﻿using System;
using ClubManagement.Utils;
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
	public class CustoMenuPopUp : PopupPage
	{
		public CustoMenuPopUp()
		{
			ScrollView scrollMain = new ScrollView();
			scrollMain.Orientation = ScrollOrientation.Vertical;
			scrollMain.VerticalOptions = LayoutOptions.FillAndExpand;

			this.BackgroundColor = Color.Transparent;
			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.EndAndExpand;
			main.HorizontalOptions = LayoutOptions.EndAndExpand;
			main.Margin = new Thickness(0, 0, 0, (int)TelaUtils.Altura * 0.25);

			StackLayout stackOpcoes = new StackLayout();
			stackOpcoes.BackgroundColor = Color.Transparent;
			stackOpcoes.Orientation = StackOrientation.Vertical;
			stackOpcoes.VerticalOptions = LayoutOptions.CenterAndExpand;
			stackOpcoes.HorizontalOptions = LayoutOptions.CenterAndExpand;

			Frame cardPrincipal = new Frame()
			{
				BackgroundColor = Color.FromHex(TemaInfo.BlueAccua),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = AbsoluteLayout.AutoSize
			};

			Button radar = new Button()
			{
				Text = "RADAR",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.3,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)

			};
			radar.Clicked += cadastrarRadar;

			Button custo = new Button()
			{
				Text = "CUSTO",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.3,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				TextColor = Color.FromHex(TemaInfo.TextIcons)

			};
			custo.Clicked += abrirCusto;

			stackOpcoes.Children.Add(radar);
			stackOpcoes.Children.Add(custo);

			cardPrincipal.Content = stackOpcoes;
			main.Children.Add(cardPrincipal);

			scrollMain.Content = main;
			Content = scrollMain;

		}

		public virtual void  cadastrarRadar(Object sender, EventArgs e)
		{
			if (InternetUtils.estarConectado())
			{
				LocalizacaoInfo local = GPSUtils.UltimaLocalizacao;
				float latitude = (float)local.Latitude;
				float longitude = (float)local.Longitude;
				GeocoderUtils.pegarAsync(latitude, longitude, (send, ev) =>
				{
					var endereco = ev.Endereco;
					ClubManagement.Utils.MensagemUtils.avisar(endereco.Logradouro);
				});
			}
			try
			{
				LocalizacaoInfo local = GPSUtils.UltimaLocalizacao;
				if (local != null)
				{
					RadarBLL regraRadar = RadarFactory.create();
					regraRadar.gravar(local, false);
					MensagemUtils.avisar("Radar incluído com sucesso.");
				}
				else
					MensagemUtils.avisar("Nenhum movimento registrado pelo GPS.");
			}
			catch (Exception e2)
			{
				MensagemUtils.avisar(e2.Message);
			}

		}

		public void abrirCusto(Object sender, EventArgs e)
		{
			((MasterDetailPage)Application.Current.MainPage).Detail =  new NavigationPage(new NovoCustoPage());
			PopupNavigation.PopAsync();
			//Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new NovoCustoPage());
			//NavigationX.create(this).PushModalAsync(new NovoCustoPage());

		}
	}
}

