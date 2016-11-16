using Radar.BLL;
using Radar.Factory;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar
{
	public partial class ModoReproducaoVozPage : ContentPage
	{
        public ModoReproducaoVozPage()
		{
			InitializeComponent();
            Title = "Reprodução Voz";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            desabilitar.IsToggled = PreferenciaUtils.HabilitarVoz;
            ligarDesligar.IsToggled = PreferenciaUtils.LigarDesligar;
            encurtar.IsToggled = PreferenciaUtils.Encurtar;
            alertaSonoro.IsToggled = PreferenciaUtils.AlertaSonoro;
        }

        public void desabilitarToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("desabilitar", 1);
            } else {
                regraPreferencia.gravar("desabilitar", 0);
            }
            */
            PreferenciaUtils.HabilitarVoz = !e.Value;
        }

        public void ligarDesligarToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("ligarDesligar", 1);
            } else {
                regraPreferencia.gravar("ligarDesligar", 0);
            }
            */
            PreferenciaUtils.LigarDesligar = e.Value;
        }

        public void encurtarToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("encurtar", 1);
            } else {
                regraPreferencia.gravar("encurtar", 0);
            }
            */
            PreferenciaUtils.Encurtar = e.Value;
        }

        public void alertaSonoroToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("alertaSonoro", 1);
            } else {
                regraPreferencia.gravar("alertaSonoro", 0);
            }
            */
            PreferenciaUtils.AlertaSonoro = e.Value;
        }
    }
}
