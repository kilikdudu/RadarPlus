using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoMeusRadaresPage : ContentPage
	{
		private static ModoMeusRadaresPage _ModoMeusRadaresPage;
		public ObservableCollection<PreferenciaLabelInfo> labels { get; set; }
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

			labels = new ObservableCollection<PreferenciaLabelInfo>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add(new PreferenciaLabelInfo
			{
				Titulo = "Exibir Botão para Adcionar",
				Descricao = "Se habilitado um botão de adcionar(+)" +
					"será exibido na tela de mapa e velocimetro"});
			labels.Add(new PreferenciaLabelInfo
			{
				Titulo = "Exibir Botão para Remover",
				Descricao = "Se habilitado um botão de remover(-)" +
					"será exibido quando aparecer um alerta de radar"});
			
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
			_ModoMeusRadaresPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoMeusRadaresPage = null;
		}
	}
}

