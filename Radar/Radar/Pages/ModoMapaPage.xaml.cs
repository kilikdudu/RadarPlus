using System;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using Radar.Pages.Popup;
using Rg.Plugins.Popup.Extensions;
using Radar.Controls;

namespace Radar {
    public partial class ModoMapaPage : ContentPage
	{
		private static ModoMapaPage _ModoMapaPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

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
        
        public ModoMapaPage() {
            InitializeComponent();
            Title = "Modo Mapa";

            //Content = new ScrollView() { Content = teststack };

				bussola.IsToggled = Configuracao.Bussola;

				sinalGPS.IsToggled = Configuracao.SinalGPS;

				imagenSatelite.IsToggled = Configuracao.ImagenSatelite;
		
				infoTrafego.IsToggled = Configuracao.InfoTrafego;

				rotacionarMapa.IsToggled = Configuracao.RotacionarMapa;

				suavizarAnimacao.IsToggled = Configuracao.SuavizarAnimacao;
            
        }

		public void bussolaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("bussola",1);
			}
			else {
				regraPreferencia.gravar("bussola", 0);
			}
		}

		public void sinalGPSToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("sinalGPS", 1);
			}
			else {
				regraPreferencia.gravar("sinalGPS", 0);
			}
		}

		public void imagenSateliteToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("imagenSatelite", 1);
			}
			else {
				regraPreferencia.gravar("imagenSatelite", 0);
			}
		}
		public void infoTrafegoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("infoTrafego", 1);
			}
			else {
				regraPreferencia.gravar("infoTrafego", 0);
			}
		}
		public void rotacionarMapaToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("rotacionarMapa", 1);
			}
			else {
				regraPreferencia.gravar("rotacionarMapa", 0);
			}
		}

        public void suavizarAnimacaoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("suavizarAnimacao", 1);
			}
			else {
				regraPreferencia.gravar("suavizarAnimacao", 0);
			}
		}

        async void nivelZoomTapped(object sender, EventArgs e) {
        
            var page = new NivelZoomPopUp();

            await Navigation.PushPopupAsync(page);
            // or
           //await Navigation.PushAsync(page);
        }

    /*
    public ModoMapaPage()
    {

        Labels = new ObservableCollection<PreferenciaLabelInfo>();

        lstView.RowHeight = 80;
        this.Title = "Modo Mapa";
        lstView.ItemTemplate = new DataTemplate(typeof(Celulas));
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Bussola" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Sinal do GPS" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Imagem do Satélite" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Informações de Tráfego" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Rotacionar Mapa", Descricao = "Sempre rotacionar o mapa" +
                " para mostrar uma visal frontal" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Nível de Zoom" });
        Labels.Add(new PreferenciaLabelInfo { Titulo = "Suavizar Animação" });
        lstView.ItemsSource = Labels;
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
            var verticaLayout = new StackLayout()
            {
                Padding = new Thickness(0, 0, 0, 0)
            };
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
            horizontalLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            verticaLayout.Orientation = StackOrientation.Vertical;
            verticaLayout.HorizontalOptions = LayoutOptions.FillAndExpand;

            tituloLabel.Margin = new Thickness(20,10,0,0);
            tituloLabel.FontSize = 20;
            mySwitch.Margin = new Thickness(0, -20, 30, 0);
            descricaoLabel.Margin = new Thickness(20, -20, 0, 0);
            descricaoLabel.FontSize = 14;

            tituloLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            mySwitch.HorizontalOptions = LayoutOptions.EndAndExpand;
            descricaoLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            //add views to the view hierarchy
            verticaLayout.Children.Add(tituloLabel);
            verticaLayout.Children.Add(mySwitch);

            //verticaLayout.Children.Add(horizontalLayout);
            verticaLayout.Children.Add(descricaoLabel);

            //horizontalLayout.Children.Add(verticaLayout);


            // add to parent view
            View = verticaLayout;
        }
    }
    */
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

