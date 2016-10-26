using Radar.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Radar
{
    public class App : Application
    {
        public App()
        {
            //MainPage = new NavigationPage(new MapaPage());
            MainPage = new NavigationPage(new VelocimetroPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
