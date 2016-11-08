using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class TempoAlertaPopUp : PopupPage {
        private String valorSliderTempo;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public TempoAlertaPopUp() {
            InitializeComponent();
            valorSliderTempo = Configuracao.TempoAlerta;
            SliderTempo.Value = int.Parse(valorSliderTempo);
            textValorAlerta.Text = valorSliderTempo;
            SliderTempo.ValueChanged += OnSliderValueChanged;
            if (SliderTempo.Value > 1) {
                textValorAlerta.Text = SliderTempo.Value.ToString() + " Segundos";
            } else {
                textValorAlerta.Text = SliderTempo.Value.ToString() + " Segundo";
            }
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("tempoAlerta", (int)Math.Floor(SliderTempo.Value));
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderTempo.Value = newStep;
            if(SliderTempo.Value > 1) {
                textValorAlerta.Text = SliderTempo.Value.ToString() + " Segundos";
            }else {
                textValorAlerta.Text = SliderTempo.Value.ToString() + " Segundo";
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
