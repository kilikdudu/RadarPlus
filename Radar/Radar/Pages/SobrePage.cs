using System;
using Radar.BLL;
using Xamarin.Forms;

namespace Radar
{
	public class SobrePage : ContentPage
	{
		public SobrePage()
		{
			
			Title = "Sobre";

			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.White;
			main.Orientation = StackOrientation.Vertical;

			StackLayout topo = new StackLayout();
			topo.Orientation = StackOrientation.Vertical;
			topo.HorizontalOptions = LayoutOptions.FillAndExpand;
			topo.HeightRequest = AbsoluteLayout.AutoSize;
			topo.BackgroundColor = Color.White;
			Image icone = new Image();
			icone.Source = "navicon.png";
			icone.WidthRequest = 180;
			icone.HorizontalOptions = LayoutOptions.Center;

			Label nome = new Label();
			nome.Text = "Radar+";
			nome.FontSize = 40;
			nome.FontFamily = "Roboto-Condensed";
			nome.HorizontalOptions = LayoutOptions.Center;

			Label versao = new Label();
			versao.Text = "Versão: 1.0.0";
			versao.FontSize = 25;
			versao.FontFamily = "Roboto-Condensed";
			versao.HorizontalOptions = LayoutOptions.Center;

			StackLayout rodape = new StackLayout();
			rodape.Orientation = StackOrientation.Vertical;
			rodape.HorizontalOptions = LayoutOptions.Fill;
			rodape.VerticalOptions = LayoutOptions.Center;

			Label desenvolidoPor = new Label();
			desenvolidoPor.Text = "Desenvolvido Por";
			desenvolidoPor.HorizontalOptions = LayoutOptions.Center;
			Image logo = new Image();
			logo.Source = "logoclubmanagement.png";
			logo.WidthRequest = 200;

			AbsoluteLayout.SetLayoutBounds(topo, new Rectangle(0, 0, 1, 0.9));
			AbsoluteLayout.SetLayoutFlags(topo, AbsoluteLayoutFlags.All);
			topo.Children.Add(icone);
			topo.Children.Add(nome);
			topo.Children.Add(versao);
			rodape.Children.Add(desenvolidoPor);
			rodape.Children.Add(logo);

			main.Children.Add(topo);
			main.Children.Add(rodape);

			Content = main;

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

		}
	}
}
