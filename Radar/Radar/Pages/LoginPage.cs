using System;
using Radar.Controls;
using Radar.Model;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class LoginPage : ContentPage
	{
		public LoginPage()
		{
			Title = "Login";


			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.CenterAndExpand;
			main.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout centro = new StackLayout();
			centro.BackgroundColor = Color.Transparent;
			centro.Orientation = StackOrientation.Vertical;
			centro.VerticalOptions = LayoutOptions.CenterAndExpand;
			centro.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout logoStack = new StackLayout();
			centro.BackgroundColor = Color.Transparent;
			centro.Orientation = StackOrientation.Vertical;
			centro.VerticalOptions = LayoutOptions.CenterAndExpand;
			centro.HorizontalOptions = LayoutOptions.CenterAndExpand;


			Frame cardPrincipal = new Frame(){
			BackgroundColor = Color.FromHex(TemaInfo.BlueAccua),
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			HeightRequest = AbsoluteLayout.AutoSize
			};

			var email = new Entry
			{
				Placeholder = "Email:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4
			};
			email.Behaviors.Add(new EmailValidatorBehavior());

			Image logo = new Image()
			{
				Source = "logo.png",
				WidthRequest = 100,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Margin = new Thickness(0,0,0,30)
			};

			var senha = new Entry
			{
				Placeholder = "Senha:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4
			};

			Button enviar = new Button(){
				Text = "ENTRAR",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			Button recuperarSenha = new Button(){
				Text = "RECUPERAR SENHA?",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			Button novoCadastro = new Button(){
				Text = "CADASTRAR",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			Button facebookButton = new Button(){
				Text = "Facebook",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			logoStack.Children.Add(logo);

			centro.Children.Add(email);
			centro.Children.Add(senha);
			centro.Children.Add(enviar);
			centro.Children.Add(novoCadastro);
			centro.Children.Add(recuperarSenha);

			cardPrincipal.Content = centro;

			main.Children.Add(logoStack);
			main.Children.Add(cardPrincipal);

			enviar.GestureRecognizers.Add(
				   new TapGestureRecognizer()
				   {
					   Command = new Command(() =>
					   {
						  

					   }
				   )
				   });

			Content = main;
		}


	}
}
