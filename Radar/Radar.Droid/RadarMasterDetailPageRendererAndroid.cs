using System;
using Xamarin.Forms.Platform.Android;
using Radar.Controls;
using Radar.Droid;
using Android.Views;

[assembly: Xamarin.Forms.ExportRenderer(typeof(RadarMasterDetailPage), typeof(RadarMasterDetailPageRendererAndroid))]

public class RadarMasterDetailPageRendererAndroid : MasterDetailRenderer
{
	bool firstDone;
	public override void AddView(View child)
	{
		if (firstDone)
		{
			RadarMasterDetailPage page = (RadarMasterDetailPage)this.Element;
			LayoutParams p = (LayoutParams)child.LayoutParameters;
			p.Width = page.DrawerWidth;
			base.AddView(child, p);
		}
		else
		{
			firstDone = true;
			base.AddView(child);
		}
	}

}
