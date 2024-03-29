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
using Radar.Utils;

[assembly: ExportRenderer(typeof(RadarMap), typeof(RadarMapRenderer))]

namespace Radar.Droid
{
    /// <summary>
    /// O projeto do RadarMapRenderer se encontra no link
    /// https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/Map
    /// Ainda � necess�rio fazer a vers�o para IOS.
    /// </summary>
    public class RadarMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        RadarMap _radarMap;
        bool animando = false;
        Marker minhaPosicao;
		RadarBLL _radarBLL;
		
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
                        if (GPSUtils.Simulado)
                            atualizarMinhaPosicao(local);
                        animando = true;
                    }
                };
                _radarMap.AoDesenharRadar += (object sender, RadarPin radar) => {
                    desenharRadar(radar);
                };
                ((MapView)Control).GetMapAsync(this);
            }
        }

        private void atualizarMinhaPosicao(LocalizacaoInfo local)
        {
            if (minhaPosicao != null)
                minhaPosicao.Position = (new LatLng(local.Latitude, local.Longitude));
            else {
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(local.Latitude, local.Longitude));
                marker.SetTitle("Minha Posi��o");
                minhaPosicao = map.AddMarker(marker);
            }
        }

        private void desenharRadar(RadarPin radar)
        {
					
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(radar.Pin.Position.Latitude, radar.Pin.Position.Longitude));
            marker.SetTitle(radar.Pin.Label);
			marker.SetSnippet(radar.Pin.Address);
				
            marker.SetRotation((float)radar.Sentido);
			switch (radar.Tipo){
				case RadarTipoEnum.RadarFixo:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/" + radar.Imagem));
				break;
				case RadarTipoEnum.SemaforoComRadar:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/radar_40_semaforo.png"));
				break;
				case RadarTipoEnum.SemaforoComCamera:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/semaforo.png"));
				break;
				case RadarTipoEnum.RadarMovel:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/radar_movel.png"));
				break;
				case RadarTipoEnum.PoliciaRodoviaria:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/policiarodoviaria.png"));
				break;
				case RadarTipoEnum.Lombada:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/lombada.png"));
				break;
				case RadarTipoEnum.Pedagio:
				marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/pedagio.png"));
				break;
				
			}
            
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