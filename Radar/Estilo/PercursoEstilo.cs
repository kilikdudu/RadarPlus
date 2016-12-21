using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Estilo
{
    public class PercursoEstilo: BaseEstilo
    {
        private const string PERCURSO_GRAVAR_STACKLAYOUT_MAIN = "percurso_gravar_stacklayout_main";
        private const string PERCURSO_GRAVAR_STACKLAYOUT_INTERNO = "percurso_gravar_stacklayout_interno";
        private const string PERCURSO_GRAVAR_IMAGEM = "percurso_gravar_imagem";
        private const string PERCURSO_GRAVAR_TITULO = "percurso_gravar_titulo";
        private const string PERCURSO_GRAVAR_DESCRICAO = "percurso_gravar_descricao";

        public Style GravarStackLayoutMain
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_STACKLAYOUT_MAIN];
            }
        }

        public Style GravarStackLayoutInterno
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_STACKLAYOUT_INTERNO];
            }
        }

        public Style GravarImagem
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_IMAGEM];
            }
        }

        public Style GravarTitulo
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_TITULO];
            }
        }

        public Style GravarDescricao
        {
            get
            {
                return (Style)App.Current.Resources[PERCURSO_GRAVAR_DESCRICAO];
            }
        }

        public override void inicializar(ResourceDictionary resources)
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
    }
}
