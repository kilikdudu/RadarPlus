using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Estilo
{
    public class PreferenciaEstilo: BaseEstilo
    {
        private const string PREFERENCIA_STACK = "preferencia_stack";
        private const string PREFERENCIA_TITULO = "preferencia_titulo";
        private const string PREFERENCIA_DESCRICAO = "preferencia_descricao";
        private const string PREFERENCIA_SWITCH = "preferencia_switch";
        private const string PREFERENCIA_FRAME = "preferencia_frame";

        public Style MainStackLayout
        {
            get
            {
                return (Style)App.Current.Resources[PREFERENCIA_STACK];
            }
        }

        public Style MainFrame
        {
            get
            {
                return (Style)App.Current.Resources[PREFERENCIA_FRAME];
            }
        }

        public Style Titulo
        {
            get
            {
                return (Style)App.Current.Resources[PREFERENCIA_TITULO];
            }
        }

        public Style Descricao
        {
            get
            {
                return (Style)App.Current.Resources[PREFERENCIA_DESCRICAO];
            }
        }

        public Style Checkbox
        {
            get
            {
                return (Style)App.Current.Resources[PREFERENCIA_SWITCH];
            }
        }

        public override void inicializar(ResourceDictionary resources)
        {
            resources.Add(PREFERENCIA_TITULO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.StartAndExpand },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("#757575") },
                    new Setter { Property = Label.FontSizeProperty, Value = 26 },
                    new Setter { Property = Label.MarginProperty, Value = new Thickness(20,0,0,0) },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" }
                }
            });
            resources.Add(PREFERENCIA_DESCRICAO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.StartAndExpand },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("#757575") },
                    new Setter { Property = Label.FontSizeProperty, Value = 14 },
                    new Setter { Property = Label.MarginProperty, Value = new Thickness(20,0,0,0) },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" }
                }
            });
            resources.Add(PREFERENCIA_STACK, new Style(typeof(StackLayout))
            {
                Setters = {
                    new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = LayoutOptions.FillAndExpand },
                    new Setter { Property = StackLayout.BackgroundColorProperty, Value = Color.FromHex("#ffffff") },
                    new Setter { Property = StackLayout.OrientationProperty, Value = StackOrientation.Vertical }
                }
            });
            resources.Add(PREFERENCIA_SWITCH, new Style(typeof(Switch))
            {
                Setters = {
                    new Setter { Property = Switch.HorizontalOptionsProperty, Value = LayoutOptions.End },
                    new Setter { Property = Switch.MarginProperty, Value = new Thickness(0,0,20,0) }
                }
            });
            resources.Add(PREFERENCIA_FRAME, new Style(typeof(Frame))
            {
                Setters = {
                    new Setter { Property = Frame.BackgroundColorProperty, Value = Color.FromHex("#b2dfdb") },
                    new Setter { Property = Frame.MarginProperty, Value = new Thickness(10,5,10,5) }
                }
            });
        }
    }
}
