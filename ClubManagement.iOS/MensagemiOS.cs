using AudioToolbox;
using ClubManagement.IBLL;
using ClubManagement.Utils;
using Foundation;
using Radar.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using static CoreMidi.Midi;

[assembly: Dependency(typeof(MensagemiOS))]

namespace Radar.iOS
{
    public class MensagemiOS: IMensagem
    {
        public void solicitarPermissao() {
            var settings = UIUserNotificationSettings.GetSettingsForTypes(
                UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, 
                null
            );
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }

		public void exibirAviso(string Titulo, string Mensagem)
        {

        }
		public bool notificar(int id, string titulo, string descricao)
        {
            return true;
        }
        public bool notificar(int id, string titulo, string mensagem, double velocidade)
        {
            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(15);
            //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications
            notification.AlertAction = titulo;
            notification.AlertBody = mensagem;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            return true;
        }

        public bool notificarPermanente(int id, string titulo, string descricao, int idRadar, string textoRadar, string acaoParar)
        {
            return true;
        }

        public bool pararNotificaoPermanente(int id)
        {
            return true;
        }

		public bool enviarEmail(string para, string titulo, string mensagem) {
            //Device.OpenUri(new Uri("mailto:" + para + "&subject=" + UrlE));
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
