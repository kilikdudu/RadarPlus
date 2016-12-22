using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    public class PercursoResumoInfo
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Tempo { get; set; }
        public double Distancia { get; set; }
    }
}
