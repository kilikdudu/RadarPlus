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
            notification.AlertTitle = titulo;
            notification.AlertAction = titulo;
            notification.AlertBody = mensagem;
			notification.SoundName = UILocalNotification.DefaultSoundName;
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
            Device.OpenUri(new Uri(
                "mailto:" + para + 
                "&subject=" + System.Net.WebUtility.UrlEncode(titulo) +
                "&body=" + mensagem));
            return false;
        }

        public void vibrar(int milisegundo)
        {
            //throw new NotImplementedException();
            //Notifications.Instance.Vibrate(2000);
            SystemSound.Vibrate.PlayAlertSound();
        }


		//private const string NotificationSoundPath = @"/System/Library/Audio/UISounds/New/Fanfare.caf";
        public bool notificariOS(int id, string titulo, string descricao, double velocidade, string audio)
        {
            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(15);
            notification.AlertTitle = titulo;
            notification.AlertAction = titulo;
            notification.AlertBody = descricao;
			notification.ApplicationIconBadgeNumber += 1;
			//notification.SoundName = UILocalNotification.DefaultSoundName;

			//if (count == 0)
			//{
			if (audio == null)
			{
				audio = @"/System/Library/Audio/UISounds/New/Fanfare.caf";
			}
			//	TriggerSoundAndViber(audio);
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			//}
			//else {
			//TriggerSoundAndViber(audio);
			//}
			return true;

        }




		public static void TriggerSoundAndViber(string audio)
		{
			NSUrl url = NSUrl.FromFilename(audio);
			//SystemSound notificationSound = SystemSound.FromFile(NotificationSoundPath);
			SystemSound mySound = new SystemSound(url);
			mySound.AddSystemSoundCompletion(SystemSound.Vibrate.PlaySystemSound);
			mySound.PlaySystemSound();

		}


	}
}
