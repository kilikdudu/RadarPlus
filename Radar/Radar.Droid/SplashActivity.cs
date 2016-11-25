using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace Radar.Droid {
    [Activity(Label = "Radar", MainLauncher = true, NoHistory = true, Icon = "@drawable/appicon", Theme = "@style/Theme.Splash")]
    public class SplashActivity : Activity {
		System.Timers.Timer t;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

			LinearLayout linLayout = new LinearLayout(this);
			linLayout.Orientation = Orientation.Vertical;
			linLayout.SetBackgroundColor(Color.Black);

			ImageView imgView = new ImageView(this);

			if (Resources.Configuration.Orientation.ToString() == "Landscape")
			{
				imgView.SetImageResource(Resource.Drawable.bgLand);
			}
			else {
				imgView.SetImageResource(Resource.Drawable.bg);
			}


			LinearLayout.LayoutParams imgParams = new LinearLayout.LayoutParams(WindowManagerLayoutParams.WrapContent, WindowManagerLayoutParams.WrapContent);

			imgParams.Gravity = GravityFlags.Center;
			linLayout.AddView(imgView,imgParams);
			ViewGroup.LayoutParams linLayoutParam = new ViewGroup.LayoutParams(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.MatchParent);
			this.SetContentView(linLayout, linLayoutParam);
			t = new System.Timers.Timer();
			t.Interval = 6000;
			t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
			t.Start();
			//System.Threading.Thread.Sleep(3000); //Aguarda 3 segundos
            this.StartActivity(typeof(MainActivity)); //Inicia próxima Activity 
                                                      // Create your application here
        }
		protected void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			t.Stop();
			this.StartActivity(typeof(MainActivity));
		}
    }
}

