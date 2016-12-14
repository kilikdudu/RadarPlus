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
	public class ResumoPercursoPage : ContentPage
	{

		public ResumoPercursoPage()
		{
			this.Title = "Resumos Percursos";

			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;

			//GrupoBLL regraGrupo = GrupoFactory.create();
			ObservableCollection<ResumoInfo> resumo = new ObservableCollection<ResumoInfo>();
			resumo.Add(new ResumoInfo(){ Nome="Paradas", Imagem="ic_pan_tool_black_24dp.png", Items = { new ResumoItemInfo() {Descricao="Quantidade Paradas", Valor="5" } } });
			resumo.Add(new ResumoInfo(){ Nome="Radar 40", Imagem="radar_40.png" });
			resumo.Add(new ResumoInfo(){ Nome="Despesas",  Imagem="ic_monetization_on_black_24dp.png" });
			
			ListView listaResumos = new ListView();
			listaResumos.RowHeight = 200;
			listaResumos.ItemTemplate = new DataTemplate(typeof(ResumosCelula));
			listaResumos.ItemTapped += OnTap;
			listaResumos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaResumos.HasUnevenRows = true;
			listaResumos.SeparatorColor = Color.Transparent;
			listaResumos.VerticalOptions = LayoutOptions.Fill;
			listaResumos.HorizontalOptions = LayoutOptions.Center;

			//var grupos = regraGrupo.listar();
			listaResumos.BindingContext = resumo;
								
			listaView.Children.Add(listaResumos);
			
			Content = listaView;
		}

		
		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			//GrupoInfo item = (GrupoInfo)e.Item;

			//if (item.aoClicar != null)
			//{
				
					//NavegacaoUtils.PushAsync(new ColaboradorAdministracaoPage());
				
			//}

		}

		public class ResumosCelula : ViewCell
		{

			public ResumosCelula()
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
					listaColaboradores.ItemTemplate = new DataTemplate(typeof(ResumosCelula));
				};
				ContextActions.Add(excluirColaborador);

				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Vertical;
				main.VerticalOptions = LayoutOptions.Fill;
				main.HorizontalOptions = LayoutOptions.Fill;
				
							
				Image icone = new Image()
				{
					WidthRequest = 50,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					//Source = "ic_add_a_photo_48pt.png"
				};
				icone.SetBinding(Image.SourceProperty, new Binding("Imagem"));

				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Start,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Nome"));		

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
					icone.WidthRequest = 60;

					//frameOuter.Padding = new Thickness(5, 10, 5, 10);
					frameOuter.WidthRequest = TelaUtils.Largura * 0.9;
					frameOuter.Margin = new Thickness(5, 10, 5, 0);

				}
				else {
					frameOuter.Margin = new Thickness(5, 10, 5, 10);
				}
				
				var gridChild = new Grid();
				
				gridChild.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
				gridChild.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
				gridChild.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star)});
				gridChild.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star)});
				gridChild.Children.Add(icone, 0, 0);
				gridChild.Children.Add(nome, 1, 0);
				gridChild.Children.Add(administradorLabel, 0, 1);
				gridChild.Children.Add(_administrador, 1, 1);

				var gridMain = new Grid();
				
				gridMain.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
				gridMain.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
				gridMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.4, GridUnitType.Star)});
				gridMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star)});
				gridMain.Children.Add(icone, 0, 0);
				Grid.SetRowSpan (icone, 2);
				gridMain.Children.Add(nome, 1, 0);
				gridMain.Children.Add(linha, 0, 1);
				gridMain.Children.Add(gridChild, 1, 2);				

				main.Children.Add(gridMain);

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
