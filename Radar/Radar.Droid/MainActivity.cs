﻿using System;

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

namespace Radar.Droid
{
    [Activity(Label = "Radar", Icon = "@drawable/appicon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
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
            StartService(new Intent(this, typeof(GPSAndroid)));
            //StartService(new Intent("br.com.cmapps.radarservice"));
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

