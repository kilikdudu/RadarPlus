using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using System.Collections.Generic;
using Android;

[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.Internet)]

namespace Radar.Droid
{
    [Activity(Label = "Radar", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ILocationListener
    {
        LocationManager _locationManager;
        string _locationProvider;

        private LocalizacaoInfo converterLocalizacao(Location location) {
            LocalizacaoInfo local = new LocalizacaoInfo();
            local.Latitude = location.Latitude;
            local.Longitude = location.Longitude;
            local.Precisao = location.Accuracy;
            local.Sentido = location.Bearing;
            local.Tempo = location.Time;
            local.Velocidade = location.Speed;
            return local;
        }

        public void OnLocationChanged(Location location)
        {
            RadarBLL regraRadar = RadarFactory.create();
            LocalizacaoInfo local = converterLocalizacao(location);
            regraRadar.calcularLocalizacao(local);
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            InitializeLocationManager();

            LoadApplication(new App());
        }

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);
            //Log.Debug(TAG, "Using " + _locationProvider + ".");
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (_locationProvider != null)
            {
                _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            }
            //Log.Debug(TAG, "Listening for location updates using " + _locationProvider + ".");
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
            //Log.Debug(TAG, "No longer listening for location updates.");
        }
    }
}

