using System;
using ClubManagement.Utils;
using Radar.Controls;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class LoginPage : ContentPage
	{
		public LoginPage()
		{
			Title = "Login";


			ScrollView scroll = new ScrollView();
			scroll.Orientation = ScrollOrientation.Vertical;
			scroll.VerticalOptions = LayoutOptions.FillAndExpand;

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
			logoStack.BackgroundColor = Color.Transparent;
			logoStack.Orientation = StackOrientation.Vertical;
			logoStack.VerticalOptions = LayoutOptions.CenterAndExpand;
			logoStack.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout emailStack = new StackLayout();
			emailStack.BackgroundColor = Color.Transparent;
			emailStack.Orientation = StackOrientation.Horizontal;
			emailStack.VerticalOptions = LayoutOptions.CenterAndExpand;
			emailStack.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout senhaStack = new StackLayout();
			senhaStack.BackgroundColor = Color.Transparent;
			senhaStack.Orientation = StackOrientation.Horizontal;
			senhaStack.VerticalOptions = LayoutOptions.CenterAndExpand;
			senhaStack.HorizontalOptions = LayoutOptions.CenterAndExpand;


			Frame cardPrincipal = new Frame()
			{
				BackgroundColor = Color.FromHex(TemaInfo.BlueAccua),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = AbsoluteLayout.AutoSize
			};

			var email = new Entry
			{
				Placeholder = "Email:",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
			    Keyboard = Keyboard.Email
			};
			EmailValidatorBehavior SecEmailValidator = new EmailValidatorBehavior();
			email.Behaviors.Add(SecEmailValidator);

			Image emailSucessImage = new Image
			{
				Source = "",
				WidthRequest = 20,
				HeightRequest = 20,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
			};
			emailSucessImage.BindingContext = SecEmailValidator;
			emailSucessImage.SetBinding(Image.SourceProperty, "ImageSource");

			Image logo = new Image()
			{
				Source = "logo.png",
				WidthRequest = 100,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 0, 0, 30)
			};

			var senha = new Entry
			{
				Placeholder = "Senha:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4
			};
			NumberValidatorBehavior SecSenhaValidator = new NumberValidatorBehavior();
			senha.Behaviors.Add(SecSenhaValidator);

			Image senhaSucessImage = new Image
			{
				Source = "",
				WidthRequest = 20,
				HeightRequest = 20,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
			};
			senhaSucessImage.BindingContext = SecSenhaValidator;
			senhaSucessImage.SetBinding(Image.SourceProperty, "ImageSource");

			Button entrar = new Button()
			{
				Text = "ENTRAR",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)

			};
			entrar.Clicked += fazerLogin;
			Button entrarFacebook = new Button()
			{
				Text = "ENTRAR COM FACEBOOK",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)

			};
			entrarFacebook.Clicked += verificaLogado;


			Button recuperarSenha = new Button()
			{
				Text = "RECUPERAR SENHA?",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)
			};

			Button novoCadastro = new Button()
			{
				Text = "CADASTRAR",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)
			};
			novoCadastro.Clicked += fazerCadastro;

			Button facebookButton = new Button()
			{
				Text = "Facebook",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			logoStack.Children.Add(logo);

			emailStack.Children.Add(email);
			emailStack.Children.Add(emailSucessImage);

			senhaStack.Children.Add(senha);
			senhaStack.Children.Add(senhaSucessImage);

			centro.Children.Add(emailStack);
			centro.Children.Add(senhaStack);
			centro.Children.Add(entrar);
			centro.Children.Add(entrarFacebook);
			centro.Children.Add(novoCadastro);
			centro.Children.Add(recuperarSenha);

			cardPrincipal.Content = centro;

			main.Children.Add(logoStack);
			main.Children.Add(cardPrincipal);

			scroll.Content = main;
			Content = scroll;


		}

		public void fazerLogin(Object sender, EventArgs e)
		{
			//Application.Current.MainPage = new NavegacaoPage();
			NavegacaoUtils.PushAsync(new NovoCustoPage());
			//((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new NovoCustoPage());
		}

		public void fazerCadastro(Object sender, EventArgs e)
		{
			NavegacaoUtils.PushAsync(new NovoCadastroPage());
			//((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new NovoCadastroPage());
		}

		public void verificaLogado(Object sender, EventArgs e)
		{
			//if (logado == true)
			//{
				NavegacaoUtils.PushAsync(new GrupoPage());
				//((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new GrupoPage());
			//}

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			//verificaLogado(true);

		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

		}
	}
}
