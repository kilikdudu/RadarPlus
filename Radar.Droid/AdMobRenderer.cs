using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using Xamarin.Forms;
using ClubManagement.Controls;
using Radar.Droid;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace Radar.Droid
{

    public class AdMobRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            var ad = new AdView(Android.App.Application.Context);
            ad.AdSize = AdSize.Banner;
            ad.AdUnitId = "ca-app-pub-1940490287982396/8222819865";
            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder.Build());
            base.SetNativeControl(ad);
        }
    }
}