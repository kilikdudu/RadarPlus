﻿using ClubManagement.Utils;
using Radar.BLL;
using Radar.Pages.Popup;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Pages
{
    public class ModoAudioPage: BasePreferenciaPage
    {
        Switch _SomCaixaSwitch;

        protected override string Titulo
        {
            get
            {
                return "Reprodução Voz";
            }
        }

        protected override void inicializarComponente()
        {
            _SomCaixaSwitch = new Switch
            {
                Style = EstiloUtils.PreferenciaSwitch,
                IsToggled = PreferenciaUtils.SomCaixa
            };
            _SomCaixaSwitch.Toggled += (sender, e) => {
                PreferenciaUtils.SomCaixa = e.Value;
            };
        }

        protected override void inicializarTela()
        {
            adicionarBotao("Canal de Áudio", () =>
            {
                NavigationX.create(this).PushPopupAsyncX(new CanalAudioPopUp(), true);
            }, "Define se o alerta de radares será feito através do canal de música ou através do auto-falante do dispositivo");
            adicionarBotao("Altura Volume", () =>
            {
                NavigationX.create(this).PushPopupAsyncX(new AlturaVolumePopUp(), true);
            });
            adicionarSwitch(_SomCaixaSwitch, "Som na Caixa", "Envia o som também para o alto falante do dispositivo");
            adicionarBotao("Som do Alerta", () =>
            {
                NavigationX.create(this).PushPopupAsyncX(new SomAlertaPopUp(), true);
            });
        }
    }
}
