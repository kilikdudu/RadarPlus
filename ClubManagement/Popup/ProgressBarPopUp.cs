using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Popup
{
    public class ProgressBarPopUp: PopupPage
    {
        ProgressBar _barraProgresso;

        public ProgressBarPopUp() {

            inicializarComponente();

            var div = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(0, 10, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    _barraProgresso
                }
            };
            AbsoluteLayout.SetLayoutBounds(div, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(div, AbsoluteLayoutFlags.All);

            Content = new AbsoluteLayout {
                Padding = 20,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 240,
                Children = { div }
            };
        }

        private void inicializarComponente() {
            _barraProgresso = new ProgressBar();
        }

    }
}
