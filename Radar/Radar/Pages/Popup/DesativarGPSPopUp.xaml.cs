using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;
using Radar.Model;

namespace Radar.Pages.Popup {
    public partial class DesativarGPSPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public DesativarGPSPopUp() {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (PreferenciaUtils.AoDesativarGPS == AoDesativarGPSEnum.FecharOPrograma)
                SwitchFechar.IsToggled = true;
            else if (PreferenciaUtils.AoDesativarGPS == AoDesativarGPSEnum.ExibirNotificacao)
                SwitchExibir.IsToggled = true;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        public void fecharToggled(object sender, ToggledEventArgs e1) {
                    
            if (SwitchFechar.IsToggled == true) {
                SwitchExibir.IsToggled = false;
                //regraPreferencia.gravar("desativarGPS", 1);
                PreferenciaUtils.AoDesativarGPS = AoDesativarGPSEnum.FecharOPrograma;
            } else {
                //regraPreferencia.gravar("desativarGPS", 0);
                PreferenciaUtils.AoDesativarGPS = AoDesativarGPSEnum.FazerNada;
            }
        }
        public void exibirToggled(object sender, ToggledEventArgs e2) {
            
            if (SwitchExibir.IsToggled == true) {
                SwitchFechar.IsToggled = false;
                //regraPreferencia.gravar("desativarGPS", 2);
                PreferenciaUtils.AoDesativarGPS = AoDesativarGPSEnum.ExibirNotificacao;
            } else {
                //regraPreferencia.gravar("desativarGPS", 0);
                PreferenciaUtils.AoDesativarGPS = AoDesativarGPSEnum.FazerNada;
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
