using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClubManagement.Utils;
using Plugin.Media;
using Radar.BLL;
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
		Entry _valor;
		DatePicker _data;
		Entry _tag;
		Entry _observacao;
		Picker _picker;

		TagInfo _tagInfo;
		
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

			_valor = new Entry
			{
				Placeholder = "Digite o valor",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			NumberValidatorBehavior SecSenhaValidator = new NumberValidatorBehavior();
			_valor.Behaviors.Add(SecSenhaValidator);
			valorStack.Children.Add(dinheiroIcone);
			valorStack.Children.Add(_valor);

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

			_data = new DatePicker
			{
				IsVisible = true,
				IsEnabled = true,
				WidthRequest = _width,
			};


			dataStack.Children.Add(dataIcone);
			dataStack.Children.Add(_data);


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

			_tag = new Entry
			{
				Placeholder = "Tags",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width - 90,
			};
			
			tagsStack.Children.Add(tagsIcone);
			tagsStack.Children.Add(_tag);
			
			StackLayout tagsCorStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal
			};
			
			Image tagsCorIcone = new Image()
			{
				Source = "ic_color_lens_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};
			
			_picker = new Picker
            {
                Title = "Cor",
                VerticalOptions = LayoutOptions.Center
                
            };
			onColorSeletected();
			
			tagsCorStack.Children.Add(tagsCorIcone);
			tagsCorStack.Children.Add(_picker);
			tagsStack.Children.Add(tagsCorStack);
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

			_observacao = new Entry
			{
				Placeholder = "Observação",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = _width,
			};
			observacaoStack.Children.Add(observacaoIcone);
			observacaoStack.Children.Add(_observacao);

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
				Source = "ic_add_a_photo_black_48dp.png",
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
			fotoStack.Children.Add(_cupomFiscal);

			main.Children.Add(valorStack);
			main.Children.Add(dataStack);
			main.Children.Add(localStack);
			main.Children.Add(tipoCustoStack);
			main.Children.Add(tagsStack);
			//main.Children.Add(tagsCorStack);
			main.Children.Add(observacaoStack);
			main.Children.Add(fotoStack);
			main.Children.Add(stackButtons);

			scrollMain.Content = main;
			Content = scrollMain;
		}

		public void OnCancelar(Object sender, EventArgs e)
		{

		}
		

		public void onColorSeletected()
		{
		_tagInfo = new TagInfo();
			 Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
	        {
	            { "Aqua", Color.Aqua }, { "Preto", Color.Black },
	            { "Azul", Color.Blue }, { "Rosa", Color.Fuschia },
	            { "Cinza", Color.Gray }, { "Verde", Color.Green },
	            { "Limão", Color.Lime }, { "Marron", Color.Maroon },
	            { "Oceano", Color.Navy }, { "Oliva", Color.Olive },
	            { "Roxo", Color.Purple }, { "Vermelho", Color.Red },
	            { "Prata", Color.Silver }, { "Chá", Color.Teal },
	            { "Branco", Color.White }, { "Amarelo", Color.Yellow }
	        };
	        
		   

            foreach (string colorName in nameToColor.Keys)
            {
                _picker.Items.Add(colorName);
            }
            
            _picker.SelectedIndexChanged += (sender, args) =>
                {
                    if (_picker.SelectedIndex == -1)
                    {
                        
                        string colorName = _picker.Items[_picker.SelectedIndex];
                        _tag.TextColor = nameToColor[colorName];
						_tagInfo.Cor = colorName;
						
                    }
                    else
                    {
                        string colorName = _picker.Items[_picker.SelectedIndex];
                        _tag.TextColor = nameToColor[colorName];
						_tagInfo.Cor = colorName;
						//if (AoProcessar != null)							
                		//AoProcessar(this, new PegarCorPickerEventArgs(nameToColor[colorName], colorName));
                    }
                };
		

		}
		
		public void OnGravar(Object sender, EventArgs e)
		{
			TagBLL tagBLL = new TagBLL();
		
			if (_tagInfo.Descricao != null)
			{
				_tagInfo.Descricao = _tag.Text;
				tagBLL.gravar(_tagInfo);
			}
			
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

