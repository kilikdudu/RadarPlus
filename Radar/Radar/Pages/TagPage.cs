using System;
using System.Collections.Generic;
using ClubManagement.Utils;
using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.IBLL;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class TagPage : ContentPage
	{

		Entry _tag;
		double _width;
		Picker _picker;

		TagInfo _tagInfo = new TagInfo();
		TagBLL _regraTag;
		ListView _listaTags;

		public TagPage()
		{
			Title = "Cadastro de tags";

			StackLayout listaView = new StackLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;

			_regraTag = TagFactory.create();
			var tags = _regraTag.listar();

			_listaTags = new ListView();
			//listaTags.RowHeight = 120;
			_listaTags.ItemTemplate = new DataTemplate(typeof(TagsCelula));
			//listaTags.ItemTapped += OnTap;
			_listaTags.ItemsSource = tags;
			_listaTags.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			_listaTags.HasUnevenRows = true;
			_listaTags.SeparatorColor = Color.Transparent;
			_listaTags.VerticalOptions = LayoutOptions.FillAndExpand;
			_listaTags.HorizontalOptions = LayoutOptions.Center;


			_listaTags.BindingContext = tags;

			if (TelaUtils.Orientacao == "Landscape")
			{
				_width = (int)TelaUtils.LarguraSemPixel * 0.5;
			}
			else {
				_width = (int)TelaUtils.LarguraSemPixel * 0.8;
			}

			StackLayout main = new StackLayout();
			main.BackgroundColor = Color.Transparent;
			main.Orientation = StackOrientation.Vertical;
			main.VerticalOptions = LayoutOptions.StartAndExpand;
			main.HorizontalOptions = LayoutOptions.CenterAndExpand;

			StackLayout tagsStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Start,
				Margin = new Thickness(10, 10, 10, 10)

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
				WidthRequest = _width - 30,
			};

			tagsStack.Children.Add(tagsIcone);
			tagsStack.Children.Add(_tag);

			StackLayout tagsCorStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Fill
			};

			Image tagsCorIcone = new Image()
			{
				Source = "ic_color_lens_black_24dp.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};
			
			tagsCorIcone.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
							NavigationX.create(this).PushPopupAsyncX(new TagColor((sender, e) => {
							_tag.TextColor = e.corPicker;
							_tagInfo.Cor = e.corTexto;

							}), true);
						}
					)
					});

			tagsCorStack.Children.Add(tagsCorIcone);
			//tagsCorStack.Children.Add(_picker);
			tagsStack.Children.Add(tagsCorStack);


			StackLayout stackButtons = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End,
				Margin = new Thickness (0,0,0,20)
			};
			Button gravar = new Button()
			{
				Text = "Gravar",
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End,
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
				VerticalOptions = LayoutOptions.End,
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontFamily = "Roboto-Condensed",
				BackgroundColor = Color.Transparent,
				FontSize = 20
			};
			cancelar.Clicked += OnCancelar;

			stackButtons.Children.Add(cancelar);
			stackButtons.Children.Add(gravar);

			listaView.Children.Add(tagsStack);
			listaView.Children.Add(_listaTags);

			listaView.Children.Add(stackButtons);


			Content = listaView;
		}

		public void OnCancelar(Object sender, EventArgs e)
		{
			NavegacaoUtils.PushAsync(new VelocimetroPage());

		}

		public void OnGravar(Object sender, EventArgs e)
		{

			TagInfo tagInfo = new TagInfo();
			if (_tag.Text != null)
			{
				tagInfo.Descricao = _tag.Text;
				tagInfo.Cor = _tagInfo.Cor;
				_regraTag.gravar(tagInfo);
				_listaTags.BindingContext = _regraTag.listar();
			}

		}

		public class TagsCelula : ViewCell
		{
			TagInfo _tag;
			TagBLL regraTag = TagFactory.create();

			public TagsCelula()
			{
				var excluirTag = new MenuItem
				{
					Text = "Excluir"
				};

				excluirTag.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirTag.Clicked += (sender, e) =>
				{
					_tag = (TagInfo)((MenuItem)sender).BindingContext;

					regraTag.excluir(_tag.Id);

					ListView listaTags = this.Parent as ListView;

					listaTags.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					//listaTags.RowHeight = 120;
					var tags = regraTag.listar();
					listaTags.BindingContext = tags;
					listaTags.ItemTemplate = new DataTemplate(typeof(TagsCelula));
				};
				ContextActions.Add(excluirTag);

				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Horizontal;
				main.VerticalOptions = LayoutOptions.CenterAndExpand;
				main.HorizontalOptions = LayoutOptions.StartAndExpand;

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
				Tag tag = new Tag()
				{
					TipoShape = TipoShape.Circle
				};

				tag.SetBinding(Tag.ColorProperty, new Binding("Cor", converter: new ColorConverter()));
				
				//frameOuter.BackgroundColor = nameToColor[_tag.Cor];
				//frameOuter.SetBinding(View.BackgroundColorProperty, new Binding("Cor", converter: new ColorConverter()));
				frameOuter.HeightRequest = AbsoluteLayout.AutoSize;
				if (Device.OS == TargetPlatform.iOS)
				{

					//frameOuter.Padding = new Thickness(5, 10, 5, 10);
					frameOuter.WidthRequest = TelaUtils.Largura * 0.9;
					frameOuter.Margin = new Thickness(5, 10, 5, 0);

				}
				else {
					frameOuter.Margin = new Thickness(5, 10, 5, 10);
				}

				
				main.Children.Add(tag);
				main.Children.Add(descricao);

				frameOuter.Content = main;

				View = frameOuter;

			}			
			
			public class ColorConverter : IValueConverter
			{
				public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
				{

					Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
				{
					{ "Aqua", Color.Aqua }, { "Preto", Color.Black },
					{ "Azul", Color.Blue }, { "Rosa", Color.Fuschia },
					{ "Cinza", Color.Gray }, { "Verde", Color.Green },
					{ "Limão", Color.Lime }, { "Marron", Color.Maroon },
					{ "Oceano", Color.Navy }, { "Oliva", Color.Olive },
					{ "Roxo", Color.Purple }, { "Vermelho", Color.Red },
					{ "Prata", Color.Silver }, { "Chá", Color.Teal },
				    { "Amarelo", Color.Yellow }
				};
					if(value != null){
						return nameToColor[value.ToString()];
					}
					return Color.Gray;

				}

				public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
				{
					// You probably don't need this, this is used to convert the other way around
					// so from color to yes no or maybe
					throw new NotImplementedException();
				}
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

