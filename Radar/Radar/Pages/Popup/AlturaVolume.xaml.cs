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
        private String valorSlider;
        private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public AlturaVolumePopUp() {
            InitializeComponent();
            valorSlider = Configuracao.AlturaVolume;
            SliderAlturaVolume.Value = int.Parse(valorSlider);
            textValor.Text = valorSlider;
            SliderAlturaVolume.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("alturaVolume", (int)Math.Floor(sliderValor));
            Debug.WriteLine("sliderValor: " + sliderValor);
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            SliderAlturaVolume.Value = newStep;
            sliderValor = newStep;
            textValor.Text = sliderValor.ToString();
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
