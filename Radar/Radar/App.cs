using Radar.Controls;
using Radar.Pages;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
    public class App : Application
    {
        public App()
        {
            //MainPage = new NavigationPage(new MapaPage());
            //MainPage = new NavigationPage(new PercursoPage());
	    //MainPage = new LoginPage();
            EstiloUtils.inicializar();
			MainPage = new NavegacaoPage();
			//MainPage = new Radar.Controls.RadarMasterDetailPage();
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