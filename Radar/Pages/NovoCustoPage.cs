using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClubManagement.Utils;
using Plugin.Media;
using Radar.Controls;
using Radar.IBLL;
using Radar.Model;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class NovoCustoPage : ContentPage
	{
		DropDownPicker _Drop1;
		Image _cupomFiscal;
		Entry _local;
		double _width;
	
		public NovoCustoPage()
		{
			Title = "Novo Custo";

			if (TelaUtils.Orientacao == "Landscape")
			{
				_width = (int)TelaUtils.LarguraSemPixel * 0.5;
			}
			else {
				_width = (int)TelaUtils.LarguraSemPixel * 0.8;
			}
			ScrollView scrollMain = new ScrollView();
			scrollMain.Orientation = ScrollOrientation.Vertical;
			scrollMain.VerticalOptions = LayoutOptions.FillAndExpand;

			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.StartAndExpand;
			main.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout valorStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};

			Image dinheiroIcone = new Image()
			{
				Source = "ic_monetization_on_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			var valor = new Entry
			{
				Placeholder = "Digite o valor",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			NumberValidatorBehavior SecSenhaValidator = new NumberValidatorBehavior();
			valor.Behaviors.Add(SecSenhaValidator);
			valorStack.Children.Add(dinheiroIcone);
			valorStack.Children.Add(valor);

			StackLayout dataStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};

			Image dataIcone = new Image()
			{
				Source = "ic_event_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			var data = new DatePicker
			{
				IsVisible = true,
				IsEnabled = true,
				WidthRequest = _width,
			};


			dataStack.Children.Add(dataIcone);
			dataStack.Children.Add(data);


			StackLayout tipoCustoStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};

			Image tipoCustoIcone = new Image()
			{
				Source = "ic_shopping_cart_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			_Drop1 = new DropDownPicker
			{
				//WidthRequest = Device.OnPlatform(100, 120, 100),
				WidthRequest = _width,
				//HeightRequest = 25,
				DropDownHeight = 150,
				Title = "Tipo",
				SelectedText = "",
				//FontSize = Device.OnPlatform(10, 14, 10),
				CellHeight = 20,
				SelectedBackgroundColor = Color.FromRgb(0, 70, 172),
				SelectedTextColor = Color.White,
				BorderColor = Color.Purple,
				ArrowColor = Color.Blue
			};
			Items();
			tipoCustoStack.Children.Add(tipoCustoIcone);
			tipoCustoStack.Children.Add(_Drop1);

			StackLayout tagsStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};

			Image tagsIcone = new Image()
			{
				Source = "ic_local_offer_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			var tags = new Entry
			{
				Placeholder = "Tags",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			tagsStack.Children.Add(tagsIcone);
			tagsStack.Children.Add(tags);

			StackLayout observacaoStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};
			Image observacaoIcone = new Image()
			{
				Source = "ic_edit_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			var observacao = new Entry
			{
				Placeholder = "Observação",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			observacaoStack.Children.Add(observacaoIcone);
			observacaoStack.Children.Add(observacao);

			StackLayout localStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};

			Image localIcone = new Image()
			{
				Source = "ic_map_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			_local = new Entry
			{
				//Placeholder = "Digite o titulo",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};

			localStack.Children.Add(localIcone);
			localStack.Children.Add(_local);



			StackLayout fotoStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};
			 
			_cupomFiscal = new Image()
			{
				Source = "ic_add_a_photo_48pt.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = TelaUtils.LarguraSemPixel * 0.4,
				HeightRequest = TelaUtils.LarguraSemPixel * 0.4
			};

			_cupomFiscal.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
							tirarFoto();
						}
					)
			});

			fotoStack.Children.Add(_cupomFiscal);

			main.Children.Add(valorStack);
			main.Children.Add(dataStack);
			main.Children.Add(localStack);
			main.Children.Add(tipoCustoStack);
			main.Children.Add(tagsStack);
			main.Children.Add(observacaoStack);
			main.Children.Add(fotoStack);

			scrollMain.Content = main;
			Content = scrollMain;
		}

		private void mostraEndereco(string endereco)
		{
			_local.Text = endereco;
		}
		private void pegaEndereco()
		{
			
				if (InternetUtils.estarConectado())
				{
					LocalizacaoInfo localEndereco = GPSUtils.UltimaLocalizacao;
					float latitude = (float)localEndereco.Latitude;
					float longitude = (float)localEndereco.Longitude;

				GeocoderUtils.pegarAsync(latitude, longitude, async (send, ev) =>
				   {
					   var endereco = ev.Endereco;
					mostraEndereco(endereco.Logradouro);

				   });
				}

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
					_cupomFiscal.Source = ImageSource.FromStream(() =>
					{
						var stream = file.GetStream();
						file.Dispose();
						return stream;
					});

				_cupomFiscal.Source = path;
				_cupomFiscal.WidthRequest = TelaUtils.LarguraSemPixel * 0.5;
				_cupomFiscal.HeightRequest = TelaUtils.LarguraSemPixel * 0.5;


			}
			else {
				DisplayAlert("Dispositivo não possiu camera ou camera desativada", null, "OK");
			}
		}

		private void Items()
		{
			var d = new List<string>();
			d.Add("Abastecimento");
			d.Add("Despesas");
			d.Add("Multas");

			this._Drop1.Source = d;
		}
	}
}

