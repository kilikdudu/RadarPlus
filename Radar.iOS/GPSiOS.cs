using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using UIKit;
using Radar.BLL;
using Radar.iOS;
using Xamarin.Forms;

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

            // iOS 8 has additional permissions requirements
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization(); // works in background
                                                     //locMgr.RequestWhenInUseAuthorization (); // only in foreground
            }

            // iOS 9 requires the following for background location updates
            // By default this is set to false and will not allow background updates
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }

            LocationUpdated += PrintLocation;

        }

        public CLLocationManager LocMgr
        {
            get { return this.locMgr; }
        }

        public bool inicializar()
        {

            // We need the user's permission for our app to use the GPS in iOS. This is done either by the user accepting
            // the popover when the app is first launched, or by changing the permissions for the app in Settings
            if (CLLocationManager.LocationServicesEnabled)
            {

                //set the desired accuracy, in meters
                LocMgr.DesiredAccuracy = 1;

                LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
                    // fire our custom Location Updated event
                    LocationUpdated(this, new GPSAtualizacaoEventArgs(e.Locations[e.Locations.Length - 1]));
                };

                LocMgr.StartUpdatingLocation();
                return true;
            }
            return false;
        }

        //This will keep going in the background and the foreground
        public void PrintLocation(object sender, GPSAtualizacaoEventArgs e)
        {

            CLLocation location = e.Location;
            Console.WriteLine("Altitude: " + location.Altitude + " meters");
            Console.WriteLine("Longitude: " + location.Coordinate.Longitude);
            Console.WriteLine("Latitude: " + location.Coordinate.Latitude);
            Console.WriteLine("Course: " + location.Course);
            Console.WriteLine("Speed: " + location.Speed);
        }

    }
}