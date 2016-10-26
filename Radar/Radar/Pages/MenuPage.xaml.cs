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
            grupo.Add(new MenuItem
            {
                Titulo = "Velocimetro",
                Icone = "contacts.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
            {
                Titulo = "Mapa",
                Icone = "todo.png",
                TargetType = typeof(MapaPage)
            });
            grupo.Add(new MenuItem
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
            grupo.Add(new MenuItem
            {
                Titulo = "Meus Radares",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
            {
                Titulo = "Preferências",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
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
            grupo.Add(new MenuItem
            {
                Titulo = "Instruções",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
            {
                Titulo = "Novidades",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
            {
                Titulo = "Sobre",
                Icone = "radar.png",
                TargetType = typeof(VelocimetroPage)
            });
            grupo.Add(new MenuItem
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
