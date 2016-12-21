using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Radar.Model
{
    public class MenuItemInfo
    {
        public string Titulo { get; set; }
		public bool IsInstrucaoPopUp { get; set; }
        public string Icone { get; set; }
        public MenuEventHandler aoClicar { get; set; }

        public string TituloAbreviado
        {
            get
            {
                return Titulo;
            }
        }
	}

    public class MenuEventArgs : EventArgs {

        public Page Page { get; set; }

        public MenuEventArgs(Page page) {
            this.Page = page;
        }
    }

    public delegate void MenuEventHandler(object sender, MenuEventArgs e);
}
