using System;
using Radar.BLL;
using Xamarin.Forms;

namespace Radar
{
	public class SobrePage : ContentPage
	{
        public SobrePage()
        {
            Title = "Sobre";
			Content = new ScrollView
			{ VerticalOptions = LayoutOptions.FillAndExpand,

				Content = new StackLayout
				{
					BackgroundColor = Color.White,
					Orientation = StackOrientation.Vertical,
					Children = {
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						HeightRequest = AbsoluteLayout.AutoSize,
						BackgroundColor = Color.White,
						Children = {
							new Image {
								Source = ImageSource.FromFile("navicon.png"),
								WidthRequest = 180,
								HorizontalOptions = LayoutOptions.Center
							},
							new Label {
								Text = "Radar+",
								FontSize = 40,
								FontFamily = "Roboto-Condensed",
								HorizontalOptions = LayoutOptions.Center
							},
							new Label {
								Text = "Versão: 1.0.0",
								FontSize = 25,
								FontFamily = "Roboto-Condensed",
								HorizontalOptions = LayoutOptions.Center
							}
						}
					},
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.Fill,
						VerticalOptions = LayoutOptions.Center,
						Children = {
							new Label {
								Text = "Desenvolvido Por",
								HorizontalOptions = LayoutOptions.Center
							},
							new Image {
								Source = ImageSource.FromFile("logoclubmanagement.png"),
								WidthRequest = 200
							}
						}
					}
				}
				}
			};

		}
	}
}
