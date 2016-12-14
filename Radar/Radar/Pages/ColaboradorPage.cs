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
	public class ColaboradorPage : ContentPage
	{

		public ColaboradorPage()
		{
			this.Title = "Colaboradores";

			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;

			//GrupoBLL regraGrupo = GrupoFactory.create();
			ObservableCollection<ColaboradorInfo> colaborador = new ObservableCollection<ColaboradorInfo>();
			colaborador.Add(new ColaboradorInfo(){ Nome="Fabio", Email="fabio@dutra.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			colaborador.Add(new ColaboradorInfo(){ Nome="Rodrigo", Email="Rodigro@landim.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			colaborador.Add(new ColaboradorInfo(){ Nome="Carlos", Email="carlos@eduardo.com", Imagem="navicon.png", Pendente="Sim", Administrador="Sim"});
			
			ListView listaColaboradores = new ListView();
			listaColaboradores.RowHeight = 200;
			listaColaboradores.ItemTemplate = new DataTemplate(typeof(ColaboradoresCelula));
			listaColaboradores.ItemTapped += OnTap;
			listaColaboradores.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaColaboradores.HasUnevenRows = true;
			listaColaboradores.SeparatorColor = Color.Transparent;
			listaColaboradores.VerticalOptions = LayoutOptions.Fill;
			listaColaboradores.HorizontalOptions = LayoutOptions.Center;

			//var grupos = regraGrupo.listar();
			listaColaboradores.BindingContext = colaborador;
			Image AdicionarRadarButton = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("mais.png"),
				WidthRequest = 180,
				HeightRequest = 180,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
				Margin = new Thickness(0,0 , 10, 10)
			};
			AdicionarRadarButton.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
						convidarUsuario();
						}
					)
					});

			AbsoluteLayout.SetLayoutBounds(AdicionarRadarButton, new Rectangle(0.93, 0.975, 0.2, 0.2));
			AbsoluteLayout.SetLayoutFlags(AdicionarRadarButton, AbsoluteLayoutFlags.All);
			
			listaView.Children.Add(listaColaboradores);
			listaView.Children.Add(AdicionarRadarButton);
			Content = listaView;
		}

		public void convidarUsuario()
		{
			NavigationX.create(this).PushPopupAsyncX(new ConviteUsuarioPopUp());
		
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			//GrupoInfo item = (GrupoInfo)e.Item;

			//if (item.aoClicar != null)
			//{
				
					NavegacaoUtils.PushAsync(new ColaboradorAdministracaoPage());
				
			//}

		}

		public class ColaboradoresCelula : ViewCell
		{

			public ColaboradoresCelula()
			{

				var excluirColaborador = new MenuItem
				{
					Text = "Excluir"
				};

				excluirColaborador.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirColaborador.Clicked += (sender, e) =>
				{
					GrupoInfo grupo = (GrupoInfo)((MenuItem)sender).BindingContext;
					//GrupoBLL regraGrupo = GrupoFactory.create();
					//regraGrupo.excluir(grupo.Id);

					ListView listaColaboradores = this.Parent as ListView;

					listaColaboradores.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaColaboradores.RowHeight = 120;
					//var grupos = regraGrupo.listar();
					//listaGrupos.BindingContext = grupos;
					listaColaboradores.ItemTemplate = new DataTemplate(typeof(ColaboradoresCelula));
				};
				ContextActions.Add(excluirColaborador);

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
					//Source = "ic_add_a_photo_48pt.png"
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
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				email.SetBinding(Label.TextProperty, new Binding("Email"));

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
				Label administrador = new Label
				{
					TextColor = Color.FromHex(TemaInfo.AdminColor),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};
				administrador.SetBinding(Label.TextProperty, new Binding("Administrador"));

				BoxView linha = new BoxView()
				{
					BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
 					HeightRequest = 0.61
				};
				
				var frameOuter = new Frame();
				frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				frameOuter.HeightRequest = 120;
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
				stackEmail.Children.Add(email);
				stackPendente.Children.Add(pendenteLabel);
				stackPendente.Children.Add(pendente);
				stackAdministrador.Children.Add(administradorLabel);
				stackAdministrador.Children.Add(administrador);
				
				stackTop.Children.Add(foto);
				stackTop.Children.Add(nome);
				stackBotton.Children.Add(stackEmail);
				stackBotton.Children.Add(stackPendente);
				stackBotton.Children.Add(stackAdministrador);				

				main.Children.Add(stackTop);
				main.Children.Add(linha);
				main.Children.Add(stackBotton);

				frameOuter.Content = main;

				View = frameOuter;

			}


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
