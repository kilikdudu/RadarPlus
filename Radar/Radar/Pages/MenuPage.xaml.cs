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
                Icone = "velocimetro.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Mapa",
                Icone = "mapas.png",
                TargetType = typeof(MapaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Radares",
                Icone = "meusradares.png",
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
                Icone = "percurso.png",
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
                Icone = "preferencias.png",
				TargetType = typeof(PreferenciaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Atualizar",
                Icone = "atualizar.png",
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
                Icone = "instrucoes.png",
                TargetType = typeof(VelocimetroPage)
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
                TargetType = typeof(VelocimetroPage)
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
            paginas.Add(criarGrupoAplicativo());
            listView.ItemsSource = paginas;
        }
    }
}
