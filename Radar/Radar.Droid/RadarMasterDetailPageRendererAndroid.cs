using System;
using Xamarin.Forms.Platform.Android;
using Radar.Controls;
using Radar.Droid;


[assembly: Xamarin.Forms.ExportRenderer(typeof(RadarMasterDetailPage), typeof(RadarMasterDetailPageRendererAndroid))]

public class RadarMasterDetailPageRendererAndroid : MasterDetailRenderer
{
	bool firstDone;
	public override void AddView(Android.Views.View child)
	{
		
			RadarMasterDetailPage page = (RadarMasterDetailPage)this.Element;
			LayoutParams p = (LayoutParams)child.LayoutParameters;
			p.Width = page.DrawerWidth;
			base.AddView(child, p);
		
	}

}
