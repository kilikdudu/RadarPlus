using System;
using Xamarin.Forms;

namespace Radar
{
	public class InstrucaoPage : ContentPage
	{
		public InstrucaoPage()
		{
			Title = "Instruções";

			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.White;
			main.Orientation = StackOrientation.Vertical;

			StackLayout topo = new StackLayout();
			topo.Orientation = StackOrientation.Vertical;
			topo.HorizontalOptions = LayoutOptions.FillAndExpand;
			topo.HeightRequest = AbsoluteLayout.AutoSize;
			topo.BackgroundColor = Color.White;
			Image icone = new Image();
			icone.Source = ImageSource.FromFile("navicon.png");
			icone.WidthRequest = 180;
			icone.HorizontalOptions = LayoutOptions.Center;

			Label nome = new Label();
			nome.Text = "Radar+";
			nome.FontSize = 40;
			nome.FontFamily = "Roboto-Condensed";
			nome.HorizontalOptions = LayoutOptions.Center;
		}
	}
}
