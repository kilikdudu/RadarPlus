using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.Pages;
using Xamarin.Forms;
using System;
using Radar.Model;

namespace Radar.Controls
{
	public class RadarMasterDetailPage : MasterDetailPage
	{
		public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create<RadarMasterDetailPage, int>(p => p.DrawerWidth, default(int));

		public int DrawerWidth
		{
			get {
                return (int)GetValue(DrawerWidthProperty);
            }
			set {
                SetValue(DrawerWidthProperty, value);
            }
		}
	}
}