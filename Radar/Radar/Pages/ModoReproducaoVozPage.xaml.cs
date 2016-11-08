using Radar.BLL;
using Radar.Factory;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar
{
	public partial class ModoReproducaoVozPage : ContentPage
	{
        private static ModoReproducaoVozPage _ModoReproducaoVozPage;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public static ModoReproducaoVozPage Atual
        {
            get
            {
                return _ModoReproducaoVozPage;
            }
            private set
            {
                _ModoReproducaoVozPage = value;
            }
        }
        public ModoReproducaoVozPage()
		{
			InitializeComponent();
            Title = "Reprodução Voz";
            //Content = new ScrollView() { Content = teststack };
            desabilitar.IsToggled = Configuracao.Desabilitar;

            ligarDesligar.IsToggled = Configuracao.LigarDesligar;

            encurtar.IsToggled = Configuracao.Encurtar;

            alertaSonoro.IsToggled = Configuracao.AlertaSonoro;

            
        }
        public void desabilitarToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("desabilitar", 1);
            } else {
                regraPreferencia.gravar("desabilitar", 0);
            }
        }

        public void ligarDesligarToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("ligarDesligar", 1);
            } else {
                regraPreferencia.gravar("ligarDesligar", 0);
            }
        }

        public void encurtarToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("encurtar", 1);
            } else {
                regraPreferencia.gravar("encurtar", 0);
            }
        }

        public void alertaSonoroToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("alertaSonoro", 1);
            } else {
                regraPreferencia.gravar("alertaSonoro", 0);
            }
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            _ModoReproducaoVozPage = this;
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            _ModoReproducaoVozPage = null;
        }
    }
}
