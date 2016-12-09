using ClubManagement.Utils;
using Radar.Controls;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Radar.Pages.Popup;

namespace Radar.Pages
{
    public class MenuPage: ContentPage
    {
        ListView _listView;

        public ListView ListView {
            get {
                return _listView;
            }
        }

        public MenuPage()
        {
            Title = "Radar";

            inicializarComponente();

            BackgroundColor = Color.FromHex("#ffffff");
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(5, 5, 5, 5),
                BackgroundColor = Color.Transparent,
                Children = {
                    new Image {
                        Source = "navicon.png",
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        WidthRequest = 80,
                        HeightRequest = 80
                    },
                    _listView
                }
            };


        }

        private void inicializarComponente() {
            var paginas = new List<MenuItemGrupo>();
            paginas.Add(criarGrupoModo());
            paginas.Add(criarGrupoAcao());
            paginas.Add(criarGrupoAplicativo());

			_listView = new ListView
			{
				GroupDisplayBinding = new Binding("Nome"),
				HasUnevenRows = false,
                SeparatorVisibility = SeparatorVisibility.Default,
                IsGroupingEnabled = true,
                BackgroundColor = Color.Transparent,
                SeparatorColor = Color.FromHex("#bdbdbd"),
                GroupHeaderTemplate = new DataTemplate(typeof(MenuGrupoCell)),
                ItemTemplate = new DataTemplate(typeof(MenuItemCell))
            };
            _listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            _listView.ItemsSource = paginas;
            _listView.ItemTapped += (sender, e) => {
                MenuItemInfo item = (MenuItemInfo)e.Item;
                if (item.aoClicar != null) {
                    if (this.Navigation.NavigationStack.Count == 1) {
                        item.aoClicar(sender, new MenuEventArgs(this));
                    }
                }
            };

			_listView.Footer = new Label()
			{
				Text = ""
			};
        }

        private MenuItemGrupo criarGrupoModo()
        {
            var grupo = new MenuItemGrupo("MODO", "MODO");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Velocimetro",
                Icone = "velocimetro.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new VelocimetroPage());
                }
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Mapa",
                Icone = "mapas.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new MapaPage());
                }
            });
            return grupo;
        }

        private MenuItemGrupo criarGrupoAcao()
        {
            var grupo = new MenuItemGrupo("AÇÕES", "AÇÕES");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Percursos",
                Icone = "percursos.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new PercursoPage());
                }
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Meus Radares",
                Icone = "meusradares.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new RadarListaPage());
                }
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Preferências",
                Icone = "config.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new PreferenciaPage());
                }
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Atualizar",
                Icone = "atualizar.png",
                aoClicar = (sender, e) =>
                {
                    var downloader = new DownloaderAtualizacao();
                    downloader.download();
                }
            });
            return grupo;
        }

        private MenuItemGrupo criarGrupoAplicativo()
        {

            var grupo = new MenuItemGrupo("APLICATIVO", "APPS");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Instruções",
                Icone = "instrucoes.png",
                aoClicar = (sender, e) =>
                {
					NavigationX.create(this).PushPopupAsyncX(new InstrucaoPopUp());
                }
            });
            /*
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Novidades",
                Icone = "novidade.png",
                TargetType = typeof(VelocimetroPage)
            });
            */
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sobre",
                Icone = "sobre.png",
                aoClicar = (sender, e) => {
                    NavegacaoUtils.PushAsync(new SobrePage());
                }
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sair",
                Icone = "sair.png",
                aoClicar = (sender, e) =>
                {
                    ThreadUtils.closeApplication();
                }
            });
            return grupo;
        }

        public class MenuGrupoCell : ViewCell {

            public MenuGrupoCell() {
                var tituloLabel = new Label {
                    FontSize = 22,
                    FontFamily = "Roboto-Condensed",
                    TextColor = Color.FromHex("#009688"),
                    BackgroundColor = Color.Transparent
                };
                tituloLabel.SetBinding(Label.TextProperty, new Binding("Nome"));
                View = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.Transparent,
                    Margin = new Thickness(0,10,0,10),
                    Children = {
                        tituloLabel,
                        new BoxView {
                            HeightRequest = 5,
                            BackgroundColor = Color.FromHex("#009688")
                        }
                    }
                };
            }
        }

        public class MenuItemCell : ViewCell {

            public MenuItemCell() {
				
                var imagemLabel = new Image {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 40,
					HeightRequest = 40,
                    //Margin = new Thickness(0,0,0,0)
                };
                imagemLabel.SetBinding(Image.SourceProperty, new Binding("Icone"));
                var tituloLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 18,
                    FontFamily = "Roboto-Condensed",
                    //Margin = new Thickness(0,0,0,0)
                };
                tituloLabel.SetBinding(Label.TextProperty, new Binding("Titulo"));
				View = new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							BackgroundColor = Color.Transparent,
							VerticalOptions = LayoutOptions.Fill,
							//Margin = new Thickness(10, 10, 10, 10),
							Children = {
								imagemLabel,
								tituloLabel
							}
						};
                        
            }

        }
    }
}
