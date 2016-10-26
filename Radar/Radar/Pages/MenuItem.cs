using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Radar.Pages
{
    public class MenuItem
    {
        public string Titulo { get; set; }
        public string Icone { get; set; }
        public Type TargetType { get; set; }

        public string TituloAbreviado
        {
            get
            {
                return Titulo;
            }
        }
    }
}
