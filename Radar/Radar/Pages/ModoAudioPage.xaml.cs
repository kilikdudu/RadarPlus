using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace Radar
{
	public partial class ModoAudioPage : ContentPage
	{
		private static ModoAudioPage _ModoAudioPage;
		public ObservableCollection<string> labels { get; set; }
		public static ModoAudioPage Atual
		{
			get
			{
				return _ModoAudioPage;
			}
			private set
			{
				_ModoAudioPage = value;
			}
		}
		public ModoAudioPage()
		{

			labels = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add("Canal de Áudio");
			labels.Add("Define se o alerta de radares será feito através do " +
			           "canal de música ou através do auto-falante do dispositivo");
			labels.Add("Volume Personalizado");
			labels.Add("Configurar um volume padrão para alertas, sobrepondo" +
			           "o volume definido no aparelho");
			labels.Add("Altura do Volume");
			labels.Add("");
			labels.Add("Som na Caixa");
			labels.Add("Enviar o som também para o alto-falante do dispositivo");
			labels.Add("Som do Alerta");
			labels.Add("");
			lstView.ItemsSource = labels;
			Content = lstView;
		}



		public class Celulas : ViewCell
		{
			public Celulas()
			{
				//instantiate each of our views
				var nameLabel = new Label();
				var descLabel = new Label();
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
				descLabel.SetBinding(Label.TextProperty, new Binding("desc"));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				nameLabel.Margin = 20;
				nameLabel.FontSize = 20;
				descLabel.Margin = 20;
				descLabel.FontSize = 14;
				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				verticaLayout.Children.Add(descLabel);
				verticaLayout.Children.Add(mySwitch);
				horizontalLayout.Children.Add(verticaLayout);

				// add to parent view
				View = horizontalLayout;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_ModoAudioPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoAudioPage = null;
		}
	}
}

