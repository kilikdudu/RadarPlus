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
	public partial class ModoAlertaPage : ContentPage
	{
		private static ModoAlertaPage _ModoAlertaPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

		public static ModoAlertaPage Atual
		{
			get
			{
				return _ModoAlertaPage;
			}
			private set
			{
                _ModoAlertaPage = value;
			}
		}
        
        public ModoAlertaPage() {
            InitializeComponent();
            Title = "Alertas";
            //Content = new ScrollView() { Content = teststack };

			radarMovel.IsToggled = Configuracao.RadarMovel;

			pedagio.IsToggled = Configuracao.Pedagio;

			policiaRodoviaria.IsToggled = Configuracao.PoliciaRodoviaria;

			lombada.IsToggled = Configuracao.Lombada;

			alertaInteligente.IsToggled = Configuracao.AlertaInteligente;

			beepAviso.IsToggled = Configuracao.BeepAviso;

			vibrarAlerta.IsToggled = Configuracao.VibrarAlerta;

            sobreposicaoVisual.IsToggled = Configuracao.SobreposicaoVisual;
        }

		public void radarMovelToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("radarMovel", 1);
			}
			else {
				regraPreferencia.gravar("radarMovel", 0);
			}
		}

		public void pedagioToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("pedagio", 1);
			}
			else {
				regraPreferencia.gravar("pedagio", 0);
			}
		}

		public void policiaRodoviariaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("policiaRodoviaria", 1);
			}
			else {
				regraPreferencia.gravar("policiaRodoviaria", 0);
			}
		}
		public void lombadaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("lombada", 1);
			}
			else {
				regraPreferencia.gravar("lombada", 0);
			}
		}
		public void alertaInteligenteToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("alertaInteligente", 1);
			}
			else {
				regraPreferencia.gravar("alertaInteligente", 0);
			}
		}
		public void beepAvisoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("beepAviso", 1);
			}
			else {
				regraPreferencia.gravar("beepAviso", 0);
			}
		}
		public void vibrarAlertaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("vibrarAlerta", 1);
			}
			else {
				regraPreferencia.gravar("vibrarAlerta", 0);
			}
		}

        public void sobreposicaoVisualToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("sobreposicaoVisual", 1);
            } else {
                regraPreferencia.gravar("sobreposicaoVisual", 0);
            }
        }
        async void tempoDuracaoTapped(object sender, EventArgs e) {

            var page = new TempoDuracaoPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        async void tempoAlertaTapped(object sender, EventArgs e) {

            var page = new TempoAlertaPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        async void distanciaAlertaTapped(object sender, EventArgs e) {

            var page = new DistanciaAlertaPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
            _ModoAlertaPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            _ModoAlertaPage = null;
		}
	}
}

