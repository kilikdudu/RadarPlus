using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Radar.Pages;
using Xamarin.Forms;
using Radar.Model;
using Radar.Controls;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Radar
{
	public partial class PreferenciaPage : ContentPage
	{
		private static PreferenciaPage _PreferenciaPageAtual;
		public List<ListaInfo> menus;

		public static PreferenciaPage Atual

		{
			get
			{
				return _PreferenciaPageAtual;
			}
			private set
			{
                _PreferenciaPageAtual = value;
			}
		}
		public PreferenciaPage()
		{

			menus = new List<ListaInfo>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Preferências";
			lstView.ItemTemplate = new DataTemplate(typeof(MenusCelula));
			lstView.ItemTapped += OnTap;
			menus.Add(new ListaInfo() { 
				Titulo= "Modo Mapa", 
				Imagem = "modomapa.png", 
				aoClicar = (sender, e) => { 
					this.Navigation.PushAsync(new ModoMapaPage()); 
				} 
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Alertas", 
				Imagem = "alerta.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoAlertaPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Audio", 
				Imagem = "audio.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoAudioPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Reprodução de Voz", 
				Imagem = "reproducaodevoz.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoReproducaoVozPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Gerais", 
				Imagem = "gerais.png", 
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoGeralPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Auto Início/Desligamento", 
				Imagem = "autoiniciodesligamento.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoAutoInicioPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Percurso", 
				Imagem = "percursos.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoPercursoPage());
				}
			});
			menus.Add(new ListaInfo() { 
				Titulo = "Meus Radares", 
				Imagem = "meusradares.png",
				aoClicar = (sender, e) =>
				{
					this.Navigation.PushAsync(new ModoMeuRadarPage());
				}
			});			
			lstView.ItemsSource = menus;
			lstView.HasUnevenRows = true;
            lstView.SeparatorColor = Color.Transparent;
			//lstView.BackgroundColor = Color.FromHex(TemaInfo.TextIcons);
			//lstView.SeparatorColor = Color.FromHex(TemaInfo.DividerColor);

			Content = lstView;
		}


		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			ListaInfo item = (ListaInfo)e.Item;
			if (item.aoClicar != null)
			{
				if (this.Navigation.NavigationStack.Count == 1)
				{
					item.aoClicar(sender, e);
				}
			}

		}

		public class MenusCelula : ViewCell
		{
			
			public MenusCelula()
			{

				Label nameLabel = new Label
				{
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HeightRequest = 36,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
							VerticalOptions = LayoutOptions.Center,


				};
				var icone = new Image();
				nameLabel.SetBinding(Label.TextProperty, new Binding("Titulo"));

				var horizontalLayout = new StackLayout();
				var frameInner = new Frame();
				var frameOuter = new Frame();
				if (Device.OS == TargetPlatform.iOS)
				{
					icone.WidthRequest = 40;
					icone.HeightRequest = 40;

				}
				else
				{
					icone.WidthRequest = 60;
					icone.HeightRequest = 60;
					icone.Margin = new Thickness(20, 0, 10, 0);
				}
				icone.SetBinding(Image.SourceProperty, new Binding("Imagem"));


				icone.HorizontalOptions = LayoutOptions.StartAndExpand;

				horizontalLayout.Padding = new Thickness(20, 0, 20, 0);
		        horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.StartAndExpand;
				horizontalLayout.VerticalOptions = LayoutOptions.FillAndExpand;
				//horizontalLayout.HeightRequest = 40;
                //frameOuter.Padding = new Thickness(20, 20, 20, 20);
                //frameOuter.HeightRequest = 66;
                frameOuter.Margin = new Thickness(10, 5, 10, 5);
                //frameInner.OutlineColor = Color.Black;
                frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				//frameOuter.Padding = new Thickness(0, 0, 20, 0);

				//verticaLayout.Children.Add(nameLabel);
				horizontalLayout.Children.Add(icone);
				horizontalLayout.Children.Add(nameLabel);
				//frameInner.Content = horizontalLayout;
				frameOuter.Content = horizontalLayout;



				// add to parent view
				View = frameOuter;
				this.View.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				//this.Tapped += (sender, e) =>
				//{
				//	this.View.BackgroundColor = Color.FromHex(TemaInfo.AccentColor);
				//	Task.Delay(2000);
				//	this.View.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				//};

			}


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            _PreferenciaPageAtual = this;
		}

		protected override void OnDisappearing()
		{
			
			base.OnDisappearing();
            _PreferenciaPageAtual = null;
		}
	}

}
