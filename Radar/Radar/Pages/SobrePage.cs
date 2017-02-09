using System;
using Radar.BLL;
using Xamarin.Forms;

namespace Radar
{
    public class SobrePage : ContentPage, IDisposable
    {
        Image _NavIconImage;
        Image _LogoClubImage;

        public SobrePage()
        {
            Title = "Sobre";

            inicializarComponente();

            Content = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
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
                                _NavIconImage,
                                new Label {
                                    Text = "Radar+",
                                    FontSize = 40,
                                    FontFamily = "Roboto-Condensed",
                                    HorizontalOptions = LayoutOptions.Center
                                },
                                new Label {
                                    Text = "Versão: 1.0.5",
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
                                _LogoClubImage
                            }
                        }
                    }
                }
            };
        }

        private void inicializarComponente() {
            _NavIconImage = new Image
            {
                Source = ImageSource.FromFile("navicon.png"),
                WidthRequest = 180,
                HorizontalOptions = LayoutOptions.Center
            };
            _LogoClubImage = new Image
            {
                Source = ImageSource.FromFile("logoclubmanagement.png"),
                WidthRequest = 200
            };
        }

        public void Dispose()
        {
            _NavIconImage.Source = null;
            _LogoClubImage.Source = null;
        }
    }
}
