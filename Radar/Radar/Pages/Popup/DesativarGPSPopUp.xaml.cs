using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class DesativarGPSPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public DesativarGPSPopUp() {
            InitializeComponent();
            if (Configuracao.DesativarGPS == "1") {
                SwitchFechar.IsToggled = true;
            } else if (Configuracao.DesativarGPS == "2") {
                SwitchExibir.IsToggled = true;
            } 
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        public void fecharToggled(object sender, ToggledEventArgs e1) {
                    
            if (SwitchFechar.IsToggled == true) {
                SwitchExibir.IsToggled = false;
                regraPreferencia.gravar("desativarGPS", 1);
            } else {
                regraPreferencia.gravar("desativarGPS", 0);
            }
        }
        public void exibirToggled(object sender, ToggledEventArgs e2) {
            
            if (e2.Value == true) {
                SwitchFechar.IsToggled = false;
                regraPreferencia.gravar("desativarGPS", 2);
            } else {
                regraPreferencia.gravar("desativarGPS", 0);
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
