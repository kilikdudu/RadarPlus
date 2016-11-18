using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using UIKit;
using Radar.BLL;
using Radar.iOS;
using Xamarin.Forms;
using Radar.Model;
using Foundation;
using Radar.IBLL;
using Radar.Utils;

[assembly: Dependency(typeof(GPSiOS))]

namespace Radar.iOS
{
    public class GPSiOS: IGPS
    {
        protected CLLocationManager locMgr;

        public event EventHandler<GPSAtualizacaoEventArgs> LocationUpdated = delegate { };

        public GPSiOS()
        {
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization(); // works in background
                                                     //locMgr.RequestWhenInUseAuthorization (); // only in foreground
            }
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }

            LocationUpdated += (sender, e) => {
                CLLocation location = e.Location;
                LocalizacaoInfo local = new LocalizacaoInfo();
                local.Latitude = location.Coordinate.Latitude;
                local.Longitude = location.Coordinate.Longitude;
                local.Precisao = (float)((location.HorizontalAccuracy + location.VerticalAccuracy) / 2);
                local.Sentido = (float)location.Course;
                local.Tempo = NSDateToDateTime(location.Timestamp);
                local.Velocidade = location.Speed * 3.6;

                GPSUtils.atualizarPosicao(local);
            };

        }

        public CLLocationManager LocMgr
        {
            get { return this.locMgr; }
        }

        public bool inicializar()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                LocMgr.DesiredAccuracy = 1;

                LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
                    LocationUpdated(this, new GPSAtualizacaoEventArgs(e.Locations[e.Locations.Length - 1]));
                };

                LocMgr.StartUpdatingLocation();
                return true;
            }
            return false;
        }

        public DateTime NSDateToDateTime(NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }

        public bool estaAtivo()
        {
			return true;
        }

        public void abrirPreferencia()
        {
			
        }
    }
}