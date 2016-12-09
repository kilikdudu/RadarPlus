using ClubManagement.Model;
using Radar.BLL;
using Radar.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Popup
{
    public class CanalAudioPopUp : BaseListaPopup
    {
        Switch _MusicaSwitch;
        Switch _AlarmeSwitch;
        Switch _NotificacaoSwitch;

        protected override string getTitulo()
        {
            return "Canal de Áudio";
        }

        protected override double getHeight()
        {
            return 320;
        }

        protected override void inicializarComponente()
        {
            base.inicializarComponente();

            _MusicaSwitch = new Switch {
                Style = EstiloUtils.PopupSwitch,
            };
            _MusicaSwitch.Toggled += (sender, e) =>
            {
                if (_MusicaSwitch.IsToggled == true)
                {
                    _AlarmeSwitch.IsToggled = false;
                    _NotificacaoSwitch.IsToggled = false;
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Musica;
                }
                else {
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Nenhum;
                }
            };
            _AlarmeSwitch = new Switch {
                Style = EstiloUtils.PopupSwitch
            };
            _AlarmeSwitch.Toggled += (sender, e) =>
            {
                if (_AlarmeSwitch.IsToggled == true)
                {
                    _MusicaSwitch.IsToggled = false;
                    _NotificacaoSwitch.IsToggled = false;
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Alarme;
                }
                else {
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Nenhum;
                }
            };
            _NotificacaoSwitch = new Switch {
                Style = EstiloUtils.PopupSwitch
            };
            _NotificacaoSwitch.Toggled += (sender, e) =>
            {
                if (_NotificacaoSwitch.IsToggled == true)
                {
                    _MusicaSwitch.IsToggled = false;
                    _AlarmeSwitch.IsToggled = false;
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Notificacao;
                }
                else {
                    PreferenciaUtils.CanalAudio = AudioCanalEnum.Nenhum;
                }
            };
        }

        public override View inicializarConteudo()
        {
            return new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Fill,
                        Children = {
                            new Label {
                                Style = EstiloUtils.PopupTexto,
                                Text = "Música"
                            },
                            _MusicaSwitch
                        }
                    },
                    criarLinha(),
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Fill,
                        Children = {
                            new Label {
                                Style = EstiloUtils.PopupTexto,
                                Text = "Alarmes"
                            },
                            _AlarmeSwitch
                        }
                    },
                    criarLinha(),
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Fill,
                        Children = {
                            new Label {
                                Style = EstiloUtils.PopupTexto,
                                Text = "Notificações"
                            },
                            _NotificacaoSwitch
                        }
                    },
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (PreferenciaUtils.CanalAudio)
            {
                case AudioCanalEnum.Musica:
                    _MusicaSwitch.IsToggled = true;
                    break;
                case AudioCanalEnum.Alarme:
                    _AlarmeSwitch.IsToggled = true;
                    break;
                case AudioCanalEnum.Notificacao:
                    _NotificacaoSwitch.IsToggled = true;
                    break;
            }
        }
    }
}
