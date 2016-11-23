using AudioToolbox;
using ClubManagement.IBLL;
using ClubManagement.Utils;
using Radar.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static CoreMidi.Midi;

[assembly: Dependency(typeof(MensagemiOS))]

namespace Radar.iOS
{
    public class MensagemiOS: IMensagem
    {
		public void exibirAviso(string Titulo, string Mensagem)
        {
        }
		public bool notificar(int id, string titulo, string descricao)
        {
            return true;
        }
        public bool notificar(int id, string titulo, string mensagem, double velocidade)
        {
            return true;
        }

        public bool notificarPermanente(int id, string titulo, string descricao, int idRadar, string textoRadar, string acaoParar)
        {
            throw new NotImplementedException();
        }

        public bool pararNotificaoPermanente(int id)
        {
            throw new NotImplementedException();
        }

		public bool enviarEmail(string para, string titulo, string mensagem) {
			return false;
		}

        public void vibrar(int milisegundo)
        {
            //throw new NotImplementedException();
            //Notifications.Instance.Vibrate(2000);
            SystemSound.Vibrate.PlayAlertSound();
        }
    }
}
