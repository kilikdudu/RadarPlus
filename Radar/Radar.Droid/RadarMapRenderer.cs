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
        RadarMap _radarMap;
        bool animando = false;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _radarMap = (RadarMap)e.NewElement;
                _radarMap.AoAtualizaPosicao += (object sender, LocalizacaoInfo local) => {
                    if (!animando)
                    {
                        if (map == null)
                            return;
                        CameraPosition.Builder builder = CameraPosition.InvokeBuilder(map.CameraPosition);
                        builder.Target(new LatLng(local.Latitude, local.Longitude));
                        builder.Bearing(local.Sentido);
                        builder.Zoom(PreferenciaUtils.NivelZoom);
                        builder.Tilt(PreferenciaUtils.MapaTilt);
                        CameraPosition cameraPosition = builder.Build();
                        CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                        if (PreferenciaUtils.SuavizarAnimacao)
                            map.AnimateCamera(cameraUpdate);
                        else
                            map.MoveCamera(cameraUpdate);
                        animando = true;
                    }
                };
                _radarMap.AoDesenharRadar += (object sender, RadarPin radar) => {
                    desenharRadar(radar);
                };
                ((MapView)Control).GetMapAsync(this);
            }
        }
            
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

        public Android.Views.View GetInfoContents(Marker marker)
        {
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            if (PreferenciaUtils.InfoTrafego)
                googleMap.TrafficEnabled = true;
            googleMap.UiSettings.SetAllGesturesEnabled(PreferenciaUtils.RotacionarMapa);
            //googleMap.UiSettings.RotateGesturesEnabled = PreferenciaUtils.RotacionarMapa;
            googleMap.UiSettings.MyLocationButtonEnabled = false;
            googleMap.UiSettings.ZoomControlsEnabled = false;
            googleMap.UiSettings.MapToolbarEnabled = false;
            map.CameraChange += (sender, e) => {
                animando = false;
                LatLng c = map.Projection.VisibleRegion.LatLngBounds.Center;
                LatLng nordeste = map.Projection.VisibleRegion.LatLngBounds.Northeast;
                LatLng sudoeste = map.Projection.VisibleRegion.LatLngBounds.Southwest;
                double latitudeDelta = Math.Abs(nordeste.Latitude - sudoeste.Latitude);
                double longitudeDelta = Math.Abs(sudoeste.Longitude - nordeste.Longitude);
                MapSpan span = new MapSpan(new Position(c.Latitude, c.Longitude), latitudeDelta, longitudeDelta);
                _radarMap.atualizarAreaVisivel(span);
            };
        }
    }
}