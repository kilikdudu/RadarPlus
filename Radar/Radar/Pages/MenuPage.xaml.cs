using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radar.Pages
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        private MenuItemGrupo criarGrupoModo() {
            var grupo = new MenuItemGrupo("MODO", "MODO");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Velocimetro",
                Icone = "icones/velocimetro.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Mapa",
                Icone = "icones/mapas.png",
                TargetType = typeof(MapaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Radares",
                Icone = "icones/reminders.png",
                TargetType = typeof(RadarListaPage)
            });
            return grupo;
        }

        private MenuItemGrupo criarGrupoAcao()
        {
            var grupo = new MenuItemGrupo("AÇÕES", "AÇÕES");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Percursos",
                Icone = "icones/percursos.png",
                TargetType = typeof(PercursoPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Meus Radares",
                Icone = "icones/radar.png",
                TargetType = typeof(RadarListaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Preferências",
                Icone = "icones/config.png",
				TargetType = typeof(PreferenciaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Atualizar",
                Icone = "icones/atualizar.png",
                TargetType = typeof(VelocimetroPage)
            });
            return grupo;
        }

        private MenuItemGrupo criarGrupoAplicativo()
        {
            var grupo = new MenuItemGrupo("APLICATIVO", "APPS");
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Instruções",
                Icone = "icones/instrucoes.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Novidades",
                Icone = "icones/novidade.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sobre",
                Icone = "icones/sobre.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sair",
                Icone = "icones/sair.png",
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
            paginas.Add(criarGrupoAplicativo());
            listView.ItemsSource = paginas;
        }
    }
}
