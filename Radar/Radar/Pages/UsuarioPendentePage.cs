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
	public class UsuarioPendentePage : ContentPage
	{
		public Label _email;
		public Switch _administrador;
		public Switch _adcionarRemoverUsuario;
		public Switch _apagarPercursoPermissao;
		public Switch _verLocalizacaoUsuario;
		public Switch _verPercursoUsuario;
		
		public UsuarioPendentePage()
		{
			Title = "Usuários Pendentes";

			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			
			ObservableCollection<ColaboradorInfo> pendente = new ObservableCollection<ColaboradorInfo>();
			pendente.Add(new ColaboradorInfo(){ Nome="Fabio", Email="fabio@dutra.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			pendente.Add(new ColaboradorInfo(){ Nome="Rodrigo", Email="Rodigro@landim.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			pendente.Add(new ColaboradorInfo(){ Nome="Carlos", Email="carlos@eduardo.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			
			ListView listaPendentes = new ListView();
			listaPendentes.RowHeight = 200;
			listaPendentes.ItemTemplate = new DataTemplate(typeof(ColaboradoresCelula));
			listaPendentes.ItemTapped += OnTap;
			listaPendentes.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaPendentes.HasUnevenRows = true;
			listaPendentes.SeparatorColor = Color.Transparent;
			listaPendentes.VerticalOptions = LayoutOptions.Fill;
			listaPendentes.HorizontalOptions = LayoutOptions.Center;

			//var grupos = regraGrupo.listar();
			listaPendentes.BindingContext = pendente;
			
			listaView.Children.Add(listaPendentes);
			
			Content = listaView;
			
			
		}

		public class ColaboradoresCelula : ViewCell
			{
			Switch _ativar;
			Switch _administrador;
			
			public ColaboradoresCelula()
			{

				var excluirColaboradorPendente = new MenuItem
				{
					Text = "Excluir"
				};

				excluirColaboradorPendente.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirColaboradorPendente.Clicked += (sender, e) =>
				{
					GrupoInfo grupo = (GrupoInfo)((MenuItem)sender).BindingContext;
					//GrupoBLL regraGrupo = GrupoFactory.create();
					//regraGrupo.excluir(grupo.Id);

					ListView listaPendentes = this.Parent as ListView;

					listaPendentes.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaPendentes.RowHeight = 120;
					//var grupos = regraGrupo.listar();
					//listaGrupos.BindingContext = grupos;
					listaPendentes.ItemTemplate = new DataTemplate(typeof(ColaboradoresCelula));
				};
				ContextActions.Add(excluirColaboradorPendente);

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
				foto.SetBinding(Image.SourceProperty, new Binding("Imagem"));
				
				Label nome = new Label
				{
					
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Start,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Nome"));

				Label emailLabel = new Label
				{
					Text = "Email:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				Label email = new Label
				{
					//Text = "fabio@dutra.com",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				email.SetBinding(Label.TextProperty, new Binding("Email"));
				
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
				
				Label ativarLabel = new Label
				{
					Text = "Ativar Cadastro:",
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				
				_ativar= new Switch
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

			
				
				stackAdministrador.Children.Add(administradorLabel);
				stackAdministrador.Children.Add(_administrador);
				
				
				var grid = new Grid();
				
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star)});
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star)});
				grid.Children.Add(ativarLabel, 0, 0);
				grid.Children.Add(_ativar, 1, 0);
				grid.Children.Add(administradorLabel, 0, 1);
				grid.Children.Add(_administrador, 1, 1);
			
				
				stackTop.Children.Add(foto);
				stackTop.Children.Add(nome);
				stackBotton.Children.Add(stackEmail);
				stackBotton.Children.Add(grid);
								

				main.Children.Add(stackTop);
				main.Children.Add(linha);
				main.Children.Add(stackBotton);

				frameOuter.Content = main;


			stackMain.Children.Add(frameOuter);
			
			View = stackMain;

			}


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
					//NavegacaoUtils.PushAsync(new ColaboradorAdministracaoPage());
				}
			//}

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
