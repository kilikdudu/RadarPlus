using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Radar.Pages;
using Xamarin.Forms;

namespace Radar
{
	public partial class PreferenciasPage : ContentPage
	{
		private static PreferenciasPage _PreferenciasPageAtual;
		public ObservableCollection<string> menus { get; set; }
		public static PreferenciasPage Atual
		{
			get
			{
				return _PreferenciasPageAtual;
			}
			private set
			{
				_PreferenciasPageAtual = value;
			}
		}
		public PreferenciasPage()
		{
			
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
			Content = lstView;
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{
			switch (e.Item.ToString())
			{
				case "Modo Mapa":
					Navigation.PushAsync(new ModoMapaPage());
				break;
				case "Alertas":
					Navigation.PushAsync(new ModoAlertasPage());
				break;
				case "Audio":
					Navigation.PushAsync(new ModoAudioPage());
				break;
				case "Reprodução de Voz":
					Navigation.PushAsync(new ModoReproducaoVozPage());
				break;
				case "Gerais":
					Navigation.PushAsync(new ModoGeraisPage());
				break;
				case "Auto Início/Desligamento":
					Navigation.PushAsync(new ModoAutoInicioPage());
				break;	
				case "Percurso":
					Navigation.PushAsync(new ModoPercursoPage());
				break;
				case "Meus Radares":
					Navigation.PushAsync(new ModoMeusRadaresPage());
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
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };

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
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_PreferenciasPageAtual = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_PreferenciasPageAtual = null;
		}
	}

}
