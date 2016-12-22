using System;
using ClubManagement.Utils;
using Plugin.Media;
using Radar.Model;
using Radar.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Radar
{
	public class AdcionarEmpresaPopUp : PopupPage
	{
		Image _foto;
		Entry _nome;
		Entry _descricao;
		double _width;
		EmpresaInfo _empresaInfo;
		public AdcionarEmpresaPopUp()
		{
			EmpresaInfo item = new EmpresaInfo();
			inicializaComponente();
		}
		
		public AdcionarEmpresaPopUp(EmpresaInfo grupo)
		{
			_empresaInfo = grupo;
			inicializaComponente();
		}
		
		public void inicializaComponente()
		{
		
		Title = "Nova Empresa";

			if (TelaUtils.Orientacao == "Landscape")
			{
				_width = (int)TelaUtils.LarguraSemPixel * 0.3;
			}
			else {
				_width = (int)TelaUtils.LarguraSemPixel * 0.4;
			}


			ScrollView scrollMain = new ScrollView();
			scrollMain.Orientation = ScrollOrientation.Vertical;
			scrollMain.VerticalOptions = LayoutOptions.FillAndExpand;


			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.CenterAndExpand;
			main.HorizontalOptions = LayoutOptions.CenterAndExpand;


			StackLayout mainFrame = new StackLayout();
			mainFrame.BackgroundColor = Color.Transparent;
			mainFrame.Orientation = StackOrientation.Vertical;
			mainFrame.VerticalOptions = LayoutOptions.CenterAndExpand;
			mainFrame.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout stackPrincipal = new StackLayout();
			stackPrincipal.BackgroundColor = Color.Transparent;
			stackPrincipal.Orientation = StackOrientation.Horizontal;
			stackPrincipal.VerticalOptions = LayoutOptions.CenterAndExpand;
			stackPrincipal.HorizontalOptions = LayoutOptions.CenterAndExpand;

			Frame cardPrincipal = new Frame()
			{
				BackgroundColor = Color.FromHex(TemaInfo.BlueAccua),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = AbsoluteLayout.AutoSize
			};

			StackLayout stackLeft = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			
			
			_nome = new Entry
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			if (_empresaInfo != null)
			{
				_nome.Placeholder = _empresaInfo.Nome;
				_nome.IsEnabled = false;

			}
			else {
				_nome.Placeholder = "Digite um nome:";

			}

			_descricao = new Entry
			{
				//Placeholder = "Digite uma descrição:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			if (_empresaInfo != null)
			{
				_descricao.Placeholder = _empresaInfo.Descricao;
				
			}
			else {
				_descricao.Placeholder = "Digite uma descrição:";

			}

			StackLayout stackRight = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
			};

			_foto = new Image()
			{
				Source = "ic_add_a_photo_black_48dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.2,
				HeightRequest = TelaUtils.LarguraSemPixel * 0.2
			};

			StackLayout stackButtons = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
			};
			Button gravar = new Button()
			{
				Text = "Gravar",
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontFamily = "Roboto-Condensed",
				BackgroundColor = Color.Transparent,
				FontSize = 20
			};

			gravar.Clicked += OnGravar;

			Button cancelar = new Button()
			{
				Text = "Cancelar",
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontFamily = "Roboto-Condensed",
				BackgroundColor = Color.Transparent,
				FontSize = 20
			};
			cancelar.Clicked += OnCancelar;

			stackButtons.Children.Add(cancelar);
			stackButtons.Children.Add(gravar);

			_foto.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
							tirarFoto();
						}
					)
					});

			stackLeft.Children.Add(_foto);
			stackRight.Children.Add(_nome);
			stackRight.Children.Add(_descricao);

			stackPrincipal.Children.Add(stackLeft);
			stackPrincipal.Children.Add(stackRight);
			main.Children.Add(stackPrincipal);
			main.Children.Add(stackButtons);

			scrollMain.Content = main;
			cardPrincipal.Content = main;

			mainFrame.Children.Add(cardPrincipal);
			Content = mainFrame;


		}
		

		private void OnCancelar(object sender, EventArgs e)
		{
			NavigationX.create(this).PopModalAsync();
		}

		private void OnGravar(object sender, EventArgs e)
		{
			//GrupoBLL regraGrupo = new GrupoBLL();
			//GrupoInfo grupo = new GrupoInfo();
			//grupo.Nome = _nome.Text;
			//grupo.Descricao = _descricao.Text;
			//regraGrupo.gravar(grupo);
			//PopupNavigation.PopAsync();
		}

		private async void tirarFoto()
		{

			if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
			{

				var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{

					Directory = "Cupons",
					Name = $"{DateTime.UtcNow}.jpg",
					//SaveToAlbum = true

				};

				// Take a photo of the business receipt.
				var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);


				if (file == null)
					return;

				//DisplayAlert("Salvar em", file.Path, "OK");
				var path = file.Path;
				_foto.Source = ImageSource.FromStream(() =>
				{
					var stream = file.GetStream();
					file.Dispose();
					return stream;
				});

				_foto.Source = path;
				_foto.WidthRequest = TelaUtils.LarguraSemPixel * 0.3;
				_foto.HeightRequest = TelaUtils.LarguraSemPixel * 0.3;


			}
			else {
				DisplayAlert("Dispositivo não possiu camera ou camera desativada", null, "OK");
			}
		}

		

		public void abrirCusto(Object sender, EventArgs e)
		{
			((MasterDetailPage)Application.Current.MainPage).Detail =  new NavigationPage(new NovoCustoPage());
			PopupNavigation.PopAsync();
			//Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new NovoCustoPage());
			//NavigationX.create(this).PushModalAsync(new NovoCustoPage());

		}
	}
}

