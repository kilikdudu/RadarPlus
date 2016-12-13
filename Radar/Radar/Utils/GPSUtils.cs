using ClubManagement.Utils;
using Radar.BLL;
using Radar.Factory;
using Radar.IBLL;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
	public static class GPSUtils
	{
		private const int RADAR_ID = 1;
        public const int DIAMETRO_TERRA = 6371;

        private static IGPS _gpsServico;

		private static bool _simulando = false;
		private static PercursoInfo _percursoSimulado;
		private static int _indexPercuso = 0;
		private static DateTime _ultimoPonto;
		private static LocalizacaoInfo _ultimaLocalizacao = null;
		private static int DistanciaOld = 0;

		public static bool Simulado
		{
			get
			{
				return _simulando;
			}
		}

		public static LocalizacaoInfo UltimaLocalizacao
		{
			get
			{
				return _ultimaLocalizacao;
			}
		}



		public static async void verificarFuncionamentoGPS()
		{
			if (_gpsServico == null)
				_gpsServico = DependencyService.Get<IGPS>();
			if (!_gpsServico.estaAtivo())
			{
				if (await App.Current.MainPage.DisplayAlert("Sinal de GPS Inativo", "Sinal de GPS não até ativo. Gostaria de ativa-lo?", "Ativar", "Não"))
				{
					_gpsServico.abrirPreferencia();
				}
			}
		}

		public static async void inicializar()
		{
			verificarFuncionamentoGPS();
			_gpsServico.inicializar();
		}

		private static int arredondarDistancia(double distancia)
		{
			return Convert.ToInt32(Math.Floor(distancia / 100) * 100);
		}

		private static void avisarRadar(LocalizacaoInfo local, RadarInfo radar)
		{
			var regraAviso = new AvisoSonoroBLL();
			RadarBLL.RadarAtual = radar;
			string mensagem = "Tem um radar a frente, diminua para " + radar.Velocidade.ToString() + "km/h!";

			MensagemUtils.notificar(RADAR_ID, "Radar Club", mensagem, radar.Velocidade);

			if (PreferenciaUtils.BeepAviso)
				regraAviso.play(PreferenciaUtils.SomAlarme);
			if (PreferenciaUtils.VibrarAlerta)
			{
				int tempo = PreferenciaUtils.TempoDuracaoVibracao;
				if (tempo <= 0)
					tempo = 1;
				tempo = tempo * 1000;
				MensagemUtils.vibrar(tempo);
			}
			if (PreferenciaUtils.HabilitarVoz)
			{
				int distancia = arredondarDistancia(local.Distancia);
                //if (distancia != DistanciaOld)
                //{
                //regraAviso.play(RadarTipoEnum.RadarFixo, radar.Velocidade, distancia);
                regraAviso.play(radar.Tipo, radar.Velocidade, distancia);
                DistanciaOld = distancia;
				//}
			}
		}

        private static LocalizacaoInfo executarPosicao(LocalizacaoInfo local) {
            try
            {
                _ultimaLocalizacao = local;
                RadarBLL regraRadar = RadarFactory.create();
                PercursoBLL regraPercurso = PercursoFactory.create();
                if (RadarBLL.RadarAtual != null)
                {
                    if (regraRadar.radarContinuaAFrente(local, RadarBLL.RadarAtual))
                    {
                        RadarInfo radar = RadarBLL.RadarAtual;
                        local.Distancia = calcularDistancia(local.Latitude, local.Longitude, radar.Latitude, radar.Longitude);
                    }
                    else
                        RadarBLL.RadarAtual = null;
                }
                else {
                    double distanciaRadar = (local.Velocidade < 90) ? PreferenciaUtils.DistanciaAlertaUrbano : PreferenciaUtils.DistanciaAlertaEstrada;
                    RadarInfo radar = regraRadar.calcularRadar(local, distanciaRadar);
                    if (radar != null)
                    {
                        local.Distancia = calcularDistancia(local.Latitude, local.Longitude, radar.Latitude, radar.Longitude);
                        if (PreferenciaUtils.AlertaInteligente)
                        {
                            if ((local.Velocidade - 5) > radar.Velocidade)
                                avisarRadar(local, radar);
                        }
                        else {
                            if (local.Velocidade > 15)
                                avisarRadar(local, radar);
                        }
                    }
                }
                var visualPage = GlobalUtils.Visual;
                if (visualPage != null)
                {
                    visualPage.VelocidadeAtual = (float)local.Velocidade;
                    visualPage.Precisao = local.Precisao;
                    visualPage.Sentido = local.Sentido;
                    RadarInfo radar = RadarBLL.RadarAtual;
                    if (radar != null)
                    {
                        visualPage.VelocidadeRadar = radar.Velocidade;
                        visualPage.DistanciaRadar = (float)local.Distancia;
                    }
                    else {
                        visualPage.VelocidadeRadar = 0;
                        visualPage.DistanciaRadar = 0;
                    }
                    visualPage.atualizarPosicao(local);
                    visualPage.redesenhar();
                }
                regraPercurso.executarGravacao(local);
                //MensagemUtils.avisar(MemoryUtils.getInfo().ToString());
            }
            catch (Exception e) {
                ErroPage.exibir(e);
            }
            return local;
        }

        public static LocalizacaoInfo atualizarPosicao(LocalizacaoInfo local) {
            var localRetorno = local;
            if (_simulando)
            {
                if (_indexPercuso < _percursoSimulado.Pontos.Count())
                {
                    PercursoPontoInfo ponto = _percursoSimulado.Pontos[_indexPercuso];
                    localRetorno = executarPosicao(new LocalizacaoInfo {
                        Latitude = ponto.Latitude,
                        Longitude = ponto.Longitude,
                        Sentido = ponto.Sentido,
                        Precisao = ponto.Precisao,
                        Tempo = ponto.Data,
                        Velocidade = ponto.Velocidade
                    });
                    _indexPercuso++;
                }
                else
                    pararSimulacao();
            }
            else
                localRetorno = executarPosicao(local);
            return localRetorno;
        }

		public static void pararSimulacao()
		{
			_simulando = false;
			_indexPercuso = 0;
			ClubManagement.Utils.MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_SIMULACAO_PERCURSO_ID);
			ClubManagement.Utils.MensagemUtils.avisar("Simulação finalizada!");
		}


        public static bool simularPercurso(int idPercurso) {
            if (_simulando) {
                ClubManagement.Utils.MensagemUtils.avisar("Já existe uma simulação em andamento.");
                return false;
            }
            PercursoBLL regraPercurso = PercursoFactory.create();
            _percursoSimulado = regraPercurso.pegar(idPercurso);
            _simulando = true;
            _indexPercuso = 0;
            _ultimoPonto = DateTime.MinValue;
            if (_percursoSimulado == null) {
                ClubManagement.Utils.MensagemUtils.avisar("Percurso não encontrado.");
                return false;
            }
            if (_percursoSimulado.Pontos.Count() == 0) {
                MensagemUtils.avisar("Nenhum movimento registrado nesse percurso.");
                return false;
            }
            //MensagemUtils.notificarPermanente(NOTIFICACAO_SIMULACAO_ID, "Simulando percurso!", string.Empty);
            MensagemUtils.notificarPermanente(
                PercursoBLL.NOTIFICACAO_SIMULACAO_PERCURSO_ID,
                "Radar Club", "Simulando percurso...",
                PercursoBLL.NOTIFICACAO_SIMULACAO_PARAR_PERCURSO_ID, 
                "Parar",
                PercursoBLL.ACAO_PARAR_SIMULACAO
            );
            MensagemUtils.avisar("Iniciando simulação!");
            /*
            var task = Task.Factory.StartNew(() =>
            {
                while (_simulando)
                {
                    if (_indexPercuso < _percursoSimulado.Pontos.Count())
                    {
                        PercursoPontoInfo ponto = _percursoSimulado.Pontos[_indexPercuso];

						LocalizacaoInfo local = new LocalizacaoInfo
						{
							Latitude = ponto.Latitude,
							Longitude = ponto.Longitude,
							Sentido = ponto.Sentido,
							Precisao = ponto.Precisao,
							Tempo = ponto.Data,
							Velocidade = ponto.Velocidade
						};
						//executarPosicao(local);
						ThreadUtils.RunOnUiThread(() =>
						{
							executarPosicao(local);
						});


                        if (_ultimoPonto != DateTime.MinValue)
                        {
                            TimeSpan delay = ponto.Data.Subtract(_ultimoPonto);
                            Task.Delay((int)delay.TotalMilliseconds).Wait();
                            //_ultimoPonto = ponto.Data;
                        }
                        _ultimoPonto = ponto.Data;
                        _indexPercuso++;
                    }
                    else {
                        pararSimulacao();
                        break;
                    }
                }
            });
            */
            return true;
        }

        private static double toRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }

        public static double calcularDistancia(double initialLat, double initialLong, double finalLat, double finalLong)
        {
            double dLat = toRadians(finalLat - initialLat);
            double dLon = toRadians(finalLong - initialLong);
            double lat1 = toRadians(initialLat);
            double lat2 = toRadians(finalLat);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return DIAMETRO_TERRA * c * 1000;
        }
    }

}
