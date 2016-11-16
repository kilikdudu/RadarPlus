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
        //private String valorSlider;
        
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public TempoPercursoPopUp() {
            InitializeComponent();
            SliderTempo.ValueChanged += (sender, e) => {
                var newStep = Math.Round(e.NewValue);
                SliderTempo.Value = newStep;

                if (SliderTempo.Value > 1)
                    textValor.Text = SliderTempo.Value.ToString() + " Dias";
                else
                    textValor.Text = SliderTempo.Value.ToString() + " Dia";
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            int valorSlider = PreferenciaUtils.TempoPercurso;
            SliderTempo.Value = valorSlider;
            if (valorSlider > 1)
                textValor.Text = SliderTempo.Value.ToString() + " Dias";
            else
                textValor.Text = SliderTempo.Value.ToString() + " Dia";

        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            //regraPreferencia.gravar("tempoPercurso", (int)Math.Floor(SliderTempo.Value));
            PreferenciaUtils.TempoPercurso = (int)Math.Floor(SliderTempo.Value);

            PopupNavigation.PopAsync();
        }

        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
