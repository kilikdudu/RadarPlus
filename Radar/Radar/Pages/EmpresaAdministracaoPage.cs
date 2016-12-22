using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClubManagement.Utils;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using Radar.Pages;
using Radar.Pages.Popup;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class EmpresaAdministracaoPage : ContentPage
	{

		public EmpresaAdministracaoPage()
		{
			Title = "Administração";

			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			
			ObservableCollection<EmpresaInfo> empresa = new ObservableCollection<EmpresaInfo>();
			empresa.Add(new EmpresaInfo(){ Nome="Compradores", Descricao="Empresa x", Imagem="navicon.png"});
			empresa.Add(new EmpresaInfo(){ Nome="Vendedores", Descricao="Empresa Y", Imagem="navicon.png"});
			empresa.Add(new EmpresaInfo(){ Nome="Entregadores", Descricao="Empresa z", Imagem="navicon.png"});
			
			ListView listaEmpresaAdministracao = new ListView();
			//listaGrupos.RowHeight = 120;
			listaEmpresaAdministracao.ItemTemplate = new DataTemplate(typeof(EmpresaCelula));
			listaEmpresaAdministracao.ItemTapped += OnTap;
			listaEmpresaAdministracao.ItemsSource = empresa;
			listaEmpresaAdministracao.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaEmpresaAdministracao.HasUnevenRows = true;
			listaEmpresaAdministracao.SeparatorColor = Color.Transparent;
			listaEmpresaAdministracao.VerticalOptions = LayoutOptions.Start;
			listaEmpresaAdministracao.HorizontalOptions = LayoutOptions.Center;
			AbsoluteLayout.SetLayoutBounds(listaEmpresaAdministracao, new Rectangle(0, 0, 1, 1));
			AbsoluteLayout.SetLayoutFlags(listaEmpresaAdministracao, AbsoluteLayoutFlags.All);
			
			listaEmpresaAdministracao.BindingContext = empresa;
			
			listaView.Children.Add(listaEmpresaAdministracao);
			//listaView.Children.Add(AdicionarRadarButton);
			Content = listaView;
		}

		public void adcionarGrupo()
		{
			NavigationX.create(this).PushModalAsync(new AdcionarEmpresaPopUp());
		
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			EmpresaInfo item = (EmpresaInfo)e.Item;

			NavigationX.create(this).PushModalAsync(new AdcionarEmpresaPopUp(item));	
			
		}

		public class EmpresaCelula : ViewCell
		{

			public EmpresaCelula()
			{

				var excluirEmpresa = new MenuItem
				{
					Text = "Excluir"
				};

				excluirEmpresa.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirEmpresa.Clicked += (sender, e) =>
				{
					//GrupoInfo grupo = (GrupoInfo)((MenuItem)sender).BindingContext;
					//GrupoBLL regraGrupo = GrupoFactory.create();
					//regraGrupo.excluir(grupo.Id);

					ListView listaGrupos = this.Parent as ListView;

					listaGrupos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaGrupos.HasUnevenRows = true;
					//var grupos = regraGrupo.listar();
					//listaGrupos.BindingContext = grupos;
					listaGrupos.ItemTemplate = new DataTemplate(typeof(EmpresaCelula));
				};
				ContextActions.Add(excluirEmpresa);

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
				frameOuter.HeightRequest = AbsoluteLayout.AutoSize;
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
