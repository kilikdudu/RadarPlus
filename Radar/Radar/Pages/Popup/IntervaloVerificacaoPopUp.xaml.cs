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
        //private String valorSlider;
        //private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public InvervaloVerificacaoPopUp() {
            InitializeComponent();
            SliderVerificacao.ValueChanged += (sender, e) => {
                var newStep = Math.Round(e.NewValue);
                SliderVerificacao.Value = newStep;
                textValor.Text = SliderVerificacao.Value.ToString() + ((SliderVerificacao.Value > 1) ? " Dias" : " Dia");
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            int valorSlider = PreferenciaUtils.IntervaloVerificacao;
            SliderVerificacao.Value = valorSlider;
            textValor.Text = SliderVerificacao.Value.ToString() + ((valorSlider > 1) ? " Dias" : " Dia");
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            //regraPreferencia.gravar("intervaloVerificacao", (int)Math.Floor(SliderVerificacao.Value));
            PreferenciaUtils.IntervaloVerificacao = (int)Math.Floor(SliderVerificacao.Value);
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
