using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    [Table("percurso")]
    public class PercursoInfo
    {
        private IList<PercursoPontoInfo> _pontos = new List<PercursoPontoInfo>();

        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Ignore]
        public IList<PercursoPontoInfo> Pontos {
            get {
                return _pontos;
            }
            set {
                _pontos = value;
            }
        }

        [Ignore]
        public TimeSpan TempoGravacao {
            get {
                DateTime maiorTempo = (from p in _pontos select p.Data).Max();
                DateTime menorTempo = (from p in _pontos select p.Data).Min();
                return maiorTempo.Subtract(menorTempo);
            }
        }

        [Ignore]
        public string TempoGravacaoStr
        {
            get
            {
                TimeSpan tempo = TempoGravacao;
                return tempo.ToString("{0:hh\\:mm\\:ss}");
            }
        }
    }
}
