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
    [Activity(Label = "Radar", Icon = "@drawable/appicon", Theme = "@style/MainTheme", MainLauncher = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static JanelaSituacaoEnum _Situacao = JanelaSituacaoEnum.Fechada;

        public static JanelaSituacaoEnum Situacao {
            get {
                return _Situacao;
            }
            set {
                _Situacao = value;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            _Situacao = JanelaSituacaoEnum.Inicializando;

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
			TelaAndroid.AlturaSemPixel = (int)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density; // real pixels

			TelaAndroid.LarguraDPI = (int)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Xdpi; // real pixels
			TelaAndroid.AlturaDPI = (int)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Ydpi; // real pixels

			TelaAndroid.Orientacao = Resources.Configuration.Orientation.ToString();


            CurrentActivityUtils.Current = this;
            //ThreadAndroid.CurrentActivity = this;
            var broadcast = new BroadcastAndroid();
            RegisterReceiver(broadcast, new IntentFilter(Intent.ActionBootCompleted));

            LoadApplication(new App());
        }

        public bool isServiceRunning(Type serviceClassName)
        {
            ActivityManager activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);
            var services = activityManager.GetRunningServices(int.MaxValue);
            foreach (var runningServiceInfo in services)
            {
                if (runningServiceInfo.Service.GetType().Equals(serviceClassName))
                    return true;
            }
            return false;
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (!isServiceRunning(typeof(GPSAndroid)))
            {
                var serviceIntent = new Intent(this, typeof(GPSAndroid));
                serviceIntent.PutExtra("ativo", true);
                StartService(serviceIntent);
            }
            /*
            if (!isServiceRunning(typeof(GPSAndroid)))
                StartService(new Intent(this, typeof(GPSAndroid)));
            */
            _Situacao = JanelaSituacaoEnum.Aberta;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
            _Situacao = JanelaSituacaoEnum.Fechada;
        }

        private void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
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

    public enum JanelaSituacaoEnum {
        Inicializando,
        Aberta,
        Fechada
    } 
}

