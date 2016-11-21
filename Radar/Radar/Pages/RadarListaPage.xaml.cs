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

            RadarListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			RadarListView.ItemTemplate = new DataTemplate(typeof(ConteudoCelula));
            this.BindingContext = regraRadar.listar(true);
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;

            //Navigation.PushAsync(new ImovelForm((ImovelDTO)((ListView)sender).SelectedItem));
            //((ListView)sender).SelectedItem = null; // de-select the row
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
			WrapLayout desc = new WrapLayout();


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
				desc.HorizontalOptions = LayoutOptions.Fill;
				desc.Spacing = 1;

				StackLayout main = new StackLayout()
				{
					Margin = new Thickness(5, 0, 5, 0),
					VerticalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Fill
				};

				Frame cardLeft = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,
					Margin = new Thickness(0, 0, 0, 100),
					WidthRequest = TelaUtils.LarguraSemPixel * 0.2

				};

				StackLayout cardLeftStack = new StackLayout()
				{
					Orientation = StackOrientation.Vertical

				};

				Image percursoIco = new Image()
				{
					Source = "meusradares.png",
					WidthRequest = 50,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};


				cardLeftStack.Children.Add(percursoIco);
				cardLeft.Content = cardLeftStack;

				Frame cardRigth = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,

					WidthRequest = TelaUtils.LarguraSemPixel * 0.65

				};

				StackLayout cardRigthStack = new StackLayout()
				{
					Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.Fill

				};

				Label titulo = new Label()
				{
					Text = "31/0ut, 17:41",
					HorizontalOptions = LayoutOptions.Start,
					FontSize = 26,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label limite = new Label()
				{
					Text = "Limite: 60 km/h",
					HorizontalOptions = LayoutOptions.Start,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label latitude = new Label()
				{
					Text = "Latitude: 16,73456",
					HorizontalOptions = LayoutOptions.Start,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label longitude = new Label()
				{
					Text = "Longitude: -49,23480",
					HorizontalOptions = LayoutOptions.Start,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};

				Label angulo = new Label()
				{
					Text = "Ângulo: 179.0",
					HorizontalOptions = LayoutOptions.Start,
					//FontSize = 28,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};


				Label endereco = new Label()
				{
					Text = "Rua H-149, 1-73 Cidade Vera Cruz/ Aparecida de Goiânia",
					HorizontalOptions = LayoutOptions.Start,
					//FontSize = 20,
					FontFamily = "Roboto-Condensed",
					HorizontalTextAlignment = TextAlignment.Start
				};

				cardRigthStack.Children.Add(titulo);
				desc.Children.Add(limite);
				desc.Children.Add(latitude);
				desc.Children.Add(longitude);
				desc.Children.Add(angulo);
				desc.Children.Add(endereco);
				//scardRigthStack.Children.Add(endereco);
				cardRigthStack.Children.Add(desc);
				cardRigth.Content = cardRigthStack;

				main.Children.Add(cardLeft);
				main.Children.Add(cardRigth);

				View = main;
			}
		}
    }
}
