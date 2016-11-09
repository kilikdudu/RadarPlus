using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;
using Radar.BLL;
using Radar.Factory;
using Radar.Pages.Popup;
using Rg.Plugins.Popup.Extensions;

namespace Radar
{
	public partial class ModoGeralPage : ContentPage
	{
		private static ModoGeralPage _ModoGeralPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

		public static ModoGeralPage Atual
		{
			get
			{
				return _ModoGeralPage;
			}
			private set
			{
                _ModoGeralPage = value;
			}
		}
        public ModoGeralPage() 
        {
            InitializeComponent();
            Title = "Gerais";
            //Content = new ScrollView() { Content = teststack };

			verificarIniciar.IsToggled = Configuracao.VerificarIniciar;
        }

		public void verificarIniciarToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("verificarIniciar", 1);
			}
			else {
				regraPreferencia.gravar("verificarIniciar", 0);
			}
		}

        async void intervaloVerificacaoTapped(object sender, EventArgs e) {

            var page = new InvervaloVerificacaoPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        async void desativarGPSTapped(object sender, EventArgs e) {

            var page = new DesativarGPSPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
            _ModoGeralPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            _ModoGeralPage = null;
		}
	}
}

