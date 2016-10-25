using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public static class Configuracao
    {
        public static double DistanciaRadar {
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
                return 45;
            }
        }

        public static int GPSTempoAtualiazacao {
            get {
                return 1000;
            }
        }

        public static int GPSDistanciaAtualizacao {
            get {
                return 0;
            }
        }

        public static double GPSDeltaMax
        {
            get
            {
                return 0.014;
            }
        }

        public static double GPSDeltaPadrao
        {
            get
            {
                return 0.008;
            }
        }

        public static float MapaZoom {
            get
            {
                return 18;
            }
        }

        public static float MapaTilt
        {
            get
            {
                return 65;
            }
        }
    }
}
