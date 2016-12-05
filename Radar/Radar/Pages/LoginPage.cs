using System;
using Radar.Controls;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class LoginPage : ContentPage
	{
		public LoginPage()
		{
			Title = "Login";

			StackLayout centro = new StackLayout();
			centro.BackgroundColor = Color.Transparent;
			centro.Orientation = StackOrientation.Vertical;
			centro.VerticalOptions = LayoutOptions.CenterAndExpand;
			centro.HorizontalOptions = LayoutOptions.CenterAndExpand;

			var email = new Entry
			{
				Placeholder = "Email",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.6
			};
			email.Behaviors.Add(new EmailValidatorBehavior());

			var senha = new Entry
			{
				Placeholder = "Senha",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.6
			};

			Button enviar = new Button(){
				Text = "Enviar",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};


			centro.Children.Add(email);
			centro.Children.Add(senha);
			centro.Children.Add(enviar);

			enviar.GestureRecognizers.Add(
				   new TapGestureRecognizer()
				   {
					   Command = new Command(() =>
					   {
						  

					   }
				   )
				   });
			Content = centro;
		}


	}
}
