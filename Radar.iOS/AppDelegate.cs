using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using ClubManagement.iOS;

namespace Radar.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate :
	global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            global::Xamarin.Forms.Forms.Init();
			global::Xamarin.FormsMaps.Init();
			LoadApplication(new App());  // method is new in 1.3

            CurrentDelegateUtils.Current = this;
			var settings = UIUserNotificationSettings.GetSettingsForTypes( UIUserNotificationType.Badge , null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			UIApplication.SharedApplication.IdleTimerDisabled = true;
            bool retorno = base.FinishedLaunching(app, options);

            //GPSiOS gps = new GPSiOS();
            //gps.inicializar();

            return retorno;
        }
    }
}