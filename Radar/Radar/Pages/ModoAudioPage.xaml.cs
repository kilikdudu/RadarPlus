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
		private static ModoAudioPage _ModoAudioPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
		public static ModoAudioPage Atual
		{
			get
			{
				return _ModoAudioPage;
			}
			private set
			{
				_ModoAudioPage = value;
			}
		}
        public ModoAudioPage() {
            InitializeComponent();
            Title = "Áudio";
            Content = new ScrollView() { Content = teststack };

			volumePersonalizado.IsToggled = Configuracao.SomCaixa;

			somCaixa.IsToggled = Configuracao.VolumePersonalizado;

        }

		public void volumePersonalizadoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("volumePersonalizado", 1);
			}
			else {
				regraPreferencia.gravar("volumePersonalizado", 0);
			}
		}

		public void somCaixaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("somCaixa", 1);
			}
			else {
				regraPreferencia.gravar("somCaixa", 0);
			}
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
        protected override void OnAppearing()
		{

			base.OnAppearing();
			_ModoAudioPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoAudioPage = null;
		}
    }
}
