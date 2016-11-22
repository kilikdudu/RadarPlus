using Radar.DALFactory;
using Radar.IDAL;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.Factory;

namespace Radar.BLL
{
    public class PercursoBLL
    {
        private IPercursoDAL _percursoDB;
        private IPercursoPontoDAL _pontoDB;

        private const int TEMPO_ATUALIZACAO_PONTO = 5;
        private const int TEMPO_MINIMO_PARADO = 120;
        private const int VELOCIDADE_MAXIMA_PARADO = 3;//3;

        private static PercursoInfo _percursoAtual;
        private static bool _gravando = false;
        private static DateTime _dataAnterior;
        private static DateTime _ultimoMovimentoReal;
        private static bool _emMovimento = true;

        public static bool Gravando {
            get {
                return _gravando;
            }
            private set {
                _gravando = value;
            }
        }

        public static PercursoInfo PercursoAtual {
            get {
                return _percursoAtual;
            }
            private set {
                _percursoAtual = value;
            }
        }

        public PercursoBLL()
        {
            _percursoDB = PercursoDALFactory.create();
            _pontoDB = PercursoPontoDALFactory.create();
        }

        private void atualizar(PercursoInfo percurso) {
            if (percurso != null)
            {
                var pontos = _pontoDB.listar(percurso.Id);
                if (pontos.Count() > 0)
                {
                    DateTime maiorTempo = (from p in pontos select p.Data).Max();
                    DateTime menorTempo = (from p in pontos select p.Data).Min();
                    percurso.TempoGravacao = maiorTempo.Subtract(menorTempo);
                }
                percurso.Pontos = pontos;
				percurso.DataTitulo = dataTitulo(percurso);
				percurso.EnderecoDestino = enderecoDestino(percurso);
				percurso.DistanciaTotal = distanciaTotal(percurso);
				percurso.VelocidadeMedia = velocidadeMedia(percurso);
				percurso.VelocidadeMaxima = velocidadeMaxima(percurso);
				percurso.QuantParadas = "Paradas: " + 0;
				percurso.QuantRadares = "Radares: " + 0;
				percurso.TempoParado = "Parado: " + TEMPO_MINIMO_PARADO;
            }
        }

        public IList<PercursoInfo> listar() {
            IList<PercursoInfo> percursos = _percursoDB.listar();
            foreach (PercursoInfo percurso in percursos) {
                atualizar(percurso);
            }
            return percursos;
        }

        public PercursoInfo pegar(int id) {
            PercursoInfo percurso = _percursoDB.pegar(id);
            atualizar(percurso);
            return percurso;
        }

        public int gravar(PercursoInfo percurso) {
            //percurso.Id = _percursoDB.gravar(percurso);
            return _percursoDB.gravar(percurso);
            //return percurso.Id;
        }

        public int gravarPonto(PercursoPontoInfo ponto) {
            return _pontoDB.gravar(ponto);
        }

        public bool iniciarGravacao() {
            if (_gravando)
                return false;
            PercursoInfo percurso = new PercursoInfo();
            percurso.Nome = "Teste";
            gravar(percurso);
            PercursoAtual = percurso;
            _dataAnterior = DateTime.MinValue;
            _ultimoMovimentoReal = DateTime.MinValue;
            _gravando = true;
            _emMovimento = true;
            //MensagemUtils.notificar(2, "Gravando Percurso", "Gravando percurso agora!");
            return true;
        }

        public bool pararGravacao()
        {
            if (!_gravando)
                return false;
            //MensagemUtils.notificar(2, "Gravando Percurso", "Gravando percurso agora!");
            PercursoAtual = null;
            _dataAnterior = DateTime.MinValue;
            _ultimoMovimentoReal = DateTime.MinValue;
            _gravando = false;
            _emMovimento = false;
            return true;
        }

        private void processarPonto(LocalizacaoInfo local, bool emMovimento) {
            PercursoPontoInfo ponto = new PercursoPontoInfo()
            {
                IdPercurso = PercursoAtual.Id,
                Latitude = local.Latitude,
                Longitude = local.Longitude,
                Velocidade = local.Velocidade,
                Sentido = local.Sentido,
                Precisao = local.Precisao,
                Data = local.Tempo,
                Movimento = emMovimento
            };
            gravarPonto(ponto);
            _dataAnterior = local.Tempo;
        }

        public bool executarGravacao(LocalizacaoInfo local)
        {
            if (!_gravando)
                return false;
            TimeSpan tempo = local.Tempo.Subtract(_dataAnterior);
            if (tempo.TotalSeconds > TEMPO_ATUALIZACAO_PONTO) {
                if (local.Velocidade >= VELOCIDADE_MAXIMA_PARADO) {
                    _ultimoMovimentoReal = local.Tempo;
                    _emMovimento = true;
                }
                else {
                    TimeSpan tempoMovimento = local.Tempo.Subtract(_ultimoMovimentoReal);
                    if (_emMovimento && tempoMovimento.TotalSeconds > TEMPO_MINIMO_PARADO)
                    {
                        _emMovimento = false;
                        _ultimoMovimentoReal = local.Tempo;
                        processarPonto(local, false);
                    }
                }

                if (_emMovimento) {
                    processarPonto(local, true);
                    return true;
                }
            }
            return false;
        }

        public void excluir(int id)
        {
            PercursoInfo percurso = _percursoDB.pegar(id);
            foreach (PercursoPontoInfo ponto in percurso.Pontos)
                _pontoDB.excluir(ponto.Id);
            _percursoDB.excluir(id);
        }

		public String enderecoDestino(PercursoInfo percurso)
		{

			String total = null;


				total = "Rua H- 149, 1-73 Cidade Vera Cruz/ Aparecida de Goiânia ";


			return total;
		}

		public double distanciaTotal(PercursoInfo percurso) {
			var regraRadar = RadarFactory.create();
			int count = 0;
			double total = 0;
			double initialLat = 0;
			double initialLong = 0;
			double finalLat = 0;
			double finalLong = 0;
			foreach (var pontos in percurso.Pontos){
				initialLat = pontos.Latitude;
				initialLong = pontos.Longitude;
				if (count > 0)
				{
					total  += regraRadar.calcularDistancia(initialLat, initialLong, finalLat, finalLong);
				}
				finalLat = pontos.Latitude;
				finalLong = pontos.Longitude;
				count++;
			}
			return total;
		}

		public String dataTitulo(PercursoInfo percurso)
		{

			String total = null;

			if (percurso.Pontos.Count > 0)
			{
				total = percurso.Pontos[0].Data.ToString();
			}

			return total;
		}

		public String velocidadeMedia(PercursoInfo percurso)
		{
			var regraRadar = RadarFactory.create();

			String total = null;

			if (percurso.Pontos.Count > 0)
			{
				total = "V Méd: " + percurso.Pontos[0].Data.ToString() + " Km/h ";
			}

			return total;
		}

		public String velocidadeMaxima(PercursoInfo percurso)
		{
			var regraRadar = RadarFactory.create();

			String total = null;

			if (percurso.Pontos.Count > 0)
			{
				total = "V Max: " + percurso.Pontos[0].Velocidade.ToString() + " Km/h ";
			}
			return total;
		}
    }
}
