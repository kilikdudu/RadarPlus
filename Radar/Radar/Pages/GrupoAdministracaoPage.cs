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
	public class GrupoAdministracaoPage : ContentPage
	{

		public GrupoAdministracaoPage()
		{
			Title = "Administração";

			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			
			ObservableCollection<GrupoInfo> grupo = new ObservableCollection<GrupoInfo>();
			grupo.Add(new GrupoInfo(){ Nome="Compradores", Descricao="Grupo dos compradores da empresa", Imagem="navicon.png"});
			grupo.Add(new GrupoInfo(){ Nome="Vendedores", Descricao="Grupo dos vendedores da empresa", Imagem="navicon.png"});
			grupo.Add(new GrupoInfo(){ Nome="Entregadores", Descricao="Grupo dos entregadores da empresa", Imagem="navicon.png"});
			
			ListView listaGrupos = new ListView();
			listaGrupos.RowHeight = 120;
			listaGrupos.ItemTemplate = new DataTemplate(typeof(GruposCelula));
			listaGrupos.ItemTapped += OnTap;
			listaGrupos.ItemsSource = grupo;
			listaGrupos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaGrupos.HasUnevenRows = true;
			listaGrupos.SeparatorColor = Color.Transparent;
			listaGrupos.VerticalOptions = LayoutOptions.Start;
			listaGrupos.HorizontalOptions = LayoutOptions.Center;

			listaGrupos.BindingContext = grupo;
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
						adcionarGrupo();
						}
					)
					});

			AbsoluteLayout.SetLayoutBounds(AdicionarRadarButton, new Rectangle(0.93, 0.975, 0.2, 0.2));
			AbsoluteLayout.SetLayoutFlags(AdicionarRadarButton, AbsoluteLayoutFlags.All);
			listaView.Children.Add(listaGrupos);
			//listaView.Children.Add(AdicionarRadarButton);
			Content = listaView;
		}

		public void adcionarGrupo()
		{
			NavigationX.create(this).PushModalAsync(new AdcionarGrupoPopUp());
		
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			GrupoInfo item = (GrupoInfo)e.Item;
	
					NavigationX.create(this).PushModalAsync(new AdcionarGrupoPopUp(item));	

		}

		public class GruposCelula : ViewCell
		{

			public GruposCelula()
			{

				var excluirGrupo = new MenuItem
				{
					Text = "Excluir"
				};

				excluirGrupo.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirGrupo.Clicked += (sender, e) =>
				{
					//GrupoInfo grupo = (GrupoInfo)((MenuItem)sender).BindingContext;
					//GrupoBLL regraGrupo = GrupoFactory.create();
					//regraGrupo.excluir(grupo.Id);

					ListView listaGrupos = this.Parent as ListView;

					listaGrupos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaGrupos.RowHeight = 120;
					//var grupos = regraGrupo.listar();
					//listaGrupos.BindingContext = grupos;
					listaGrupos.ItemTemplate = new DataTemplate(typeof(GruposCelula));
				};
				ContextActions.Add(excluirGrupo);

				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Horizontal;
				main.VerticalOptions = LayoutOptions.CenterAndExpand;
				main.HorizontalOptions = LayoutOptions.StartAndExpand;

				StackLayout stackRight = new StackLayout();
				stackRight.Orientation = StackOrientation.Vertical;
				stackRight.VerticalOptions = LayoutOptions.CenterAndExpand;
				stackRight.HorizontalOptions = LayoutOptions.StartAndExpand;

				StackLayout stackLeft = new StackLayout();
				stackLeft.Orientation = StackOrientation.Vertical;
				stackLeft.VerticalOptions = LayoutOptions.CenterAndExpand;
				stackLeft.HorizontalOptions = LayoutOptions.StartAndExpand;


				Image foto = new Image()
				{
					WidthRequest = 50,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					//Source = "ic_add_a_photo_48pt.png"
				};
				foto.SetBinding(Image.SourceProperty, new Binding("Imagem"));

				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Nome"));


				Label descricao = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				descricao.SetBinding(Label.TextProperty, new Binding("Descricao"));

		
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

				stackLeft.Children.Add(foto);
				stackRight.Children.Add(nome);
				stackRight.Children.Add(descricao);

				main.Children.Add(stackLeft);
				main.Children.Add(stackRight);

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
