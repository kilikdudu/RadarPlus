using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {

    public partial class DownloaderPopUp : PopupPage {

        //private String valorSlider;
        //private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public DownloaderPopUp() {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //valorSlider = PreferenciaUtils.AlturaVolume;
            //SliderAlturaVolume.Value = int.Parse(valorSlider);
            int valorSlider = PreferenciaUtils.AlturaVolume;
            SliderAlturaVolume.Value = valorSlider;
            textValor.Text = valorSlider.ToString();
            SliderAlturaVolume.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //regraPreferencia.gravar("alturaVolume", (int)Math.Floor(SliderAlturaVolume.Value));
            PreferenciaUtils.AlturaVolume = (int)Math.Floor(SliderAlturaVolume.Value);

            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderAlturaVolume.Value = newStep;
            
            textValor.Text = SliderAlturaVolume.Value.ToString();
           
        }

        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
