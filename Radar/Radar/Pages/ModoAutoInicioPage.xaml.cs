using Radar.BLL;
using Radar.Factory;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar {
    public partial class ModoAutoInicioPage : ContentPage {

        public ModoAutoInicioPage() {
            InitializeComponent();
            Title = "Auto Inicio/Desligamento";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            habilitar.IsToggled = PreferenciaUtils.InicioDesligamento;
        }

        public void habilitarToggled(object sender, ToggledEventArgs e) {
            /*
            if (e.Value == true) {
                regraPreferencia.gravar("inicioDesligamento", 1);
            } else {
                regraPreferencia.gravar("inicioDesligamento", 0);
            }
            */
            PreferenciaUtils.InicioDesligamento = e.Value;
        }
    }
}
