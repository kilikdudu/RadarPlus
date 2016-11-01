using MapKit;
using System;
using System.Collections.Generic;
using System.Text;
using CoreLocation;
using Radar.Controls;

namespace Radar.iOS
{
    public class RadarMKAnnotation : MKAnnotation
    {
        public RadarPin Radar { get; set; }

        public override CLLocationCoordinate2D Coordinate {
            get {
                if (Radar != null) {
                    return new CLLocationCoordinate2D(Radar.Pin.Position.Latitude, Radar.Pin.Position.Longitude);
                }
                return new CLLocationCoordinate2D();
            }
        }

        public RadarMKAnnotation(RadarPin radar) {
            Radar = radar;
        }
    }
}
