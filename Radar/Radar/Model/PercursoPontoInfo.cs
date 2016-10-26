using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    [Table("percurso_ponto")]
    public class PercursoPontoInfo
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public int IdPercurso { get; set; }
        public DateTime Data { get; set; }
        public double Velocidade { get; set; }
        public bool Movimento { get; set; }
    }
}
