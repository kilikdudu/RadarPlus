using Radar.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Popup
{
    public abstract class BaseListaPopup : BasePopup
    {
        Button _FecharButton;

        protected abstract string getTitulo();
        public abstract View inicializarConteudo();
        protected virtual string getFechar()
        {
            return "Sair";
        }

        protected override void inicializarComponente()
        {
            _FecharButton = new Button
            {
                Style = EstiloUtils.PopupButton,
                Text = getFechar(),
            };
            _FecharButton.Clicked += (sender, e) => {
                PopupNavigation.PopAsync();
            };
        }

        protected override View inicializarTela()
        {
            return new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    criarTitulo(getTitulo()),
                    criarLinha(),
                    new ScrollView {
                        Orientation = ScrollOrientation.Vertical,
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        Content = inicializarConteudo()
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children = {
                            _FecharButton
                        }
                    }
                }
            };
        }
    }
}
