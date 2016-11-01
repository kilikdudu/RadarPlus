using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace Radar
{
	public partial class ModoMeusRadaresPage : ContentPage
	{
		private static ModoMeusRadaresPage _ModoMeusRadaresPage;
		public ObservableCollection<string> labels { get; set; }
		public static ModoMeusRadaresPage Atual
		{
			get
			{
				return _ModoMeusRadaresPage;
			}
			private set
			{
				_ModoMeusRadaresPage = value;
			}
		}
		public ModoMeusRadaresPage()
		{

			labels = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add("Exibir Botão para Adcionar");
			labels.Add("Se habilitado um botão de adcionar(+)" +
			           "será exibido na tela de mapa e velocimetro");
			labels.Add("Exibir Botão para Remover");
			labels.Add("Se habilitado um botão de remover(-)" +
			           "será exibido quando aparecer um alerta de radar");
			
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
			_ModoMeusRadaresPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoMeusRadaresPage = null;
		}
	}
}

