using Xamarin.Forms;

namespace Radar.Pages
{
	public class ColaboradorTabbedPage : TabbedPage
	{
		public ColaboradorTabbedPage()
		{
			var navigationPage = new NavigationPage(new ColaboradorPage());
			//navigationPage.Icon = "schedule.png";
			//navigationPage.Title = "Schedule";

			Children.Add(new ColaboradorAdministracaoPage());
			Children.Add(navigationPage);

		}
	}
}