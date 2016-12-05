using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class AlturaVolumePopUp : PopupPage {
        //private String valorSlider;
        //private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public AlturaVolumePopUp() {
            InitializeComponent();
            SliderAlturaVolume.ValueChanged += (sender, e) => {
                var newStep = Math.Round(e.NewValue);
                SliderAlturaVolume.Value = newStep;
                textValor.Text = SliderAlturaVolume.Value.ToString();
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SliderAlturaVolume.Value = PreferenciaUtils.AlturaVolume;
            textValor.Text = SliderAlturaVolume.Value.ToString();
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            //regraPreferencia.gravar("alturaVolume", (int)Math.Floor(SliderAlturaVolume.Value));
            PreferenciaUtils.AlturaVolume = (int)Math.Floor(SliderAlturaVolume.Value);
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