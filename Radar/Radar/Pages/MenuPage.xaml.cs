using ClubManagement.Utils;
using Radar.BLL;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Rg.Plugins.Popup;

namespace Radar.Pages
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get {

				return listView; } }

        private MenuItemGrupo criarGrupoModo() {
            var grupo = new MenuItemGrupo("MODO", "MODO");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Velocimetro",
                Icone = "velocimetro.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Mapa",
                Icone = "mapas.png",
                TargetType = typeof(MapaPage)

            });
			/*
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Radares",
                Icone = "meusradares.png",
                TargetType = typeof(RadarListaPage)
            });*/
            return grupo;
        }

        private MenuItemGrupo criarGrupoAcao()
        {
            var grupo = new MenuItemGrupo("AÇÕES", "AÇÕES");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Percursos",
                Icone = "percursos.png",
                TargetType = typeof(PercursoPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Meus Radares",
                Icone = "meusradares.png",
                TargetType = typeof(RadarListaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Preferências",
                Icone = "config.png",
				TargetType = typeof(PreferenciaPage)
            });
            var menuAtualizar = new MenuItemInfo
            {
                Titulo = "Atualizar",
                Icone = "atualizar.png",
                TargetType = null,
            };
            menuAtualizar.aoClicar += (sender, e) =>
            {
                //var downloader = new DownloaderUtils();
                //downloader.download(Configuracao.UrlAtualizacao);
            };
            grupo.Add(menuAtualizar);
            return grupo;
        }

        private MenuItemGrupo criarGrupoAplicativo()
        {
			
            var grupo = new MenuItemGrupo("APLICATIVO", "APPS");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Instruções",
                Icone = "instrucoes.png",
				TargetType = null,
				aoClicar = (sender, e) =>
				{
					//this.Navigation.PushAsync(new ModoAutoInicioPage());
					//Navigation.PushModalAsync(new MapaPage(true));

						Application.Current.MainPage = new NavegacaoPage(true);


				}
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Novidades",
                Icone = "novidade.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sobre",
                Icone = "sobre.png",
				TargetType = typeof(SobrePage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sair",
                Icone = "sair.png",
                TargetType = typeof(VelocimetroPage)
            });
            return grupo;
        }

        public MenuPage()
        {
            InitializeComponent();

            Title = "Radar";

            var paginas = new List<MenuItemGrupo>();
            paginas.Add(criarGrupoModo());
            paginas.Add(criarGrupoAcao());
			ListView.ItemTapped += OnTap;
            paginas.Add(criarGrupoAplicativo());

            listView.ItemsSource = paginas;
        }
		public void OnTap(object sender, ItemTappedEventArgs e)
		{

			MenuItemInfo item = (MenuItemInfo)e.Item;
			if (item.aoClicar != null)
			{
				if (this.Navigation.NavigationStack.Count == 1)
				{
					item.aoClicar(sender, e);
				}
			}

		}
    }
}
