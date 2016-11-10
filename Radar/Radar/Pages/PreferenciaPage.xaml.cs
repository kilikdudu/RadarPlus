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
		public ObservableCollection<string> menus { get; set; }

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

			this.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Red);

			menus = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Preferências";
			lstView.ItemTemplate = new DataTemplate(typeof(MenusCelula));
			lstView.ItemTapped += OnTap;
			menus.Add("Modo Mapa");
			menus.Add("Alertas");
			menus.Add("Audio");
			menus.Add("Reprodução de Voz" );
			menus.Add("Gerais");
			menus.Add("Auto Início/Desligamento");
			menus.Add("Percurso");
			menus.Add("Meus Radares" );			
			lstView.ItemsSource = menus;
			lstView.HasUnevenRows = true;
			//lstView.BackgroundColor = Color.FromHex(TemaInfo.TextIcons);
			//lstView.SeparatorColor = Color.FromHex(TemaInfo.DividerColor);

			Content = lstView;
		}
		protected override bool OnBackButtonPressed()
		{
			System.Diagnostics.Debug.WriteLine("TESTE");
			return base.OnBackButtonPressed();
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{
			
			
				switch (e.Item.ToString())
				{
					case "Modo Mapa":

					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoMapaPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Alertas":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoAlertaPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Audio":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoAudioPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Reprodução de Voz":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoReproducaoVozPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Gerais":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoGeralPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Auto Início/Desligamento":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoAutoInicioPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Percurso":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoPercursoPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
						break;
					case "Meus Radares":
					if (this.Navigation.NavigationStack.Count == 1)
					{
						this.Navigation.PushAsync(new ModoMeuRadarPage());
						Debug.WriteLine("NavigationStack" + this.Navigation.NavigationStack.Count);
					}
					break;
					
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
					FontSize = 20

				};
				nameLabel.SetBinding(Label.TextProperty, new Binding("."));

				var horizontalLayout = new StackLayout();
				var frameInner = new Frame();
				var frameOuter = new Frame();

				horizontalLayout.Padding = new Thickness(20, 0, 0, 0);
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.StartAndExpand;
				frameInner.Padding = new Thickness(20, 20, 20, 20);
				frameInner.HeightRequest = 36;
				//frameInner.OutlineColor = Color.Black;
				frameInner.BackgroundColor = Color.FromHex(TemaInfo.SecondaryText);
				frameOuter.Padding = new Thickness(4, 1, 1, 4);

				//verticaLayout.Children.Add(nameLabel);
				horizontalLayout.Children.Add(nameLabel);
				frameInner.Content = horizontalLayout;
				frameOuter.Content = frameInner;



				// add to parent view
				View = frameInner;
				this.View.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				this.Tapped += (sender, e) =>
				{
					this.View.BackgroundColor = Color.FromHex(TemaInfo.AccentColor);
					Task.Delay(2000);
					this.View.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				};

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
