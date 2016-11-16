using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class NivelZoomPopUp : PopupPage {
        //private String valorSlider;
        
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public NivelZoomPopUp() {
            InitializeComponent();
            Slider.ValueChanged += (sender, e) => {
                var newStep = Math.Round(e.NewValue);
                Slider.Value = newStep;
                textValor.Text = Slider.Value.ToString();
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Slider.Value = PreferenciaUtils.NivelZoom;
            textValor.Text = Slider.Value.ToString();
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            //regraPreferencia.gravar("nivelZoom", (int)Math.Floor(Slider.Value));
            PreferenciaUtils.NivelZoom = (int)Math.Floor(Slider.Value);

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
