using System;
using ClubManagement.Utils;
using Plugin.Media;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Radar
{
	public class ConviteUsuarioPopUp : PopupPage
	{
		Entry _email;
		double _width;

		public ConviteUsuarioPopUp()
		{
			Title = "Enviar Email";

			if (TelaUtils.Orientacao == "Landscape")
			{
				_width = (int)TelaUtils.LarguraSemPixel * 0.3;
			}
			else {
				_width = (int)TelaUtils.LarguraSemPixel * 0.4;
			}

			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.CenterAndExpand;
			main.HorizontalOptions = LayoutOptions.CenterAndExpand;


			StackLayout mainFrame = new StackLayout();
			mainFrame.BackgroundColor = Color.Transparent;
			mainFrame.Orientation = StackOrientation.Vertical;
			mainFrame.VerticalOptions = LayoutOptions.CenterAndExpand;
			mainFrame.HorizontalOptions = LayoutOptions.CenterAndExpand;


			Frame cardPrincipal = new Frame()
			{
				BackgroundColor = Color.FromHex(TemaInfo.BlueAccua),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = AbsoluteLayout.AutoSize
			};


			Label nomeLabel = new Label
			{
				Text = "Digite o email para o convidar um novo usuário.",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				WidthRequest = _width,
			};

			_email = new Entry
			{
				Placeholder = "Digite o email:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};


			StackLayout stackButtons = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
			};

			Button confirmar = new Button()
			{
				Text = "Confirmar",
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontFamily = "Roboto-Condensed",
				BackgroundColor = Color.Transparent,
				FontSize = 20
			};

			confirmar.Clicked += enviarEmail;

			Button cancelar = new Button()
			{
				Text = "Cancelar",
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontFamily = "Roboto-Condensed",
				BackgroundColor = Color.Transparent,
				FontSize = 20
			};
			cancelar.Clicked += OnCancelar;

			stackButtons.Children.Add(cancelar);
			stackButtons.Children.Add(confirmar);


			main.Children.Add(nomeLabel);
			main.Children.Add(_email);
			main.Children.Add(stackButtons);

			cardPrincipal.Content = main;

			mainFrame.Children.Add(cardPrincipal);
			Content = mainFrame;

		}

		private void OnCancelar(object sender, EventArgs e)
		{
			PopupNavigation.PopAsync();
		}

		private void enviarEmail(object sender, EventArgs e)
		{
			MensagemUtils.avisar("Email enviado com sucesso!");
			PopupNavigation.PopAsync();
		}


	}
}

