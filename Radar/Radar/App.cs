using Radar.Controls;
using Radar.Estilo;
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
                
			if (ClubManagement.Utils.NavigationX._current == null)
			{
				MainPage = new LoginPage();
				
			}
			else {
			    var index = ClubManagement.Utils.NavigationX._current.NavigationStack.Count - 1;				
				if (index < 1)
				{
				var	currPage = new VelocimetroPage();
					MainPage = new NavegacaoPage(currPage);
				}
				else {
				var currPage = ClubManagement.Utils.NavigationX._current.NavigationStack[index];
				MainPage = new NavegacaoPage(currPage);
				}
				
			}
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