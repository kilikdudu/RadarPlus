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
        
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public TempoDuracaoPopUp() {
            InitializeComponent();
            valorSliderDuracao = Configuracao.TempoDuracao;
            SliderDuracao.Value = int.Parse(valorSliderDuracao);
           
            if (int.Parse(valorSliderDuracao) > 1) {
                textValor.Text = valorSliderDuracao + " Segundos";
            } else {
                textValor.Text = valorSliderDuracao + " Segundo";
            }
            SliderDuracao.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("tempoDuracao", (int)Math.Floor(SliderDuracao.Value));
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderDuracao.Value = newStep;
           
            if(SliderDuracao.Value > 1) {
                textValor.Text = SliderDuracao.Value.ToString() + " Segundos";
            }else {
                textValor.Text = SliderDuracao.Value.ToString() + " Segundo";
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
