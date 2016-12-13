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
using ClubManagement.Utils;

namespace Radar.BLL
{
    public class PercursoBLL
    {
        private IPercursoDAL _percursoDB;
        private IPercursoPontoDAL _pontoDB;

        //private const int TEMPO_ATUALIZACAO_PONTO = 5;
        private const int TEMPO_MINIMO_PARADO = 120;
        private const int VELOCIDADE_MAXIMA_PARADO = 3;
        public const int NOTIFICACAO_GRAVAR_PERCURSO_ID = 2301;
        public const int NOTIFICACAO_PARAR_PERCURSO_ID = 2302;
        public const int NOTIFICACAO_SIMULACAO_PERCURSO_ID = 1034;
        public const int NOTIFICACAO_SIMULACAO_PARAR_PERCURSO_ID = 1035;
        public const string ACAO_PARAR_SIMULACAO = "parar-simulacao";
        public const string ACAO_PARAR_GRAVACAO = "parar-gravacao";

        private static PercursoInfo _percursoAtual;
        private static bool _gravando = false;
        private static DateTime _dataAnterior;
        //private static DateTime _ultimoMovimentoReal;
        //private static bool _emMovimento = true;

        public ProcessarPontoEventHandler AoProcessar { get; set; }

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
				percurso.QuantidadeParada = 0;
				percurso.QuantidadeRadar =  0;
				percurso.TempoParado = tempoParado(percurso);
				_percursoAtual = percurso;

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
			var grava = _percursoDB.gravar(percurso);
			atualizarEndereco();
            return grava;
            //return percurso.Id;
        }

        public int gravarPonto(PercursoPontoInfo ponto) {
            return _pontoDB.gravar(ponto);
        }

		public void atualizarEndereco()
		{
			if (InternetUtils.estarConectado())
			{
				var percursos = _percursoDB.listarEnderecoNulo();
				if (percursos.Count > 0)
				{
					int idPercurso = percursos[0].Id;
					var pontos = _pontoDB.listar(idPercurso);
					if (pontos.Count() > 0)
					{
						float lat = (float)(from p in pontos select p.Latitude).Last();
						float lon = (float)(from p in pontos select p.Longitude).Last();

						GeocoderUtils.pegarAsync(lat, lon, (sender, e) =>
						{
							var endereco = e.Endereco;
							PercursoInfo percurso = new PercursoInfo()
							{
								Id = idPercurso,
								Endereco = endereco.Logradouro + " " + endereco.Complemento + " " + endereco.Bairro + " " + endereco.Cidade + " " + endereco.Uf + " " + endereco.CEP

							};

							gravar(percurso);
							atualizarEndereco();
						});
					}

				}
			}
		}

        public bool iniciarGravacao(ProcessarPontoEventHandler aoProcessar) {
            if (_gravando)
                return false;
			PercursoInfo percurso = new PercursoInfo();
            gravar(percurso);
			//atualizarEndereco();
            PercursoAtual = percurso;
            _dataAnterior = DateTime.MinValue;
            //_ultimoMovimentoReal = DateTime.MinValue;
            _gravando = true;
            //_emMovimento = true;
			AoProcessar += aoProcessar;
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
            //_ultimoMovimentoReal = DateTime.MinValue;
            _gravando = false;
            //_emMovimento = false;
			//atualizarEndereco();
            return true;
        }

        private void processarPonto(LocalizacaoInfo local, RadarInfo radar = null) {

				PercursoPontoInfo ponto = new PercursoPontoInfo()
				{
					IdPercurso = PercursoAtual.Id,
					Latitude = local.Latitude,
					Longitude = local.Longitude,
					Velocidade = local.Velocidade,
					Sentido = local.Sentido,
					Precisao = local.Precisao,
					Data = local.Tempo,
                    IdRadar = (radar != null) ? radar.Id : 0
				};


				gravarPonto(ponto);

				if (AoProcessar != null)
					AoProcessar(this, new ProcessarPontoEventArgs(_percursoAtual));
				_dataAnterior = local.Tempo;
			
        }

        public bool executarGravacao(LocalizacaoInfo local, RadarInfo radar = null)
        {
            if (!_gravando)
                return false;
            //TimeSpan tempo = local.Tempo.Subtract(_dataAnterior);
            //if (tempo.TotalSeconds > TEMPO_ATUALIZACAO_PONTO) {
            /*
            if (local.Velocidade >= VELOCIDADE_MAXIMA_PARADO)
            {
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

           if (_emMovimento)
            {
                processarPonto(local, true);
                return true;
            }
            */
            //}
            processarPonto(local, radar);
            return false;
        }

        public void excluir(int id)
        {
            PercursoInfo percurso = _percursoDB.pegar(id);
			if(percurso != null)
            	foreach (PercursoPontoInfo ponto in percurso.Pontos)
                	_pontoDB.excluir(ponto.Id);
            _percursoDB.excluir(id);
        }

		public String enderecoDestino(PercursoInfo percurso)
		{

			string endereco = null;
			var pontos = _percursoDB.listarPercurso(percurso.Id);
			if (pontos.Count() > 0)
			{

				endereco = (from p in pontos select p.Endereco).Last();
			}

			return endereco;
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

		public DateTime dataTitulo(PercursoInfo percurso)
		{

			DateTime total = new DateTime();

			if (percurso.Pontos.Count > 0)
			{
				total = percurso.Pontos[0].Data;
			}

			return total;
		}

		public int velocidadeMedia(PercursoInfo percurso)
		{     
			int total = 0;
			var pontos = _pontoDB.listar(percurso.Id);
			if (pontos.Count() > 0)
			{
				DateTime maiorTempo = (from p in pontos select p.Data).Max();
				DateTime menorTempo = (from p in pontos select p.Data).Min();
				double horas = maiorTempo.Subtract(menorTempo).TotalHours;

				total = (int)Math.Floor(((distanciaTotal(percurso) / 1000) / horas));
			}


			return total;
		}

		public int velocidadeMaxima(PercursoInfo percurso)
		{
			int total = 0;

			if (percurso.Pontos.Count > 0)
			{
				total =  (int)Math.Floor((from p in percurso.Pontos select p.Velocidade).Max());
			}
			return total;
		}

		public TimeSpan tempoParado(PercursoInfo percurso)
		{
			TimeSpan total = new TimeSpan();

			if (percurso.Pontos.Count > 0)
			{
				
				DateTime maiorTempo = (from p in percurso.Pontos select p.Data).Max();
					DateTime menorTempo = (from p in percurso.Pontos select p.Data).Min();
					total = maiorTempo.Subtract(menorTempo);

			}
			return total;
		}
    }
}
