using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Radar.Pages;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class PreferenciaPage : ContentPage
	{
		private static PreferenciaPage _PreferenciaPageAtual;
		public ObservableCollection<string> menus { get; set; }
		ModoMapaPage modoMapaPage = new ModoMapaPage();
		ModoAlertaPage modoAlertaPage = new ModoAlertaPage();
		ModoAudioPage modoAudioPage = new ModoAudioPage();
		ModoReproducaoVozPage modoReproducaoVozPage = new ModoReproducaoVozPage();
		ModoGeralPage modoGeralPage = new ModoGeralPage();
		ModoAutoInicioPage modoAutoInicioPage = new ModoAutoInicioPage();
		ModoPercursoPage modoPercursoPage = new ModoPercursoPage();
		ModoMeuRadarPage modoMeuRadarPage = new ModoMeuRadarPage();
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
			

			this.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Blue);


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
			lstView.BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor);
			lstView.SeparatorColor = Color.FromHex(TemaInfo.DividerColor);

			Content = lstView;
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{
			
				switch (e.Item.ToString())
				{
					case "Modo Mapa":

						Navigation.PushAsync(modoMapaPage);
						break;
					case "Alertas":
						Navigation.PushAsync(modoAlertaPage);
						break;
					case "Audio":
						Navigation.PushAsync(modoAudioPage);
						break;
					case "Reprodução de Voz":
						Navigation.PushAsync(modoReproducaoVozPage);
						break;
					case "Gerais":
						Navigation.PushAsync(modoGeralPage);
						break;
					case "Auto Início/Desligamento":
						Navigation.PushAsync(modoAutoInicioPage);
						break;
					case "Percurso":
						Navigation.PushAsync(modoPercursoPage);
						break;
					case "Meus Radares":
						Navigation.PushAsync(modoMeuRadarPage);
					break;
					
			}

		}

		public class MenusCelula : ViewCell
		{
			
			public MenusCelula()
			{
				//instantiate each of our views
				var nameLabel = new Label();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor) };

				//set bindings
				nameLabel.SetBinding(Label.TextProperty, new Binding("."));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				nameLabel.Margin = 20;
				nameLabel.FontSize = 20;

				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				horizontalLayout.Children.Add(verticaLayout);

				// add to parent view
				View = horizontalLayout;
				this.Tapped += (sender, e) =>
				{
					this.View.BackgroundColor = Color.FromHex(TemaInfo.AccentColor);
				};
				this.View.BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor);
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
