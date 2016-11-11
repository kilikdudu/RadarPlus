using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Radar.Droid {
    [Activity(Label = "Radar", MainLauncher = true, NoHistory = true, Icon = "@drawable/appicon", Theme = "@style/Theme.Splash")]
    public class SplashActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            System.Threading.Thread.Sleep(3000); //Aguarda 3 segundos
            this.StartActivity(typeof(MainActivity)); //Inicia próxima Activity 
                                                      // Create your application here
        }
    }
}

