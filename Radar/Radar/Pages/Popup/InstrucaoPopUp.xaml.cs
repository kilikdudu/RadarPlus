using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;
using ClubManagement.Utils;

namespace Radar.Pages.Popup
{
	public partial class InstrucaoPopUp : PopupPage
	{
		//private String valorSliderUrbano;
		//private String valorSliderEstrada;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

		public InstrucaoPopUp()
		{
			InitializeComponent();
			Title = "Instruções";
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

		}



		protected override Task OnAppearingAnimationEnd()
		{
			return Content.FadeTo(1);
		}

		protected override Task OnDisappearingAnimationBegin()
		{
			return Content.FadeTo(1);
		}
	}
}
