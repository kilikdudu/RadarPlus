using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Radar.Controls;
using Radar.Model;
using Radar.Droid;
using Xamarin.Forms.Maps;
using System.ComponentModel;
using Radar.BLL;

[assembly: ExportRenderer(typeof(RadarMap), typeof(RadarMapRenderer))]

namespace Radar.Droid
{
    /// <summary>
    /// O projeto do RadarMapRenderer se encontra no link
    /// https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/Map
    /// Ainda é necessário fazer a versão para IOS.
    /// </summary>
    public class RadarMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        //Dictionary<string, RadarPin> _radares;
        RadarMap _radarMap;
        bool animando = false;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            //if (e.OldElement != null)
            //{
            //map.InfoWindowClick -= OnInfoWindowClick;
            //}

            if (e.NewElement != null)
            {
                //var formsMap = (RadarMap)e.NewElement;
                _radarMap = (RadarMap)e.NewElement;
                _radarMap.AoAtualizaPosicao += (object sender, LocalizacaoInfo local) => {
                    if (!animando)
                    {
                        CameraPosition.Builder builder = CameraPosition.InvokeBuilder(map.CameraPosition);
                        builder.Target(new LatLng(local.Latitude, local.Longitude));
                        builder.Bearing(local.Sentido);
                        builder.Zoom(Configuracao.MapaZoom);
                        builder.Tilt(Configuracao.MapaTilt);
                        CameraPosition cameraPosition = builder.Build();
                        CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                        map.AnimateCamera(cameraUpdate);
                        //map.CameraPosition.Bearing = rotacao;
                        animando = true;
                    }
                };
                _radarMap.AoDesenharRadar += (object sender, RadarPin radar) => {
                    desenharRadar(radar);
                };
                //_radares = formsMap.Radares;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        /*
        private void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetRadarPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }
            if (!string.IsNullOrWhiteSpace(customPin.Url))
            {
                var url = Android.Net.Uri.Parse(customPin.Url);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }
        */

        /*
        private void desenharRadar() {
            IList<RadarPin> radares = (from r in _radarMap.Radares
                                       where r.Value.Desenhado == false
                                       select r.Value).ToList();

            foreach (RadarPin radar in radares)
            {
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(radar.Pin.Position.Latitude, radar.Pin.Position.Longitude));
                marker.SetTitle(radar.Pin.Label);
                marker.SetSnippet(radar.Pin.Address);
                marker.SetRotation(radar.Sentido);
                marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/" + radar.Imagem));
                map.AddMarker(marker);

                radar.Desenhado = true;
            }
        }
        */

        private void desenharRadar(RadarPin radar)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(radar.Pin.Position.Latitude, radar.Pin.Position.Longitude));
            marker.SetTitle(radar.Pin.Label);
            marker.SetSnippet(radar.Pin.Address);
            marker.SetRotation(radar.Sentido);
            marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/" + radar.Imagem));
            map.AddMarker(marker);
        }

        /*
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            if (e.PropertyName.Equals("VisibleRegion"))
            {
                //map.Clear();
                desenharRadar();
                //isDrawn = true;
            }
        }
        */

        /*
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (changed)
            {
                isDrawn = false;
            }
        }
        */

        public Android.Views.View GetInfoContents(Marker marker)
        {
            /*
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetRadarPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (customPin.Id == "Xamarin")
                {
                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                }
                else {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }

                return view;
            }
            */
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.CameraChange += Map_CameraChange;
            //map.InfoWindowClick += OnInfoWindowClick;
            //map.SetInfoWindowAdapter(this);
        }

        private void Map_CameraChange(object sender, GoogleMap.CameraChangeEventArgs e)
        {
            animando = false;
            //map.Projection.VisibleRegion.LatLngBounds.
            LatLng c = map.Projection.VisibleRegion.LatLngBounds.Center;
            LatLng nordeste = map.Projection.VisibleRegion.LatLngBounds.Northeast;
            LatLng sudoeste = map.Projection.VisibleRegion.LatLngBounds.Southwest;
            double latitudeDelta = Math.Abs(nordeste.Latitude - sudoeste.Latitude);
            double longitudeDelta = Math.Abs(sudoeste.Longitude - nordeste.Longitude);
            MapSpan span = new MapSpan(new Position(c.Latitude, c.Longitude), latitudeDelta, longitudeDelta);
            _radarMap.atualizarAreaVisivel(span);
            //desenharRadar();
            //LatLngBounds bounds = ((GoogleMap)map).getProjection().getVisibleRegion().latLngBounds;
            //fetchData(bounds);
        }
    }
}