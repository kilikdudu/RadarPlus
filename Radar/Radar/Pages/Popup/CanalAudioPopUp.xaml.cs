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
    public partial class CanalAudioPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public CanalAudioPopUp() {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (PreferenciaUtils.CanalAudio)
            {
                case CanalAudioEnum.Musica:
                    SwitchMusica.IsToggled = true;
                    break;
                case CanalAudioEnum.Alarme:
                    SwitchAlarmes.IsToggled = true;
                    break;
                case CanalAudioEnum.Notificacao:
                    SwitchNotificacoes.IsToggled = true;
                    break;
            }
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        public void musicaToggled(object sender, ToggledEventArgs e1) {
            if (SwitchMusica.IsToggled == true) {
                SwitchAlarmes.IsToggled = false;
                SwitchNotificacoes.IsToggled = false;
                //regraPreferencia.gravar("canalAudio", 1);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Musica;
            } else {
                //regraPreferencia.gravar("canalAudio", 0);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Nenhum;
            }
        }

        public void alarmesToggled(object sender, ToggledEventArgs e2) {
            

            if (e2.Value == true) {
                SwitchMusica.IsToggled = false;
                SwitchNotificacoes.IsToggled = false;
                //regraPreferencia.gravar("canalAudio", 2);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Alarme;
            } else {
                //regraPreferencia.gravar("canalAudio", 0);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Nenhum;
            }
        }

        public void notificacoesToggled(object sender, ToggledEventArgs e3) {
           
           
            if (e3.Value == true) {
                SwitchMusica.IsToggled = false;
                SwitchAlarmes.IsToggled = false;
                //regraPreferencia.gravar("canalAudio", 3);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Notificacao;
            } else {
                //regraPreferencia.gravar("canalAudio", 0);
                PreferenciaUtils.CanalAudio = CanalAudioEnum.Nenhum;
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
