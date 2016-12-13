

using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Radar.Pages.Popup
{
	public class InstrucaoPage : PopupPage
	{



		public InstrucaoPage() {
			Navigation.PushModalAsync(new InstrucaoTabbedPage());

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

	}
}