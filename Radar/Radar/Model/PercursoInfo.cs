using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.BLL;

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
		public double DistanciaTotal { get; set; }

		[Ignore]
		public DateTime DataTitulo { get; set; }

		[Ignore]
		public String EnderecoDestino { get; set; }

		[Ignore]
		public int VelocidadeMedia { get; set; }

		[Ignore]
		public int VelocidadeMaxima { get; set; }

		[Ignore]
		public TimeSpan TempoParado { get; set; }

		[Ignore]
		public int QuantidadeRadar { get; set; }

		[Ignore]
		public int QuantidadeParada { get; set; }

        [Ignore]
        public TimeSpan TempoGravacao { get; set; }

        [Ignore]
        public string TempoGravacaoStr
        {
            get
            {
                TimeSpan tempo = TempoGravacao;
                return "Tempo: " + tempo.ToString();
            }
        }

		public string VelocidadeMediaStr
		{
			get
			{
				double velocidadeMedia = VelocidadeMedia;
				return "V Méd: " + velocidadeMedia.ToString()+ " Km/h ";
			}
		}

		public string VelocidadeMaximaStr
		{
			get
			{
				double velocidadeMaxima = VelocidadeMaxima;
				return "V Max: " + velocidadeMaxima.ToString() + " Km/h ";
			}
		}

		public string DataTituloStr
		{
			get
			{
				DateTime dataTitulo = DataTitulo;
				return dataTitulo.ToString("dd/MMM - HH:mm");
			}
		}

		public string TempoParadoStr
		{
			get
			{
				TimeSpan tempoParado = TempoParado;
				return "Parado: " + tempoParado.ToString();
			}
		}

		public string QuantidadeRadarStr
		{
			get
			{
				int quantidadeRadar = QuantidadeRadar;
				return "Radares: " + quantidadeRadar.ToString();
			}
		}

		public string QuantidadeParadaStr
		{
			get
			{
				int quantidadeParada = QuantidadeParada;
				return "Paradas: " + quantidadeParada.ToString();
			}
		}

		public string DistanciaTotalStr
		{
			get
			{
				double distanciaTotal = Math.Floor(DistanciaTotal / 1000);
				return  distanciaTotal.ToString() + " Km ";
			}
		}

		public string EnderecoStr
		{
			get
			{
				string endereco = EnderecoDestino;
				return endereco;
			}
		}
    }
}
