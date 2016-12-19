using System;
using System.Collections.Generic;
using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.IBLL;
using Radar.Model;
using Radar.Utils;
using Xamarin.Forms;

namespace Radar
{
	public class TagPage : ContentPage
	{

		Entry _tag;
		double _width;
		Picker _picker;

		TagInfo _tagInfo;
		
		public TagPage()
		{
			Title = "Cadastro de tags";
			
			AbsoluteLayout listaView = new AbsoluteLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
			
			
            TagBLL regraTag = TagFactory.create();
            var tags = regraTag.listar();
            
			ListView listaTags = new ListView();
			//listaTags.RowHeight = 120;
			listaTags.ItemTemplate = new DataTemplate(typeof(TagsCelula));
			//listaTags.ItemTapped += OnTap;
			listaTags.ItemsSource = tags;
			listaTags.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaTags.HasUnevenRows = true;
			listaTags.SeparatorColor = Color.Transparent;
			listaTags.VerticalOptions = LayoutOptions.Fill;
			listaTags.HorizontalOptions = LayoutOptions.Center;
			AbsoluteLayout.SetLayoutBounds(listaTags, new Rectangle(0, 0.2, 1, 0.8));
			AbsoluteLayout.SetLayoutFlags(listaTags, AbsoluteLayoutFlags.All);

			listaTags.BindingContext = tags;
			
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
			
			
			StackLayout stackButtons = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End
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
			


			listaView.Children.Add(tagsStack);
			listaView.Children.Add(listaTags);

			listaView.Children.Add(stackButtons);

			scrollMain.Content = main;
			Content = listaView;
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
		
		public class TagsCelula : ViewCell
		{

			public TagsCelula()
			{

				var excluirTag = new MenuItem
				{
					Text = "Excluir"
				};

				excluirTag.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirTag.Clicked += (sender, e) =>
				{
					TagInfo tag = (TagInfo)((MenuItem)sender).BindingContext;
					TagBLL regraTag = TagFactory.create();
					regraTag.excluir(tag.Id);

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
				frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
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

				main.Children.Add(descricao);

				frameOuter.Content = main;

				View = frameOuter;

			}


		}
		
		
	}
}

