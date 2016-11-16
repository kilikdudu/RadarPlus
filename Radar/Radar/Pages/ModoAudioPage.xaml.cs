using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.BLL;
using Radar.Factory;
using Xamarin.Forms;
using Radar.Pages.Popup;
using Rg.Plugins.Popup.Extensions;

namespace Radar.Pages {
    public partial class ModoAudioPage : ContentPage {

        public ModoAudioPage() {
            InitializeComponent();
            Title = "Áudio";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            volumePersonalizado.IsToggled = PreferenciaUtils.VolumePersonalizado;
            somCaixa.IsToggled = PreferenciaUtils.SomCaixa;
        }


        public void volumePersonalizadoToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("volumePersonalizado", 1);
			}
			else {
				regraPreferencia.gravar("volumePersonalizado", 0);
			}
            */
            PreferenciaUtils.VolumePersonalizado = e.Value;
        }

		public void somCaixaToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("somCaixa", 1);
			}
			else {
				regraPreferencia.gravar("somCaixa", 0);
			}
            */
            PreferenciaUtils.SomCaixa = e.Value;
        }
        async void canalAudioTapped(object sender, EventArgs e) {

            var page = new CanalAudioPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }
        async void alturaVolumeTapped(object sender, EventArgs e) {

            var page = new AlturaVolumePopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        async void somAlertaTapped(object sender, EventArgs e) {

            var page = new SomAlertaPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }
    }
}
