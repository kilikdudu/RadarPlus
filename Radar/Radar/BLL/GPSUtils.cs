using Radar.Factory;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.BLL
{
    public static class GPSUtils
    {
        private const int NOTIFICACAO_SIMULACAO_ID = 1034;

        private static IGPS _gpsServico;

        private static bool _simulando = false;
        private static PercursoInfo _percursoSimulado;
        private static int _indexPercuso = 0;
        private static DateTime _ultimoPonto;

        public static bool Simulado {
            get {
                return _simulando;
            }
        }

        public static bool inicializar() {
            if (_gpsServico != null)
                _gpsServico = DependencyService.Get<IGPS>();
            return _gpsServico.inicializar();            
        }

        private static void executarPosicao(LocalizacaoInfo local) {
            try
            {
                RadarBLL regraRadar = RadarFactory.create();
                PercursoBLL regraPercurso = PercursoFactory.create();
                if (RadarBLL.RadarAtual != null)
                {
                    if (!regraRadar.radarContinuaAFrente(local, RadarBLL.RadarAtual))
                        RadarBLL.RadarAtual = null;
                }
                else {
                    RadarInfo radar = regraRadar.calcularRadar(local);
                    if (radar != null)
                        RadarBLL.RadarAtual = radar;
                }
                if (MapaPage.Atual != null)
                    MapaPage.Atual.atualizarPosicao(local);
                regraPercurso.executarGravacao(local);

                if (VelocimetroPage.Atual != null)
                {

                    VelocimetroPage.Atual.Velocimentro.VelocidadeAtual = (float)local.Velocidade;
                    //VelocimetroPage.Atual.Velocimentro.VelocidadeAtual = velocidadeAtual;
                    //velocidadeAtual  +=  5;

                    if (RadarBLL.RadarAtual != null)
                        VelocimetroPage.Atual.Velocimentro.VelocidadeRadar = RadarBLL.RadarAtual.Velocidade;
                    VelocimetroPage.Atual.Velocimentro.redesenhar();
                }
            }
            catch (Exception e) {
                ErroPage.exibir(e);
                //throw new Exception("Deu pau!");
            }
        }

        public static void atualizarPosicao(LocalizacaoInfo local) {
            if (!_simulando)
                executarPosicao(local);
        }

        public static bool simularPercurso(int idPercurso) {
            if (_simulando) {
                MensagemUtils.avisar("Já existe uma simulação em andamento.");
                return false;
            }
            PercursoBLL regraPercurso = PercursoFactory.create();
            _percursoSimulado = regraPercurso.pegar(idPercurso);
            _simulando = true;
            _indexPercuso = 0;
            _ultimoPonto = DateTime.MinValue;
            if (_percursoSimulado == null) {
                MensagemUtils.avisar("Percurso não encontrado.");
                return false;
            }
            if (_percursoSimulado.Pontos.Count() == 0) {
                MensagemUtils.avisar("Nenhum movimento registrado nesse percurso.");
                return false;
            }
            MensagemUtils.notificarPermanente(NOTIFICACAO_SIMULACAO_ID, "Simulando percurso!", string.Empty);
            MensagemUtils.avisar("Iniciando simulação!");
            var task = Task.Factory.StartNew(() => {
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
                    executarPosicao(local);

                    if (_ultimoPonto != DateTime.MinValue) { 
                        TimeSpan delay = ponto.Data.Subtract(_ultimoPonto);
                        Task.Delay((int)delay.TotalMilliseconds);
                    }
                    _ultimoPonto = ponto.Data;
                }
                else {
                    _simulando = false;
                    _indexPercuso = 0;
                    MensagemUtils.pararNotificaoPermanente(NOTIFICACAO_SIMULACAO_ID);
                    MensagemUtils.avisar("Simulação terminada!");
                }
            });
            //task.Start();
            return true;
        }
    }
}
