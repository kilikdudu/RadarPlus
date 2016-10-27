using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android;
using Android.Locations;
using Radar.BLL;
using Radar.Model;

[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.Internet)]

namespace Radar.Droid
{
    [Service]
    //[IntentFilter(new String[] { "br.com.cmapps.radarservice" })]
    public class LocalizacaoServico : Service, ILocationListener
    {
        LocationManager _locationManager;
        string _locationProvider;

        public LocalizacaoServico() {
            InitializeLocationManager();
        }

        public override IBinder OnBind(Intent intent)
        {
            //throw new NotImplementedException();
            return null;
        }

        private void InitializeLocationManager()
        {
            Context context = Android.App.Application.Context;
            _locationManager = (LocationManager)context.GetSystemService(LocationService);
            //_locationManager = (LocationManager)this.GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);
            _locationManager.RequestLocationUpdates(_locationProvider, Configuracao.GPSTempoAtualiazacao, Configuracao.GPSDistanciaAtualizacao, this);
            //Log.Debug(TAG, "Using " + _locationProvider + ".");
        }

        private LocalizacaoInfo converterLocalizacao(Location location)
        {
            LocalizacaoInfo local = new LocalizacaoInfo();
            local.Latitude = location.Latitude;
            local.Longitude = location.Longitude;
            local.Precisao = location.Accuracy;
            local.Sentido = location.Bearing;
            local.Tempo = (new DateTime(1970, 1, 1)).AddMilliseconds(location.Time);
            local.Velocidade = location.Speed * 3.6;
            return local;
        }

        public void OnLocationChanged(Location location)
        {
            LocalizacaoInfo local = converterLocalizacao(location);
            GPSUtils.atualizarPosicao(local);
        }

        public void OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
            //_locationManager.RemoveUpdates();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }
    }
}