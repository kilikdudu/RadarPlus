using System;
using Xamarin.Forms.Platform.Android;
using Radar.Controls;
using Radar.Droid;
using Radar.Pages;
using Xamarin.Forms;
using Android.Content;
using Android.App;

//[assembly: Xamarin.Forms.ExportRenderer(typeof(RadarMasterDetailPage), typeof(RadarMasterDetailRenderer))]

public class RadarMasterDetailRenderer : MasterDetailRenderer
{
    MasterDetailPage _page;

    public new void SetElement(VisualElement element) {
        try
        {
            base.SetElement(element);
        }
        catch (Exception e) {
        }
    }

    protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
    {
        base.OnElementChanged(oldElement, newElement);
        if (oldElement == null)
        {
            Context context = Android.App.Application.Context;
            var actionBar = ((Activity)context).ActionBar;
            actionBar.Hide();

        }
        if (newElement != null)
        {
            _page = (MasterDetailPage)newElement;
        }
    }

	bool firstDone;

    /*
	public override void AddView(Android.Views.View child)
	{
        if (child == null)
            return;
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
    */
}
