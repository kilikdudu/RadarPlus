using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public static class Configuracao
    {
        public static int DistanciaRadar {
            get {
                return 500;
            }
        }

        public static int AnguloRadar
        {
            get
            {
                return 30;
            }
        }

        public static int AnguloCone
        {
            get
            {
                return 30;
            }
        }
    }
}
