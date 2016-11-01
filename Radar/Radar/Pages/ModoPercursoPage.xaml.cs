using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace Radar
{
	public partial class ModoPercursoPage : ContentPage
	{
		private static ModoPercursoPage _ModoPercursoPage;
		public ObservableCollection<string> labels { get; set; }
		public static ModoPercursoPage Atual
		{
			get
			{
				return _ModoPercursoPage;
			}
			private set
			{
				_ModoPercursoPage = value;
			}
		}
		public ModoPercursoPage()
		{

			labels = new ObservableCollection<string>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add("Salvar Percurso");
			labels.Add("Salvar o percurso(dados recebidos pelo GPS" +
			           "enquanto o radar estive em funcionamento");
			labels.Add("Excluir Antigos");
			labels.Add("Exclui automaticamente os registros de percurso que forem " +
			           "considerados antigos");
			labels.Add("TEMPO");
			labels.Add("Defina com quantos dias um percurso se torna antigo");

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
			_ModoPercursoPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoPercursoPage = null;
		}
	}
}

