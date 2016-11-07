using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class TempoDuracaoPopUp : PopupPage {
        private String valorSliderDuracao;
        private double sliderValorDuracao;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public TempoDuracaoPopUp() {
            InitializeComponent();
            valorSliderDuracao = Configuracao.TempoDuracao;
            SliderDuracao.Value = int.Parse(valorSliderDuracao);
            textValor.Text = valorSliderDuracao;
            SliderDuracao.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("tempoDuracao", (int)Math.Floor(sliderValorDuracao));
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderDuracao.Value = newStep;
            sliderValorDuracao = newStep;
            if(sliderValorDuracao > 1) {
                textValor.Text = sliderValorDuracao.ToString() + " Segundos";
            }else {
                textValor.Text = sliderValorDuracao.ToString() + " Segundo";
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
