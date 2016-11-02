
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using Radar.Controls;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CoreGraphics;
using Xamarin.Forms.Maps;
using Radar.iOS;
using Radar.Model;
using Radar.BLL;

[assembly: ExportRenderer(typeof(RadarMap), typeof(RadarMapRenderer))]

namespace Radar.iOS
{
    public class RadarMapRenderer: MapRenderer
    {
        RadarMap _radarMap;
        MKMapView _nativeMap;
        //UIView customPinView;
        //bool animando = false;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                _nativeMap = Control as MKMapView;
                //_nativeMap.GetViewForAnnotation = null;
            }

            if (e.NewElement != null)
            {
                _radarMap = (RadarMap)e.NewElement;
                _nativeMap = Control as MKMapView;
                //_nativeMap.GetViewForAnnotation = GetViewForAnnotation;
                _radarMap.AoAtualizaPosicao += (object sender, LocalizacaoInfo local) => {
                    CoreLocation.CLLocationCoordinate2D target = new CoreLocation.CLLocationCoordinate2D(local.Latitude, local.Longitude);

                    MKMapCamera camera = MKMapCamera.CameraLookingAtCenterCoordinate(target, Configuracao.MapaZoom, local.Sentido, local.Sentido);
                    _nativeMap.Camera = camera;
                    /*
                    if (!animando)
                    {
                        if (map == null)
                            return;
                        CameraPosition.Builder builder = CameraPosition.InvokeBuilder(map.CameraPosition);
                        builder.Target(new LatLng(local.Latitude, local.Longitude));
                        builder.Bearing(local.Sentido);
                        builder.Zoom(Configuracao.MapaZoom);
                        builder.Tilt(Configuracao.MapaTilt);
                        CameraPosition cameraPosition = builder.Build();
                        CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                        map.AnimateCamera(cameraUpdate);
                        animando = true;
                    }
                    */
                };
                _radarMap.AoDesenharRadar += (object sender, RadarPin radar) => {
                    desenharRadar(radar);
                };
            }
        }

        private void desenharRadar(RadarPin radar)
        {
            var marker = new MKPointAnnotation()
            {
                Coordinate = new CoreLocation.CLLocationCoordinate2D(radar.Pin.Position.Latitude, radar.Pin.Position.Longitude),
                Title = radar.Pin.Label,
                Subtitle = radar.Pin.Address
            };
            _nativeMap.AddAnnotation(marker);
            /*
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(radar.Pin.Position.Latitude, radar.Pin.Position.Longitude));
            marker.SetTitle(radar.Pin.Label);
            marker.SetSnippet(radar.Pin.Address);
            marker.SetRotation(radar.Sentido);
            marker.SetIcon(BitmapDescriptorFactory.FromAsset("radares/" + radar.Imagem));
            map.AddMarker(marker);
            */
        }

        /*
        MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;

            var anno = annotation as MKPointAnnotation;
            string chave = anno.Coordinate.Latitude.ToString() + "|" + anno.Coordinate.Longitude.ToString();
            RadarPin customPin = _radarMap.Radares[chave];
            if (customPin == null)
                throw new Exception("Custom pin not found");

            annotationView = mapView.DequeueReusableAnnotation(customPin.Id);
            if (annotationView == null)
            {
                annotationView = new RadarMKAnnotationView(annotation, customPin.Id);
                annotationView.Image = UIImage.FromFile("pin.png");
                annotationView.CalloutOffset = new CGPoint(0, 0);
                annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("monkey.png"));
                annotationView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
                //((RadarMKAnnotationView)annotationView).Id = customPin.Id;
                //((RadarMKAnnotationView)annotationView).Url = customPin.Url;
            }
            annotationView.CanShowCallout = true;

            return annotationView;
        }
        */
    }
}