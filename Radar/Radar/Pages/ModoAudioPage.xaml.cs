using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoAudioPage : ContentPage
	{
		private static ModoAudioPage _ModoAudioPage;
		public ObservableCollection<PreferenciaLabelInfo> labels { get; set; }
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

			labels = new ObservableCollection<PreferenciaLabelInfo>();
			ListView lstView = new ListView();
			lstView.RowHeight = 60;
			this.Title = "Alertas";
			lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
			labels.Add(new PreferenciaLabelInfo
			{
				Titulo = "Canal de Áudio",
				Descricao = "Define se o alerta de radares será feito através do " +
					"canal de música ou através do auto-falante do dispositivo" });
			labels.Add(new PreferenciaLabelInfo
			{
				Titulo = "Volume Personalizado",
				Descricao = "Configurar um volume padrão para alertas, sobrepondo" +
					"o volume definido no aparelho"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Altura do Volume"});
			labels.Add(new PreferenciaLabelInfo { Titulo = "Som na Caixa", 
				Descricao = "Enviar o som também para o alto-falante do dispositivo" });
			labels.Add(new PreferenciaLabelInfo { Titulo = "Som do Alerta" });
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
			_ModoAudioPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoAudioPage = null;
		}
	}
}

