using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Radar.Controls;
using Radar.Utils;
using System.Diagnostics;

namespace Radar.Pages
{
    public partial class RadarListaPage : ContentPage
    {
        public RadarListaPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
			RadarBLL regraRadar = RadarFactory.create();
			RadarListView.RowHeight = 150;
			RadarListView.ItemTapped += OnTap;

			RadarListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			RadarListView.ItemTemplate = new DataTemplate(typeof(ConteudoCelula));

			var percursos = regraRadar.listar();

			//desc.VerticalOptions = LayoutOptions.Center;


			if (percursos.Count > 0)
			{
				//percursoListView.SetBinding(Label.TextProperty, new Binding("Data"));
				this.BindingContext = percursos;

			}
            
        }
		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			if (e == null)
				return;

		}
        

        public void excluirRadar(object sender, EventArgs e)
        {
            RadarInfo radar = (RadarInfo)((MenuItem)sender).BindingContext;
            RadarBLL regraRadar = RadarFactory.create();
            regraRadar.excluir(radar.Id);
            OnAppearing();
        }

		public class ConteudoCelula : ViewCell
		{
			StackLayout desc = new StackLayout();


			public ConteudoCelula()
			{
				
				MenuItem excluirRadar = new MenuItem();

				excluirRadar.CommandParameter = "{Binding .}";
				excluirRadar.Text = "Excluir";
				excluirRadar.IsDestructive = true;
				excluirRadar.Clicked += async (object sender, EventArgs e) =>
				{
					RadarInfo radar = (RadarInfo)((MenuItem)sender).BindingContext;
					RadarBLL regraRadar = RadarFactory.create();
					regraRadar.excluir(radar.Id);
					OnAppearing();
				};

				this.ContextActions.Add(excluirRadar);


				//desc.VerticalOptions = LayoutOptions.Center;
				desc.HorizontalOptions = LayoutOptions.FillAndExpand;
				desc.Orientation = StackOrientation.Horizontal;

				StackLayout main = new StackLayout()
				{
					Margin = new Thickness(5, 0, 5, 0),
					VerticalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Fill,
					WidthRequest = TelaUtils.LarguraSemPixel
				};

				Frame cardLeft = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,
					Margin = new Thickness(0, 0, 0, 0),
					WidthRequest = main.WidthRequest * 0.2

				};

				StackLayout cardLeftStack = new StackLayout()
				{
					Orientation = StackOrientation.Vertical

				};

				Image percursoIco = new Image()
				{
					Source = "meusradares.png",
					WidthRequest = cardLeft.WidthRequest / 1.5,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};


				cardLeftStack.Children.Add(percursoIco);
				cardLeft.Content = cardLeftStack;

				Frame cardRigth = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,
					WidthRequest = main.WidthRequest * 0.7

				};

				WrapLayout cardRigthStackHor = new WrapLayout()
				{
					//Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Fill,
					Spacing = 1

				};
				StackLayout cardRigthStackVer = new StackLayout()
				{
					Orientation = StackOrientation.Vertical,
					Spacing = 1

				};

				Label titulo = new Label()
				{
					Text = "31/0ut, 17:41",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					FontSize = 26,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label limite = new Label()
				{
					Text = "Limite: 60 km/h ",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label latitude = new Label()
				{ 
					Text = "Latitude: 16,73456 ",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label longitude = new Label()
				{
					Text = "Longitude: -49,23480 ",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label angulo = new Label()
				{
					Text = "Ângulo: 179.0 ",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};


				Label endereco = new Label()
				{
					Text = "Rua H-149, 1-73 Cidade Vera Cruz/ Aparecida de Goiânia ",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//VerticalOptions = LayoutOptions.StartAndExpand,
					//WidthRequest = cardRigth.WidthRequest * 0.8,
					//FontSize = 20,
					FontFamily = "Roboto-Condensed",
					//HorizontalTextAlignment = TextAlignment.Center
				};
				BoxView linha = new BoxView()
				{
					HeightRequest = 1,
					BackgroundColor = Color.FromHex(TemaInfo.DividerColor),
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				cardRigthStackVer.Children.Add(titulo);
				cardRigthStackVer.Children.Add(linha);
				cardRigthStackHor.Children.Add(limite);
				cardRigthStackHor.Children.Add(latitude);
				cardRigthStackHor.Children.Add(longitude);
				cardRigthStackHor.Children.Add(angulo);
				cardRigthStackVer.Children.Add(cardRigthStackHor);
				cardRigthStackVer.Children.Add(endereco);

				cardRigthStackVer.WidthRequest = main.WidthRequest * 0.8;
				//desc.Children.Add(cardRigthStack);

				cardRigth.Content = cardRigthStackVer;
				//if (main.WidthRequest > 320)
				//{

					main.Children.Add(cardLeft);
				//}
				main.Children.Add(cardRigth);

				View = main;
			}
		}
    }
}
