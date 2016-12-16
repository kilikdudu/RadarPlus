using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
		int _count = 0;
		StackLayout _main;
		ObservableCollection<ResumoInfo> _resumo;
		BoxView _linha;
		public ResumoPercursoPage(PercursoInfo percursoinfo)
		{
			var percurso = percursoinfo;
			this.Title = "Resumo do percurso";
			
			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			listaView.BackgroundColor = Color.Transparent;

			//GrupoBLL regraGrupo = GrupoFactory.create();
			_resumo = new ObservableCollection<ResumoInfo>();
			ObservableCollection<ResumoItemInfo> resumoParada = new ObservableCollection<ResumoItemInfo>();

			resumoParada.Add(new ResumoItemInfo() { Descricao = "Latitude", Valor = "-10.897765" });
			resumoParada.Add(new ResumoItemInfo() { Descricao = "Longitude", Valor = "-15.447853" });
			resumoParada.Add(new ResumoItemInfo() { Descricao = "Data", Valor = "10 / DEZ" });
			resumoParada.Add(new ResumoItemInfo() { Descricao = "Tempo", Valor = "00:30:55" });
			
			ObservableCollection<ResumoItemInfo> resumoRadar = new ObservableCollection<ResumoItemInfo>();

			resumoRadar.Add(new ResumoItemInfo() { Descricao = "Latitude", Valor = "-10.897765" });
			resumoRadar.Add(new ResumoItemInfo() { Descricao = "Longitude", Valor = "-15.447853" });
			resumoRadar.Add(new ResumoItemInfo() { Descricao = "Data", Valor = "10 / DEZ" });
			resumoRadar.Add(new ResumoItemInfo() { Descricao = "Velocidade", Valor = "40 Km/h" });
			
			ObservableCollection<ResumoItemInfo> resumoDespesas = new ObservableCollection<ResumoItemInfo>();

			resumoDespesas.Add(new ResumoItemInfo() { Descricao = "Latitude", Valor = "-10.897765" });
			resumoDespesas.Add(new ResumoItemInfo() { Descricao = "Longitude", Valor = "-15.447853" });
			resumoDespesas.Add(new ResumoItemInfo() { Descricao = "Data", Valor = "10 / DEZ" });
			resumoDespesas.Add(new ResumoItemInfo() { Descricao = "Valor", Valor = "120.00 R$" });
			
			ObservableCollection<ResumoItemInfo> resumoPoliciaRodoviaria = new ObservableCollection<ResumoItemInfo>();

			resumoPoliciaRodoviaria.Add(new ResumoItemInfo() { Descricao = "Latitude", Valor = "-10.897765" });
			resumoPoliciaRodoviaria.Add(new ResumoItemInfo() { Descricao = "Longitude", Valor = "-15.447853" });
			resumoPoliciaRodoviaria.Add(new ResumoItemInfo() { Descricao = "Data", Valor = "10 / DEZ" });
			
			_resumo.Add(new ResumoInfo() { Nome = "Radar", Imagem = "radar_40.png",Items = resumoRadar });
			_resumo.Add(new ResumoInfo()
			{
				Nome = "Paradas",
				Imagem = "ic_pan_tool_black_24dp.png",
				Items = resumoParada
			});
			_resumo.Add(new ResumoInfo() { Nome = "Despesas", Imagem = "ic_monetization_on_black_24dp.png",Items = resumoDespesas });
			_resumo.Add(new ResumoInfo() { Nome = "Polícia Rodoviária", Imagem = "policiarodoviaria.png",Items = resumoPoliciaRodoviaria });
			_resumo.Add(new ResumoInfo() { Nome = "Despesas", Imagem = "ic_monetization_on_black_24dp.png",Items = resumoDespesas });
		
			ListView listaResumos = new ListView();
			//listaResumos.RowHeight = 200;
			listaResumos.ItemTemplate = new DataTemplate(celulaResumo);
        
			listaResumos.ItemTapped += OnTap;
			listaResumos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaResumos.HasUnevenRows = true;
			listaResumos.SeparatorColor = Color.Transparent;
			//listaResumos.VerticalOptions = LayoutOptions.FillAndExpand;
			//listaResumos.HorizontalOptions = LayoutOptions.Center;
			 AbsoluteLayout.SetLayoutBounds(listaResumos, new Rectangle(0, 0, 1 , 1));
			 AbsoluteLayout.SetLayoutFlags(listaResumos, AbsoluteLayoutFlags.All);
			//var grupos = regraGrupo.listar();
			listaResumos.BindingContext = _resumo;

			listaView.Children.Add(listaResumos);

			Content = listaView;
		}

		public ViewCell celulaResumo()
		{
			var cell = new ViewCell();
             
            _main = new StackLayout();
            
			_main.BackgroundColor = Color.Transparent;
			_main.Orientation = StackOrientation.Vertical;
			_main.VerticalOptions = LayoutOptions.Fill;
			_main.HorizontalOptions = LayoutOptions.Fill;
			
			var frameOuter = new Frame();
			frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
			frameOuter.HeightRequest = AbsoluteLayout.AutoSize;

			var gridMain = new Grid();

			gridMain.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.4, GridUnitType.Star) });
			gridMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
			gridMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.8, GridUnitType.Star) });
			
			var gridChild = new Grid();

			gridChild.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			gridChild.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star) });
			gridChild.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.65, GridUnitType.Star) });


           
           // for (int i = 0; i < _resumo.Count; i++)
           // {
                      
				Image icone = new Image()
				{
					HeightRequest = 60,
					WidthRequest = 60,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					//Source = "ic_add_a_photo_48pt.png"
				};
				 
				icone.SetBinding(Image.SourceProperty, new Binding("Imagem"));
	
				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryColor),
					FontFamily = "Roboto-Condensed",
					FontSize = 28,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Nome"));
				
				_linha = new BoxView()
				{
					BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
					HeightRequest = 0.6
				};

			
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
			
				gridMain.Children.Add(icone, 0, 0);
				gridMain.Children.Add(nome, 1, 0);

				int itemPosicao = 0;
				foreach(var item in _resumo[_count].Items){
					Label DescricaoItem = new Label
					{
						TextColor = Color.FromHex(TemaInfo.PrimaryText),
						FontFamily = "Roboto-Condensed",
						FontSize = 20,
						HorizontalOptions = LayoutOptions.Start,
						VerticalOptions = LayoutOptions.Start,
					};
					DescricaoItem.SetBinding(Label.TextProperty, new Binding("Items[" + itemPosicao.ToString() + "].Descricao"));

					Label ValorItem = new Label
					{
						TextColor = Color.FromHex(TemaInfo.PrimaryText),
						FontFamily = "Roboto-Condensed",
						FontSize = 20,
						HorizontalOptions = LayoutOptions.Start,
						VerticalOptions = LayoutOptions.Start,
					};
					ValorItem.SetBinding(Label.TextProperty, new Binding("Items[" + itemPosicao.ToString() + "].Valor"));
					
					gridChild.Children.Add(DescricaoItem, 0, itemPosicao);
					gridChild.Children.Add(ValorItem, 1, itemPosicao);
					itemPosicao++;
				}
			
				_count++;
            //}
			
            _main.Children.Add(gridMain);
            _main.Children.Add(_linha);
            _main.Children.Add(gridChild);
			frameOuter.Content = _main;
            cell.View = frameOuter;
            return cell;
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			//GrupoInfo item = (GrupoInfo)e.Item;

			//if (item.aoClicar != null)
			//{

			//NavegacaoUtils.PushAsync(new ColaboradorAdministracaoPage());

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
