using System;
using Xamarin.Forms.Platform.iOS;
using Radar.Controls;
using Radar.iOS;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(RadarMasterDetailPage), typeof(RadarMasterDetailPageRendereriOS))]

namespace Radar.iOS
{

	class RadarMasterDetailPageRendereriOS { /*: TabletMasterDetailPageRenderer
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
*/
	}

}
