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

[assembly: ExportRenderer(typeof(RadarMap), typeof(RadarMapRenderer))]

namespace Radar.iOS
{
    public class RadarMapRenderer: MapRenderer
    {
        RadarMap _radarMap;
        //UIView customPinView;
        //bool animando = false;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                nativeMap.GetViewForAnnotation = null;
            }

            if (e.NewElement != null)
            {
                _radarMap = (RadarMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
            }
        }

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
    }
}