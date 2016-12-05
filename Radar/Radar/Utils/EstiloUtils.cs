using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
    public static class EstiloUtils
    {
        private static string PREFERENCIA_STACK = "preferencia_stack";
        private static string PREFERENCIA_TITULO = "preferencia_titulo";
        private static string PREFERENCIA_DESCRICAO = "preferencia_descricao";
        private static string PREFERENCIA_SWITCH = "preferencia_switch";
        private static string PREFERENCIA_FRAME = "preferencia_frame";

        public static Style PreferenciaStack {
            get {
                return (Style)App.Current.Resources[PREFERENCIA_STACK];
            }
        }

        public static Style PreferenciaFrame {
            get {
                return (Style)App.Current.Resources[PREFERENCIA_FRAME];
            }
        }

        public static Style PreferenciaTitulo {
            get {
                return (Style)App.Current.Resources[PREFERENCIA_TITULO];
            }
        }

        public static Style PreferenciaDescricao {
            get {
                return (Style)App.Current.Resources[PREFERENCIA_DESCRICAO];
            }
        }

        public static Style PreferenciaSwitch {
            get {
                return (Style)App.Current.Resources[PREFERENCIA_SWITCH];
            }
        }

        public static void inicializar() {
            var resources = new ResourceDictionary();
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
                    new Setter { Property = Switch.HorizontalOptionsProperty, Value = LayoutOptions.EndAndExpand },
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
            App.Current.Resources = resources;
        }
    }
}
