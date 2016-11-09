using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class InvervaloVerificacaoPopUp : PopupPage {
        private String valorSlider;
        private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public InvervaloVerificacaoPopUp() {
            InitializeComponent();
            valorSlider = Configuracao.IntervaloVerificacao;
            SliderVerificacao.Value = int.Parse(valorSlider);
            if (int.Parse(valorSlider) > 1) {
                textValor.Text = SliderVerificacao.Value.ToString() + " Dias";
            } else {
                textValor.Text = SliderVerificacao.Value.ToString() + " Dia";
            }
            
            SliderVerificacao.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("intervaloVerificacao", (int)Math.Floor(SliderVerificacao.Value));
           
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderVerificacao.Value = newStep;
           
            if (SliderVerificacao.Value > 1) {
                textValor.Text = SliderVerificacao.Value.ToString() + " Dias";
            } else {
                textValor.Text = SliderVerificacao.Value.ToString() + " Dia";
            }
            
           
        }

        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
