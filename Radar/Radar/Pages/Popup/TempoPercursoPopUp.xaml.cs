using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class TempoPercursoPopUp : PopupPage {
        private String valorSlider;
        private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public TempoPercursoPopUp() {
            InitializeComponent();
            valorSlider = Configuracao.TempoPercurso;
            SliderTempo.Value = int.Parse(valorSlider);
            if (int.Parse(valorSlider) > 1) {
                textValor.Text = sliderValor.ToString() + " Dias";
            } else {
                textValor.Text = sliderValor.ToString() + " Dia";
            }

            SliderTempo.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("tempoPercurso", (int)Math.Floor(sliderValor));
            Debug.WriteLine("sliderValor: " + sliderValor);
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderTempo.Value = newStep;
            sliderValor = newStep;
            if (sliderValor > 1) {
                textValor.Text = sliderValor.ToString() + " Dias";
            } else {
                textValor.Text = sliderValor.ToString() + " Dia";
            }
            
            Debug.WriteLine("sliderValor: " + sliderValor);
        }

        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
