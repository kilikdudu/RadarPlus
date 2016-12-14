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

        private static string POPUP_ABSOLUTE_LAYOUT = "popup_absolute_layout";
        private static string POPUP_STACK_LAYOUT = "popup_stack_layout";
        private static string POPUP_TITULO = "popup_titulo";
        private static string POPUP_TEXTO = "popup_texto";
        private static string POPUP_LABEL = "popup_label";
        private static string POPUP_BUTTON = "popup_button";
        private static string POPUP_LINHA = "popup_linha";
        private static string POPUP_SWITCH = "popup_switch";
        private static string POPUP_FORM_CAMPO = "popup_form_campo";
        private static string POPUP_FORM_DESCRICAO = "popup_form_descricao";

        private static string PERCURSO_GRAVAR_STACKLAYOUT_MAIN = "percurso_gravar_stacklayout_main";
        private static string PERCURSO_GRAVAR_STACKLAYOUT_INTERNO = "percurso_gravar_stacklayout_interno";
        private static string PERCURSO_GRAVAR_IMAGEM = "percurso_gravar_imagem";
        private static string PERCURSO_GRAVAR_TITULO = "percurso_gravar_titulo";
        private static string PERCURSO_GRAVAR_DESCRICAO = "percurso_gravar_descricao";

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

        public static Style PopupAbsoluteLayout
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_ABSOLUTE_LAYOUT];
            }
        }

        public static Style PopupStackLayout
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_STACK_LAYOUT];
            }
        }

        public static Style PopupTitulo
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_TITULO];
            }
        }

        public static Style PopupTexto
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_TEXTO];
            }
        }

        public static Style PopupLabel
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_LABEL];
            }
        }

        public static Style PopupButton
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_BUTTON];
            }
        }

        public static Style PopupLinha
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_LINHA];
            }
        }

        public static Style PopupSwitch
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_SWITCH];
            }
        }

        public static Style PopupCampo
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_FORM_CAMPO];
            }
        }

        public static Style PopupDescricao
        {
            get
            {
                return (Style)App.Current.Resources[POPUP_FORM_DESCRICAO];
            }
        }

        public static Style PercursoGravarStackLayoutMain {
            get {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_STACKLAYOUT_MAIN];
            }
        }

        public static Style PercursoGravarStackLayoutInterno
        {
            get {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_STACKLAYOUT_INTERNO];
            }
        }

        public static Style PercursoGravarImagem
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_IMAGEM];
            }
        }

        public static Style PercursoGravarTitulo
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_TITULO];
            }
        }

        public static Style PercursoGravarDescricao
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_DESCRICAO];
            }
        }

        public static void inicializarPopup(ResourceDictionary resources) {

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

        private static void inicializarPreferencia(ResourceDictionary resources) {
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

        private static void inicializarPercurso(ResourceDictionary resources)
        {
            resources.Add(PERCURSO_GRAVAR_STACKLAYOUT_MAIN, new Style(typeof(StackLayout))
            {
                Setters = {
                    new Setter { Property = StackLayout.OrientationProperty, Value = StackOrientation.Horizontal },
                    new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = LayoutOptions.CenterAndExpand },
                    new Setter { Property = StackLayout.VerticalOptionsProperty, Value = LayoutOptions.EndAndExpand },
                    new Setter { Property = StackLayout.MarginProperty, Value = new Thickness(30, 30, 30, 40) }
                }
            });
            resources.Add(PERCURSO_GRAVAR_STACKLAYOUT_INTERNO, new Style(typeof(StackLayout))
            {
                Setters = {
                    new Setter { Property = StackLayout.OrientationProperty, Value = StackOrientation.Vertical },
                    new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = LayoutOptions.CenterAndExpand },
                    new Setter { Property = StackLayout.VerticalOptionsProperty, Value = LayoutOptions.EndAndExpand }
                }
            });
            resources.Add(PERCURSO_GRAVAR_IMAGEM, new Style(typeof(Image))
            {
                Setters = {
                    new Setter { Property = Image.WidthRequestProperty, Value = 60 },
                    new Setter { Property = Image.HorizontalOptionsProperty, Value = LayoutOptions.End },
                    new Setter { Property = Image.VerticalOptionsProperty, Value = LayoutOptions.Center },
                }
            });

            resources.Add(PERCURSO_GRAVAR_TITULO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.FontSizeProperty, Value = 24 },
                    new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" },
                    new Setter { Property = Label.BackgroundColorProperty, Value = Color.Transparent },
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Start },
                    new Setter { Property = Label.VerticalOptionsProperty, Value = LayoutOptions.Center }
                }
            });

            resources.Add(PERCURSO_GRAVAR_DESCRICAO, new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = Label.FontSizeProperty, Value = 18 },
                    new Setter { Property = Label.FontFamilyProperty, Value = "Roboto-Condensed" },
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Start },
                    new Setter { Property = Label.VerticalOptionsProperty, Value = LayoutOptions.Center }
                }
            });
        }

        public static void inicializar() {
            var resources = new ResourceDictionary();
            inicializarPreferencia(resources);
            inicializarPopup(resources);
            inicializarPercurso(resources);
            App.Current.Resources = resources;
        }
    }
}
