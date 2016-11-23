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
using Radar.Pages;
using Android.Content;
using ClubManagement.Droid;
using Android.Support.V7.App;

namespace Radar.Droid
{
    [Activity(Label = "Radar", Icon = "@drawable/appicon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int ID_RADAR_CLUB = 5;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //global::Xamarin.Forms.DependencyService.Register<MensagemAndroid>();

            //InitializeLocationManager();

            //AndroidEnvironment.UnhandledExceptionRaiser += HandleAndroidException;

            TelaAndroid.Largura = (int)Resources.DisplayMetrics.WidthPixels; // real pixels
            TelaAndroid.Altura = (int)Resources.DisplayMetrics.HeightPixels;
			TelaAndroid.LarguraSemPixel = (int)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density; // real pixels

            CurrentActivityUtils.Current = this;
            //ThreadAndroid.CurrentActivity = this;
            var broadcast = new BroadcastAndroid();
            RegisterReceiver(broadcast, new IntentFilter("br.com.cmapps.radar"));

            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            base.OnStart();
            //StartService(new Intent(this, typeof(GPSAndroid)));

            //Intent intent = new Intent(this, typeof(MainActivity));
            Intent intent = new Intent(this, typeof(GPSAndroid));
            StartService(intent);
            var intentPrincipal = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);
            builder.SetPriority((int)NotificationPriority.Max);
            builder.SetAutoCancel(true);
            builder.SetContentIntent(intentPrincipal);
            builder.SetNumber(ID_RADAR_CLUB);
            builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle("Radar+ em Funcionamento");
            //builder.SetContentText("");
            //builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));

            var acao = new Intent(this, typeof(BroadcastAndroid));
            acao.SetAction("fechar-servico");
            var pendingIntent = PendingIntent.GetBroadcast(this, 0, acao, PendingIntentFlags.UpdateCurrent);
            builder.AddAction(new Android.Support.V4.App.NotificationCompat.Action(Resource.Drawable.mystop, "Fechar", pendingIntent));

            NotificationManager notificationManager = (NotificationManager)this.GetSystemService(Context.NotificationService);
            Notification notificacao = builder.Build();
            notificacao.Flags = NotificationFlags.NoClear;
            notificationManager.Notify(ID_RADAR_CLUB, notificacao);
        }

        protected override void OnResume()
        {
            base.OnResume();
            /*
            if (_locationProvider != null)
                _locationManager.RequestLocationUpdates(_locationProvider, Configuracao.GPSTempoAtualiazacao, Configuracao.GPSDistanciaAtualizacao, this);
            */
            //Log.Debug(TAG, "Listening for location updates using " + _locationProvider + ".");
        }

        protected override void OnPause()
        {
            base.OnPause();
            //_locationManager.RemoveUpdates(this);
            //Log.Debug(TAG, "No longer listening for location updates.");
        }

        void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
        {
            /*
            Log.Error("ERROR", e.Exception.Message);
            MensagemAndroid msg = new MensagemAndroid();
            msg.exibirAviso("Erro", e.Exception.ToString());
            e.Handled = false;
            */
            //ErroPage.exibir(e.Exception);
            ///e.Handled = true;
        }
    }
}

