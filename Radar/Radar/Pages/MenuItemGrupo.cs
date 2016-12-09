using Radar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Pages
{
    public class MenuItemGrupo : List<MenuItemInfo>
    {
        public string Nome { get; private set; }
        public string NomeCurto { get; private set; }

        public MenuItemGrupo(string nome, string nomeCurto)
        {
            this.Nome = nome;
            this.NomeCurto = NomeCurto;
        }

        // Whatever other properties
    }
}
