using MapKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.iOS
{
    public class RadarMKAnnotationView : MKAnnotationView
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public RadarMKAnnotationView(IMKAnnotation annotation, string id) : base(annotation, id) {
        }
    }
}
