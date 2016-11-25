using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android;
using Android.Locations;
using Radar.BLL;
using Radar.Model;
using Radar.Droid;
using Xamarin.Forms;
using Radar.IBLL;
using Radar.Utils;
using Android.Support.V7.App;

[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.Internet)]

[assembly: Dependency(typeof(GPSAndroid))]

namespace Radar.Droid
{
    [Service]
    [IntentFilter(new String[] { "br.com.cmapps.radar" })]
    public class GPSAndroid : Service, ILocationListener, IGPS
    {
        private const int ID_RADAR_CLUB = 5;

        LocationManager _locationManager;
        string _locationProvider;

        public GPSAndroid() {
            //InitializeLocationManager();
        }

        DemoServiceBinder binder;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            inicializar();
            StartServiceInForeground();
            //DoWork();
            return StartCommandResult.NotSticky;
        }

        void StartServiceInForeground()
        {
            var ongoing = new Notification(Resource.Drawable.navicon, "Radar+");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            ongoing.SetLatestEventInfo(this, "Radar+", "Está em funcionamento", pendingIntent);
            StartForeground((int)NotificationFlags.ForegroundService, ongoing);
        }

        /*
        void SendNotification()
        {
            var nMgr = (NotificationManager)GetSystemService(NotificationService);
            var notification = new Notification(Resource.Drawable.icon, "Message from demo service");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            notification.SetLatestEventInfo(this, "Demo Service Notification", "Message from demo service", pendingIntent);
            nMgr.Notify(0, notification);
        }
        */

        public override IBinder OnBind(Intent intent)
        {
            binder = new DemoServiceBinder(this);
            return binder;
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

        public bool inicializar()
        {
            Context context = Android.App.Application.Context;
            _locationManager = (LocationManager)context.GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);
            _locationManager.RequestLocationUpdates(_locationProvider, PreferenciaUtils.GPSTempoAtualiazacao, PreferenciaUtils.GPSDistanciaAtualizacao, this);
            exibirNotificacao();
            return true;
        }

        public void exibirNotificacao() {

            //Intent servIntent = new Intent(this, typeof(GPSAndroid));
            //Intent servIntent = new Intent();
            //var intentPrincipal = PendingIntent.GetActivity(this, 0, servIntent, PendingIntentFlags.OneShot);

            /*
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);
            builder.SetPriority((int)NotificationPriority.Max);
            builder.SetAutoCancel(true);
            //builder.SetContentIntent(intentPrincipal);
            builder.SetNumber(ID_RADAR_CLUB);
            builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle("Radar+ em Funcionamento");
            */
            /*
            var acao = new Intent(this, typeof(BroadcastAndroid));
            acao.SetAction("fechar-servico");
            var pendingIntent = PendingIntent.GetBroadcast(this, 0, acao, PendingIntentFlags.UpdateCurrent);
            builder.AddAction(new NotificationCompat.Action(Resource.Drawable.mystop, "Fechar", pendingIntent));
            */

            /*
            //NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            Notification notificacao = builder.Build();
            notificacao.Flags = NotificationFlags.NoClear;
            //notificationManager.Notify(ID_RADAR_CLUB, notificacao);

            StartForeground(ID_RADAR_CLUB, notificacao);
            */
            //var ongoing = new Notification(Resource.Drawable.icon, "DemoService in foreground");
            //var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            //ongoing.SetLatestEventInfo(this, "DemoService", "DemoService is running in the foreground", pendingIntent);

            //StartForeground((int)NotificationFlags.ForegroundService, ongoing);
        }

        public bool estaAtivo()
        {
            Context context = Android.App.Application.Context;
            if (_locationManager == null)
                _locationManager = (LocationManager)context.GetSystemService(LocationService);
            //LocationManager gpsServico  = (LocationManager)context.GetSystemService(LocationManager.GpsProvider);
            if (_locationManager != null)
                return _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
            return false;
        }

        public void abrirPreferencia()
        {
            Context context = Android.App.Application.Context;
            Intent myIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            myIntent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(myIntent);
        }

        public class DemoServiceBinder : Binder
        {
            GPSAndroid service;

            public DemoServiceBinder(GPSAndroid service)
            {
                this.service = service;
            }

            public GPSAndroid GetDemoService()
            {
                return service;
            }
        }
    }
}