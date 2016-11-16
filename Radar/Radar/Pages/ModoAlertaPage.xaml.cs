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
        public ModoAlertaPage() {
            InitializeComponent();
            Title = "Alertas";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            radarMovel.IsToggled = PreferenciaUtils.RadarMovel;
            pedagio.IsToggled = PreferenciaUtils.Pedagio;
            policiaRodoviaria.IsToggled = PreferenciaUtils.PoliciaRodoviaria;
            lombada.IsToggled = PreferenciaUtils.Lombada;
            alertaInteligente.IsToggled = PreferenciaUtils.AlertaInteligente;
            beepAviso.IsToggled = PreferenciaUtils.BeepAviso;
            vibrarAlerta.IsToggled = PreferenciaUtils.VibrarAlerta;
            sobreposicaoVisual.IsToggled = PreferenciaUtils.SobreposicaoVisual;
        }


        public void radarMovelToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("radarMovel", 1);
			}
			else {
				regraPreferencia.gravar("radarMovel", 0);
			}
            */
            PreferenciaUtils.RadarMovel = e.Value;
		}

		public void pedagioToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("pedagio", 1);
			}
			else {
				regraPreferencia.gravar("pedagio", 0);
			}
            */
            PreferenciaUtils.Pedagio = e.Value;
        }

		public void policiaRodoviariaToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("policiaRodoviaria", 1);
			}
			else {
				regraPreferencia.gravar("policiaRodoviaria", 0);
			}
            */
            PreferenciaUtils.PoliciaRodoviaria = e.Value;
        }

		public void lombadaToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("lombada", 1);
			}
			else {
				regraPreferencia.gravar("lombada", 0);
			}
            */
            PreferenciaUtils.Lombada = e.Value;
        }

		public void alertaInteligenteToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("alertaInteligente", 1);
			}
			else {
				regraPreferencia.gravar("alertaInteligente", 0);
			}
            */
            PreferenciaUtils.AlertaInteligente = e.Value;
        }

		public void beepAvisoToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("beepAviso", 1);
			}
			else {
				regraPreferencia.gravar("beepAviso", 0);
			}
            */
            PreferenciaUtils.BeepAviso = e.Value;
        }
		public void vibrarAlertaToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("vibrarAlerta", 1);
			}
			else {
				regraPreferencia.gravar("vibrarAlerta", 0);
			}
            */
            PreferenciaUtils.VibrarAlerta = e.Value;
        }

        public void sobreposicaoVisualToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("sobreposicaoVisual", 1);
            } else {
                regraPreferencia.gravar("sobreposicaoVisual", 0);
            }
            */
            PreferenciaUtils.SobreposicaoVisual = e.Value;
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
	}
}

