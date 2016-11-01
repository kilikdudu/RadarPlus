using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace Radar
{
	public partial class ModoAlertasPage : ContentPage
	{
		private static ModoAlertasPage _ModoAlertasPage;
		public ObservableCollection<string> labels { get; set; }
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

			labels = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add("Radar Móvel");
			labels.Add("Pedágio");
			labels.Add("Polícia Rodoviária");
			labels.Add("Lombada");
			labels.Add("Alerta Inteligente");
			labels.Add("Beep de Aviso");
			labels.Add("Vibrar ao Emitir um Alerta");
			labels.Add("Tempo de Duração");
			labels.Add("Tempo para o Alerta");
			labels.Add("Distância para o Alerta");
			labels.Add("Sobreposição Visual");
			lstView.ItemsSource = labels;
			Content = lstView;
		}



		public class Celulas : ViewCell
		{
			public Celulas()
			{
				//instantiate each of our views
				var nameLabel = new Label();
				var mySwitch = new Switch();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };
				mySwitch.Toggled += (object sender, ToggledEventArgs e) =>
				{
					Debug.WriteLine("TEste");
				};
				mySwitch.IsToggled = true;


				//set bindings
				nameLabel.SetBinding(Label.TextProperty, new Binding("."));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				nameLabel.Margin = 20;
				nameLabel.FontSize = 20;

				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				verticaLayout.Children.Add(mySwitch);
				horizontalLayout.Children.Add(verticaLayout);

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

