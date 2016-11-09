using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class DistanciaAlertaPopUp : PopupPage {
        private String valorSliderUrbano;
        private String valorSliderEstrada;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public DistanciaAlertaPopUp() {
            InitializeComponent();
            valorSliderUrbano = Configuracao.DistanciaAlertaUrbano;
            if(valorSliderUrbano == "0") {
                SliderUrbano.Value = 50;
            }else {
                SliderUrbano.Value = int.Parse(valorSliderUrbano);
            }
            
            distanciaUrbano.Text = valorSliderUrbano;
            SliderUrbano.ValueChanged += OnSliderValueChangedUrbano;

            valorSliderEstrada = Configuracao.DistanciaAlertaEstrada;
            if (valorSliderEstrada == "0") {
                SliderEstrada.Value = 300;
            } else {
                SliderEstrada.Value = int.Parse(valorSliderEstrada);
            }
            distanciaEstrada.Text = valorSliderEstrada;
            SliderEstrada.ValueChanged += OnSliderValueChangedEstrada;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("distanciaAlertaUrbano", (int)Math.Floor(SliderUrbano.Value));
            regraPreferencia.gravar("distanciaAlertaEstrada", (int)Math.Floor(SliderEstrada.Value));

            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChangedUrbano(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderUrbano.Value = newStep;   
            distanciaUrbano.Text = SliderUrbano.Value.ToString() + " M";
            
        }

        private void OnSliderValueChangedEstrada(object sender, ValueChangedEventArgs e2) {
            var newStep2 = Math.Round(e2.NewValue);
            SliderEstrada.Value = e2.NewValue;
            distanciaEstrada.Text = Math.Floor(SliderEstrada.Value).ToString() + " M";
        }
        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
