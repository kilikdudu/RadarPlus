using System.Collections.ObjectModel;
using ClubManagement.Utils;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class EmpresaPage : ContentPage
	{

		public EmpresaPage()
		{
		
			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.FillAndExpand;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			
			Label title = new Label
			{
				Text = "Empresas",
				Margin = new Thickness(20,20,0,0),
				FontFamily = TemaInfo.fontPadrao,
				FontSize = 26,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				HorizontalOptions = LayoutOptions.Center
			};
			BoxView linha = new BoxView
			{
				HeightRequest = 1,
				BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor),
				HorizontalOptions = LayoutOptions.Fill,
				Margin = new Thickness(0,60,0,0),
			};
					
			ObservableCollection<EmpresaInfo> empresa = new ObservableCollection<EmpresaInfo>();
			empresa.Add(new EmpresaInfo(){ Nome="Compradores", Descricao="Empresa x", Imagem="navicon.png"});
			empresa.Add(new EmpresaInfo(){ Nome="Vendedores", Descricao="Empresa Y", Imagem="navicon.png"});
			empresa.Add(new EmpresaInfo(){ Nome="Entregadores", Descricao="Empresa z", Imagem="navicon.png"});
			
			ListView listaEmpresas = new ListView();
			listaEmpresas.RowHeight = 120;
			listaEmpresas.ItemTemplate = new DataTemplate(typeof(EmpresasCelula));
			listaEmpresas.ItemTapped += OnTap;
			listaEmpresas.ItemsSource = empresa;
			listaEmpresas.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaEmpresas.HasUnevenRows = true;
			listaEmpresas.SeparatorColor = Color.Transparent;
			//listaEmpresas.VerticalOptions = LayoutOptions.Fill;
			//listaEmpresas.HorizontalOptions = LayoutOptions.Center;
			listaEmpresas.Margin = new Thickness(0, 70, 0, 0);
			AbsoluteLayout.SetLayoutBounds(listaEmpresas, new Rectangle(0, 0, 1, 1));
			AbsoluteLayout.SetLayoutFlags(listaEmpresas, AbsoluteLayoutFlags.All);
			
			listaEmpresas.BindingContext = empresa;
			Image AdicionarEmpresaButton = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("mais.png"),
				WidthRequest = 180,
				HeightRequest = 180,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
				Margin = new Thickness(0,0 , 10, 10)
			};
			AdicionarEmpresaButton.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
						adcionarEmpresa();
						}
					)
					});

			AbsoluteLayout.SetLayoutBounds(AdicionarEmpresaButton, new Rectangle(0.93, 0.975, 0.2, 0.2));
			AbsoluteLayout.SetLayoutFlags(AdicionarEmpresaButton, AbsoluteLayoutFlags.All);
			
			listaView.Children.Add(title);
			listaView.Children.Add(linha);
			listaView.Children.Add(listaEmpresas);
			listaView.Children.Add(AdicionarEmpresaButton);
			Content = listaView;
		}

		public void adcionarEmpresa()
		{
			NavigationX.create(this).PushModalAsync(new AdcionarEmpresaPopUp());
		
		}

		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			EmpresaInfo item = (EmpresaInfo)e.Item;
			//NavigationX.create(this).PopModalAsync();
			App.Current.MainPage = new NavegacaoPage();
					//((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new GrupoTabbedPage());
		}

		public class EmpresasCelula : ViewCell
		{

			public EmpresasCelula()
			{

				var excluirEmpresa = new MenuItem
				{
					Text = "Excluir"
				};

				excluirEmpresa.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirEmpresa.Clicked += (sender, e) =>
				{
					//GrupoInfo grupo = (GrupoInfo)((MenuItem)sender).BindingContext;
					//GrupoBLL regraGrupo = GrupoFactory.create();
					//regraGrupo.excluir(grupo.Id);

					ListView listaEmpresas = this.Parent as ListView;

					listaEmpresas.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaEmpresas.RowHeight = 120;
					//var grupos = regraGrupo.listar();
					//listaGrupos.BindingContext = grupos;
					listaEmpresas.ItemTemplate = new DataTemplate(typeof(EmpresasCelula));
				};
				ContextActions.Add(excluirEmpresa);

				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Horizontal;
				main.VerticalOptions = LayoutOptions.CenterAndExpand;
				main.HorizontalOptions = LayoutOptions.StartAndExpand;

				StackLayout stackRight = new StackLayout();
				stackRight.Orientation = StackOrientation.Vertical;
				stackRight.VerticalOptions = LayoutOptions.CenterAndExpand;
				stackRight.HorizontalOptions = LayoutOptions.StartAndExpand;

				StackLayout stackLeft = new StackLayout();
				stackLeft.Orientation = StackOrientation.Vertical;
				stackLeft.VerticalOptions = LayoutOptions.CenterAndExpand;
				stackLeft.HorizontalOptions = LayoutOptions.StartAndExpand;


				Image foto = new Image()
				{
					WidthRequest = 50,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					//Source = "ic_add_a_photo_48pt.png"
				};
				foto.SetBinding(Image.SourceProperty, new Binding("Imagem"));

				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Nome"));


				Label descricao = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				descricao.SetBinding(Label.TextProperty, new Binding("Descricao"));

		
				var frameOuter = new Frame();
				frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				frameOuter.HeightRequest = AbsoluteLayout.AutoSize;
				if (Device.OS == TargetPlatform.iOS)
				{
					foto.WidthRequest = 60;

					//frameOuter.Padding = new Thickness(5, 10, 5, 10);
					frameOuter.WidthRequest = TelaUtils.Largura * 0.9;
					frameOuter.Margin = new Thickness(5, 10, 5, 0);

				}
				else {
					frameOuter.Margin = new Thickness(5, 10, 5, 10);
				}

				stackLeft.Children.Add(foto);
				stackRight.Children.Add(nome);
				stackRight.Children.Add(descricao);

				main.Children.Add(stackLeft);
				main.Children.Add(stackRight);

				frameOuter.Content = main;

				View = frameOuter;

			}


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{

			base.OnDisappearing();
		}
	}
}
