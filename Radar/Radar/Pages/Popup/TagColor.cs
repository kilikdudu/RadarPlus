using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClubManagement.Utils;
using Radar.Model;
using Radar.Utils;
using Radar.BLL;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Radar.Controls;

namespace Radar
{
	public class TagColor : PopupPage
	{
	 public PegarCorPickerEventHandle AoProcessar { get; set; }
		Dictionary<string, Color> nameToColor;
		public TagColor(PegarCorPickerEventHandle aoProcessar)
		{
		AoProcessar += aoProcessar;
			Label title = new Label
			{
				Text = "Escolha uma cor",
				TextColor = Color.FromHex(TemaInfo.PrimaryColor),
				FontSize = 25,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				Margin = new Thickness(10, 20, 0,0)
			};
			
			BoxView linha = new BoxView
			{
				BackgroundColor = Color.FromHex(TemaInfo.DividerColor),
				HeightRequest = 1
			};

			AbsoluteLayout main = new AbsoluteLayout
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};
			AbsoluteLayout.SetLayoutBounds(main, new Rectangle(0.5, 0.5, 0.8, 0.8));
			AbsoluteLayout.SetLayoutFlags(main, AbsoluteLayoutFlags.All);
			
			StackLayout lista = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White,
				Margin = new Thickness(0, 30, 0,0)
			};
			AbsoluteLayout.SetLayoutBounds(lista, new Rectangle(0.5, 0.5, 0.8, 0.75));
			AbsoluteLayout.SetLayoutFlags(lista, AbsoluteLayoutFlags.All);
			nameToColor = new Dictionary<string, Color>
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
			ListView listaCores = new ListView
			{
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(colorsCell)),
				SeparatorColor = Color.FromHex(TemaInfo.DividerColor),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				BindingContext = nameToColor,
			};
			listaCores.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaCores.ItemTapped += OnTap;
			
			Button cancelar = new Button
				{
					Text = "Cancelar",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor),
					BackgroundColor = Color.White,
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.End
				};
			cancelar.Clicked += OnCancelar;
			
			lista.Children.Add(title);
			lista.Children.Add(linha);
			lista.Children.Add(listaCores);
			lista.Children.Add(cancelar);
			main.Children.Add(lista);
			Content = main;

		}

		public void OnTap(Object sender, ItemTappedEventArgs e)
		{
		    var valores = (KeyValuePair<string, Color>)e.Item;
			
			 if (AoProcessar != null)
                AoProcessar(this, new PegarCorPickerEventArgs(valores.Value, valores.Key));
                PopupNavigation.PopAsync();
		}
		
		public void OnCancelar(Object sender, EventArgs e)
		{
			PopupNavigation.PopAsync();
		}

		public class colorsCell : ViewCell
		{
			public colorsCell()
			{
				StackLayout main = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Center,
					

				};
				Frame frameOuter = new Frame
				{
					HeightRequest = AbsoluteLayout.AutoSize,
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Center,
					HasShadow = false,
					Content = main

				};
				Label cor = new Label
				{
					FontSize = 20,
					FontFamily = "Roboto-Condensed"
				};
				cor.SetBinding(Label.TextProperty, new Binding("Key"));
			
				
				Tag tag = new Tag
				{
					TipoShape = TipoShape.Circle					
				};		
				tag.SetBinding(Tag.ColorProperty, new Binding("Value"));
				
				main.Children.Add(tag);
				main.Children.Add(cor);
				

				View = frameOuter;
			}
		}
	}
}
