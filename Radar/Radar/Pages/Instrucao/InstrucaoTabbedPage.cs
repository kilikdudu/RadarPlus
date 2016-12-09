using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Radar
{
	public class InstrucaoTabbedPage : TabbedPage
	{
		public InstrucaoTabbedPage()
		{
			this.Children.Add(new LoginPage());
			this.Children.Add(new SobrePage());
		}
	}
}
