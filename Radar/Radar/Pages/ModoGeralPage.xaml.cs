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
        public ModoGeralPage() 
        {
            InitializeComponent();
            Title = "Gerais";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            verificarIniciar.IsToggled = PreferenciaUtils.VerificarIniciar;
        }


        public void verificarIniciarToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("verificarIniciar", 1);
			}
			else {
				regraPreferencia.gravar("verificarIniciar", 0);
			}
            */
            PreferenciaUtils.VerificarIniciar = e.Value;
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
	}
}

