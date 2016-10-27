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
                Icone = "contacts.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Mapa",
                Icone = "todo.png",
                TargetType = typeof(MapaPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Radares",
                Icone = "reminders.png",
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
                Icone = "radar.png",
                TargetType = typeof(PercursoPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Meus Radares",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Preferências",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Atualizar",
                Icone = "radar.png",
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
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Novidades",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sobre",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItemInfo
            {
                Titulo = "Sair",
                Icone = "radar.png",
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
