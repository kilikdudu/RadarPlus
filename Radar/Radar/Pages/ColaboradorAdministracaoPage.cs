using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClubManagement.Utils;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using Radar.Pages.Popup;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class ColaboradorAdministracaoPage : ContentPage
	{
		public Label _email;
		public Switch _administrador;
		public Switch _adcionarRemoverUsuario;
		public Switch _apagarPercursoPermissao;
		public Switch _verLocalizacaoUsuario;
		public Switch _verPercursoUsuario;
		
		public ColaboradorAdministracaoPage()
		{
			Title = "Permissões";

			StackLayout stackMain = new StackLayout();
			stackMain.VerticalOptions = LayoutOptions.FillAndExpand;
			stackMain.HorizontalOptions = LayoutOptions.Fill;

			StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Vertical;
				main.VerticalOptions = LayoutOptions.Fill;
				main.HorizontalOptions = LayoutOptions.Fill;
				
				StackLayout stackTop = new StackLayout();
				stackTop.Orientation = StackOrientation.Horizontal;
				stackTop.VerticalOptions = LayoutOptions.StartAndExpand;
				stackTop.HorizontalOptions = LayoutOptions.StartAndExpand;
				
				StackLayout stackBotton = new StackLayout();
				stackBotton.Orientation = StackOrientation.Vertical;
				stackBotton.VerticalOptions = LayoutOptions.StartAndExpand;
				stackBotton.HorizontalOptions = LayoutOptions.StartAndExpand;
				
				StackLayout stackEmail = new StackLayout();
				stackEmail.Orientation = StackOrientation.Horizontal;
				stackEmail.VerticalOptions = LayoutOptions.StartAndExpand;
				stackEmail.HorizontalOptions = LayoutOptions.StartAndExpand;
				
				StackLayout stackPendente = new StackLayout();
				stackPendente.Orientation = StackOrientation.Horizontal;
				stackPendente.VerticalOptions = LayoutOptions.StartAndExpand;
				stackPendente.HorizontalOptions = LayoutOptions.StartAndExpand;
				
				StackLayout stackAdministrador = new StackLayout();
				stackAdministrador.Orientation = StackOrientation.Horizontal;
				stackAdministrador.VerticalOptions = LayoutOptions.StartAndExpand;
				stackAdministrador.HorizontalOptions = LayoutOptions.StartAndExpand;
				
				
				Image foto = new Image()
				{
					WidthRequest = 50,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Source = "navicon.png"
				};
				
				Label nome = new Label
				{
					Text = "Fabio",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Start,
				};
				

				Label emailLabel = new Label
				{
					Text = "Email:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				 _email = new Label
				{
					Text = "fabio@dutra.com",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				

				Label pendenteLabel = new Label
				{
					Text = "Convite aceito:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				Label pendente = new Label
				{
					Text = "Convite aceito: ",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				pendente.SetBinding(Label.TextProperty, new Binding("Pendente"));
				
				Label administradorLabel = new Label
				{
					Text = "Administrador:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_administrador= new Switch
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				Label adicionarRemoverUsuarioLabel = new Label
				{
					Text = "Adcionar/ Remover Usuário:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_adcionarRemoverUsuario= new Switch
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				Label apagarPercursoPermissaoLabel = new Label
				{
					Text = "Apagar percurso:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_apagarPercursoPermissao= new Switch
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				Label verLocalizacaoUsuarioLabel = new Label
				{
					Text = "Ver localização do usuário:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_verLocalizacaoUsuario = new Switch
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				Label verPercursoUsuarioLabel = new Label
				{
					Text = "Ver percursos do usuário:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_verPercursoUsuario = new Switch
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				BoxView linha = new BoxView()
				{
					BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
 					HeightRequest = 0.6
				};
				
				var frameOuter = new Frame();
				frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				frameOuter.HeightRequest = AbsoluteLayout.AutoSize;
				if (Device.OS == TargetPlatform.iOS)
				{
					foto.WidthRequest = 60;

					//frameOuter.Padding = new Thickness(5, 10, 5, 10);
					frameOuter.WidthRequest = TelaUtils.Largura * 0.9;
					frameOuter.Margin = new Thickness(5, 10, 5, 0);

				}
				else {
					frameOuter.Margin = new Thickness(5, 10, 5, 10);
				}

				stackEmail.Children.Add(emailLabel);
				stackEmail.Children.Add(_email);
				
				stackAdministrador.Children.Add(administradorLabel);
				stackAdministrador.Children.Add(_administrador);
				
				
				var grid = new Grid();
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Auto)});
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star)});
				grid.Children.Add(emailLabel, 0, 0);
				grid.Children.Add(_email, 1, 0);
				grid.Children.Add(administradorLabel, 0, 1);
				grid.Children.Add(_administrador, 1, 1);
				grid.Children.Add(adicionarRemoverUsuarioLabel, 0, 2);
				grid.Children.Add(_adcionarRemoverUsuario, 1, 2);
				grid.Children.Add(apagarPercursoPermissaoLabel, 0, 3);
				grid.Children.Add(_apagarPercursoPermissao, 1, 3);
				grid.Children.Add(verLocalizacaoUsuarioLabel, 0, 4);
				grid.Children.Add(_verLocalizacaoUsuario, 1, 4);
				grid.Children.Add(verPercursoUsuarioLabel, 0, 5);
				grid.Children.Add(_verPercursoUsuario, 1, 5);
				
				stackTop.Children.Add(foto);
				stackTop.Children.Add(nome);
				stackBotton.Children.Add(stackEmail);
				stackBotton.Children.Add(grid);
								

				main.Children.Add(stackTop);
				main.Children.Add(linha);
				main.Children.Add(stackBotton);

				frameOuter.Content = main;


			stackMain.Children.Add(frameOuter);
			
			Content = stackMain;
		}

		public void convidarUsuario()
		{
			NavigationX.create(this).PushPopupAsyncX(new ConviteUsuarioPopUp());
		
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			GrupoInfo item = (GrupoInfo)e.Item;

			//if (item.aoClicar != null)
			//{
				if (this.Navigation.NavigationStack.Count == 1)
				{
					NavegacaoUtils.PushAsync(new ColaboradorAdministracaoPage());
				}
			//}

		}

		public class ColaboradoresCelula : ViewCell
		{

		

				

		


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
