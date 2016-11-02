using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoAlertasPage : ContentPage
	{
		private static ModoAlertasPage _ModoAlertasPage;
		public ObservableCollection<PreferenciaLabelInfo> labels { get; set; }
		public static ModoAlertasPage Atual
		{
			get
			{
				return _ModoAlertasPage;
			}
			private set
			{
				_ModoAlertasPage = value;
			}
		}
		public ModoAlertasPage()
		{

			labels = new ObservableCollection<PreferenciaLabelInfo>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add(new PreferenciaLabelInfo { Titulo = "Radar Móvel"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Pedágio"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Polícia Rodoviária"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Lombada"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Alerta Inteligente"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Beep de Aviso"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Vibrar ao Emitir um Alerta"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Tempo de Duração"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Tempo para o Alerta"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Distância para o Alerta"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Sobreposição Visual"});
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
			_ModoAlertasPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoAlertasPage = null;
		}
	}
}

