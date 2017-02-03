using Radar.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Utils
{
    public static class GlobalUtils
    {
        private static bool _AplicativoEstaAberto = false;

        public static BaseVisualPage Visual { get; set; }

        public static bool AplicativoEstaAberto {
            get {
                return _AplicativoEstaAberto;
            }
            set {
                _AplicativoEstaAberto = value;
            }
        }
    }
}
