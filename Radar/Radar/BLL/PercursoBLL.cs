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
        private static float _latitude = 0;
        private static float _longitude = 0;
        //private static DateTime _dataAnterior;
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
                percurso.Pontos = pontos;
				//_percursoAtual = percurso;
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
            atualizarEndereco(percurso);
            return grava;
            //return percurso.Id;
        }

        public int gravarPonto(PercursoPontoInfo ponto) {			
            return _pontoDB.gravar(ponto);
        }

        public void atualizarEndereco(PercursoInfo percurso)
        {
            if (!InternetUtils.estarConectado()) return;
            if (percurso.Pontos.Count == 0) return;

            var ponto = percurso.Pontos.Last();
            GeocoderUtils.pegarAsync((float)ponto.Latitude, (float)ponto.Longitude, (sender, e) =>
            {
                var endereco = e.Endereco;
                percurso.Endereco = endereco.Logradouro + " " + endereco.Complemento + " " + endereco.Bairro + " " + endereco.Cidade + " " + endereco.Uf + " " + endereco.CEP;
                gravar(percurso);
            });
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
            _percursoAtual = percurso;
            //_dataAnterior = DateTime.MinValue;
            //_ultimoMovimentoReal = DateTime.MinValue;
            _gravando = true;
            _latitude = 0;
            _longitude = 0;
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
            _percursoAtual = null;
            //_dataAnterior = DateTime.MinValue;
            //_ultimoMovimentoReal = DateTime.MinValue;
            _gravando = false;
            //_emMovimento = false;
			//atualizarEndereco();
            return true;
        }

        private PercursoPontoInfo gerarPonto(LocalizacaoInfo local, RadarInfo radar = null) {
            return new PercursoPontoInfo()
            {
                IdPercurso = _percursoAtual.Id,
                Latitude = local.Latitude,
                Longitude = local.Longitude,
                Velocidade = local.Velocidade,
                Sentido = local.Sentido,
                Precisao = local.Precisao,
                Data = local.Tempo,
                IdRadar = (radar != null) ? radar.Id : 0
            };
        }

        private void processarPonto(LocalizacaoInfo local, RadarInfo radar = null)
        {
            var distancia = GPSUtils.calcularDistancia(local.Latitude, local.Longitude, _latitude, _longitude);
            bool alterado = false;
            if (distancia >= 15)
            {
                var ponto = gerarPonto(local, radar);
                gravarPonto(ponto);
                _percursoAtual.Pontos.Add(ponto);

                _latitude = (float)local.Latitude;
                _longitude = (float)local.Longitude;
                alterado = true;
            }
            if (AoProcessar != null)
                AoProcessar(this, new ProcessarPontoEventArgs(_percursoAtual, local, alterado));
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

       //    if (_emMovimento)
       //     {
                processarPonto(local, true);
                return true;
            }
            */
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

        /*
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
        */

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
