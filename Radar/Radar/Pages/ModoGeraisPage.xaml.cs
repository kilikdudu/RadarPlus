using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace Radar
{
	public partial class ModoGeraisPage : ContentPage
	{
		private static ModoGeraisPage _ModoGeraisPage;
		public ObservableCollection<string> labels { get; set; }
		public static ModoGeraisPage Atual
		{
			get
			{
				return _ModoGeraisPage;
			}
			private set
			{
				_ModoGeraisPage = value;
			}
		}
		public ModoGeraisPage()
		{

			labels = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add("COMPORTAMENTO");
			labels.Add("");
			labels.Add("Ao Desativar o GPS");
			labels.Add("Define a ação ao ser executada quanto o GPS for desativado");
			labels.Add("ATUALIZAÇÃO");
			labels.Add("");
			labels.Add("Verificar ao Iniciar");
			labels.Add("Lembrar sobre a atualização da Base de Dados de Radar ao iniciar o aplicativo");
			labels.Add("Intervalo de Verificação");
			labels.Add("");
			labels.Add("Última Verificação");
			labels.Add("");
			labels.Add("Última Atualização");
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
			_ModoGeraisPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoGeraisPage = null;
		}
	}
}

