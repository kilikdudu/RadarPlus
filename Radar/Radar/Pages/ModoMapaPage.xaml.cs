using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;


namespace Radar
{
	public partial class ModoMapaPage : ContentPage
	{
		private static ModoMapaPage _ModoMapaPage;
		public ObservableCollection<PreferenciaLabelInfo> labels { get; set; }
		ListView lstView = new ListView();
		public static ModoMapaPage Atual
		{
			get
			{
				return _ModoMapaPage;
			}
			private set
			{
				_ModoMapaPage = value;
			}
		}
		public ModoMapaPage()
		{

			labels = new ObservableCollection<PreferenciaLabelInfo>();

			lstView.RowHeight = 60;
			this.Title = "Modo Mapa";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add(new PreferenciaLabelInfo { Titulo = "Bussola", Descricao = "aaaaaaaaaa" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Sinal do GPS" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Imagem do Satélite" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Informações de Tráfego" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Rotacionar Mapa", Descricao = "Sempre rotacionar o mapa" +
					"para mostrar uma visal frontal" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Nível de Zoom" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Suavizar Animação" });
			lstView.ItemsSource = labels;
			Content = lstView;
		}



		public class Celulas : ViewCell
		{
			public Celulas()
			{
				//instantiate each of our views
				var tituloLabel = new Label();
				var descricaoLabel = new Label();
				var mySwitch = new Switch();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };
				mySwitch.Toggled += (object sender, ToggledEventArgs e) =>
				{
					
						Debug.WriteLine(mySwitch.IsToggled);

				};



				//set bindings
				tituloLabel.SetBinding(Label.TextProperty, new Binding("Titulo"));
				descricaoLabel.SetBinding(Label.TextProperty, new Binding("Descricao"));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				horizontalLayout.HorizontalOptions = LayoutOptions.End;
				verticaLayout.Orientation = StackOrientation.Vertical;
				verticaLayout.HorizontalOptions = LayoutOptions.Start;
				tituloLabel.Margin = 20;
				tituloLabel.FontSize = 20;
				descricaoLabel.Margin = 20;
				descricaoLabel.FontSize = 14;
				tituloLabel.HorizontalOptions = LayoutOptions.Start;

				//add views to the view hierarchy
				verticaLayout.Children.Add(tituloLabel);
				verticaLayout.Children.Add(descricaoLabel);
				horizontalLayout.Children.Add(verticaLayout);

				horizontalLayout.Children.Add(mySwitch);

				// add to parent view
				View = horizontalLayout;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_ModoMapaPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoMapaPage = null;
		}
	}
}

