using System;
using ClubManagement.Controls;
using Radar.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Google.MobileAds;
using UIKit;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace Radar.iOS
{
	public class AdMobRenderer : ViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			var ad = new BannerView(size: AdSizeCons.Banner);
			ad.AdUnitID = "ca-app-pub-1940490287982396/3653019463";
			ad.RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController;
			ad.LoadRequest(Request.GetDefaultRequest());

			base.SetNativeControl(ad);
		}
	}
}
