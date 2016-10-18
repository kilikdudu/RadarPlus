using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    public class LocalizacaoInfo
    {
        public LocalizacaoInfo(double latitude, double longitude, float precisao, float sentido, double velocidade, long tempo) {
            Latitude = latitude;
            Longitude = longitude;
            Precisao = precisao;
            Sentido = sentido;
            Velocidade = velocidade;
            Tempo = tempo;
        }

        public LocalizacaoInfo(double latitude, double longitude, float precisao, float sentido, double velocidade) : this(latitude, longitude, precisao, sentido, velocidade, 0)
        {
        }

        public LocalizacaoInfo() : this(0, 0, 0, 0, 0, 0)
        {
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Precisao { get; set; }
        public float Sentido { get; set; }
        /// <summary>
        /// Velocidade em Km/h
        /// </summary>
        public double Velocidade { get; set; }
        public long Tempo { get; set; }
    }
}
