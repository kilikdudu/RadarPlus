using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Estilo
{
    public class PopupEstilo: BaseEstilo
    {
        private const string POPUP_ABSOLUTE_LAYOUT = "popup_absolute_layout";
        private const string POPUP_STACK_LAYOUT = "popup_stack_layout";
        private const string POPUP_TITULO = "popup_titulo";
        private const string POPUP_TEXTO = "popup_texto";
        private const string POPUP_LABEL = "popup_label";
        private const string POPUP_BUTTON = "popup_button";
        private const string POPUP_LINHA = "popup_linha";
        private const string POPUP_SWITCH = "popup_switch";
        private const string POPUP_FORM_CAMPO = "popup_form_campo";
        private const string POPUP_FORM_DESCRICAO = "popup_form_descricao";

        public Style MainAbsoluteLayout
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_ABSOLUTE_LAYOUT];
            }
        }

        public Style MainStackLayout
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_STACK_LAYOUT];
            }
        }

        public Style Titulo
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_TITULO];
            }
        }

        public Style Texto
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_TEXTO];
            }
        }

        public Style TextoPadrao
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_LABEL];
            }
        }

        public Style Botao
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_BUTTON];
            }
        }

        public Style Linha
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_LINHA];
            }
        }

        public Style CheckBox
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_SWITCH];
            }
        }

        public Style Campo
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_FORM_CAMPO];
            }
        }

        public Style Descricao
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_FORM_DESCRICAO];
            }
        }

        public override void inicializar(ResourceDictionary resources)
        {
            resources.Add(POPUP_ABSOLUTE_LAYOUT, new Style(typeof(AbsoluteLayout))
            {
                Setters = {
                    new Setter { Property = AbsoluteLayout.VerticalOptionsProperty, Value = LayoutOptions.Center },
                    new Setter { Property = AbsoluteLayout.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                    new Setter { Property = AbsoluteLayout.OpacityProperty, Value = 0 },
                    new Setter { Property = AbsoluteLayout.PaddingProperty, Value = new Thickness(20,20,20,20) },
                    new Setter { Property = AbsoluteLayout.HeightRequestProperty, Value = 240 }
                }
            });

            resources.Add(POPUP_STACK_LAYOUT, new Style(typeof(StackLayout))
            {
                Setters = {
                    new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = LayoutOptions.FillAndExpand },
                    new Setter { Property = StackLayout.BackgroundColorProperty, Value = Color.Transparent },
                    new Setter { Property = StackLayout.PaddingProperty, Value = new Thickness(0,10,0,0) }
                }
            });

            resources.Add(POPUP_TITULO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.StartAndExpand },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("#009688") },
                    new Setter { Property = Label.FontSizeProperty, Value = 26 },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" }
                }
            });

            resources.Add(POPUP_TEXTO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 20 },
                    new Setter { Property = Label.MarginProperty, Value = new Thickness(20,0,0,0) },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" }
                }
            });

            resources.Add(POPUP_BUTTON, new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = Button.HorizontalOptionsProperty, Value = LayoutOptions.End },
                    new Setter { Property = Button.TextColorProperty, Value = Color.FromHex("#009688") },
                    new Setter { Property = Button.FontFamilyProperty, Value = "Roboto-Condensed" },
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent },
                    new Setter { Property = Button.FontSizeProperty, Value = 20 }
                }
            });

            resources.Add(POPUP_LINHA, new Style(typeof(BoxView))
            {
                Setters = {
                    new Setter { Property = BoxView.HeightRequestProperty, Value = 1 },
                    new Setter { Property = BoxView.BackgroundColorProperty, Value = Color.FromHex("#bdbdbd") },
                }
            });

            resources.Add(POPUP_SWITCH, new Style(typeof(Switch))
            {
                Setters = {
                    new Setter { Property = Switch.HorizontalOptionsProperty, Value = LayoutOptions.End },
                    new Setter { Property = Switch.MarginProperty, Value = new Thickness(0, 0, 0, 20) }
                }
            });

            resources.Add(POPUP_FORM_CAMPO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 18 },
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                }
            });

            resources.Add(POPUP_FORM_DESCRICAO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 14 },
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                }
            });
        }
    }
}
