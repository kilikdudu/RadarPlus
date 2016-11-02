using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoGeraisPage : ContentPage
	{
		private static ModoGeraisPage _ModoGeraisPage;
		public ObservableCollection<PreferenciaLabelInfo> labels { get; set; }
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

			labels = new ObservableCollection<PreferenciaLabelInfo>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add(new PreferenciaLabelInfo { Titulo = "COMPORTAMENTO"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Ao Desativar o GPS", 
				Descricao = "Define a ação ao ser executada quanto o GPS for desativado" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "ATUALIZAÇÃO"});
			labels.Add(new PreferenciaLabelInfo
			{
				Titulo = "Verificar ao Iniciar",
				Descricao = "Lembrar sobre a atualização da Base de Dados de Radar ao iniciar o aplicativo"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Intervalo de Verificação" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Última Verificação" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Última Atualização" });
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
			_ModoGeraisPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoGeraisPage = null;
		}
	}
}

