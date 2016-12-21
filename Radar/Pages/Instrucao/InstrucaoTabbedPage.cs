using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Radar
{
	public class InstrucaoTabbedPage : ContentPage
	{
		public InstrucaoTabbedPage()
		{
			AbsoluteLayout ab = new AbsoluteLayout();

			ab.Children.Add(new vieww());

			
		}
	}
	public class vieww : View
	{
		public vieww()
		{
			new InstrucaoTabbedPageTab();
		}

	}
	public class InstrucaoTabbedPageTab : TabbedPage
	{
		public InstrucaoTabbedPageTab()
		{

			
			this.Children.Add(new LoginPage());
			this.Children.Add(new SobrePage());
			
		}

	}
}
