using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class CanalAudioPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public CanalAudioPopUp() {
            InitializeComponent();
            if (Configuracao.CanalAudio == "1") {
                SwitchMusica.IsToggled = true;
            } else if (Configuracao.CanalAudio == "2") {
                SwitchAlarmes.IsToggled = true;
            } else if (Configuracao.CanalAudio == "3") {
                SwitchNotificacoes.IsToggled = true;
            }
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        public void musicaToggled(object sender, ToggledEventArgs e1) {
            
            
            
            
            if (SwitchMusica.IsToggled == true) {
                SwitchAlarmes.IsToggled = false;

                SwitchNotificacoes.IsToggled = false;
                regraPreferencia.gravar("canalAudio", 1);
            } else {
                regraPreferencia.gravar("canalAudio", 0);
            }
        }
        public void alarmesToggled(object sender, ToggledEventArgs e2) {
            

            if (e2.Value == true) {
                SwitchMusica.IsToggled = false;

                SwitchNotificacoes.IsToggled = false;
                regraPreferencia.gravar("canalAudio", 2);
            } else {
                regraPreferencia.gravar("canalAudio", 0);
            }
        }

        public void notificacoesToggled(object sender, ToggledEventArgs e3) {
           
           
            if (e3.Value == true) {
                SwitchMusica.IsToggled = false;
                SwitchAlarmes.IsToggled = false;
                regraPreferencia.gravar("canalAudio", 3);
            } else {
                regraPreferencia.gravar("canalAudio", 0);
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
