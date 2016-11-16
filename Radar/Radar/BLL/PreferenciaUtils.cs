using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.Factory;
using Radar.Model;

namespace Radar.BLL
{
    public static class PreferenciaUtils
    {
        private const string URL_ATUALIZACAO = "http://pavmanager.com.br/maparadar.txt";

        private static PreferenciaBLL _regraPreferencia = PreferenciaFactory.create();

        private const string ALTURA_VOLUME = "alturaVolume";
        private const string CANAL_AUDIO = "canalAudio";
        private const string AO_DESATIVAR_GPS = "aoDesativarGPS";
        private const string DISTANCIA_ALERTA_URBANO = "distanciaAlertaUrbano";
        private const string DISTANCIA_ALERTA_ESTRADA = "distanciaAlertaEstrada";
        private const string INTERVALO_VERIFICACAO = "intervaloVerificacao";
        private const string NIVEL_ZOOM = "nivelZoom";
        private const string SOM_ALARME = "somAlarme";
        private const string TEMPO_ALERTA = "tempoAlerta";
        private const string TEMPO_DURACAO = "tempoDuracao";
        private const string TEMPO_PERCURSO = "tempoPercurso";
        private const string PEDAGIO = "pedagio";
        private const string POLICIA_RODOVIARIA = "policiaRodoviaria";
        private const string RADAR_MOVEL = "radarMovel";
        private const string ROTACIONAR_MAPA = "rotacionarMapa";
        private const string SALVAR_PERCURSO = "salvarPercurso";
        private const string SINAL_GPS = "sinalGPS";
        private const string SOBREPOSICAO_VISUAL = "sobreposicaoVisual";
        private const string SOM_CAIXA = "somCaixa";
        private const string SUAVIZAR_ANIMACAO = "suavizarAnimacao";
        private const string ALERTA_INTELIGENTE = "alertaInteligente";
        private const string ALERTA_SONORO = "alertaSonoro";
        private const string BEEP_AVISO = "beepAviso";
        private const string BUSSOLA = "bussola";
        private const string VOZ_HABILITADA = "vozHabilitada";
        private const string ENCURTAR = "encurtar";
        private const string EXCLUIR_ANTIGO = "excluirAntigos";
        private const string EXIBIR_BOTAO_ADICIONAR = "exibirBotaoAdicionar";
        private const string EXIBIR_BOTAO_REMOVER = "exibirBotaoRemover";
        private const string IMAGEM_SATELITE = "imagemSatelite";
        private const string INICIO_DESLIGAMENTO = "inicioDesligamento";
        private const string INFO_TRAFEGO = "infoTrafego";
        private const string LIGAR_DESLIGAR = "ligarDesligar";
        private const string LOMBADA = "lombada";
        private const string VERIFICAR_INICIAR = "verificarIniciar";
        private const string VIBRAR_ALERTA = "vibrarAlerta";
        private const string VOLUME_PERSONALIZADO = "volumePersonalizado";

        public static bool AlertaInteligente
		{
			get {
				return _regraPreferencia.pegarBool(ALERTA_INTELIGENTE);
			}
            set {
                _regraPreferencia.gravar(ALERTA_INTELIGENTE, value);
            }
		}

        public static bool AlertaSonoro
        {
            get {
                return _regraPreferencia.pegarBool(ALERTA_SONORO);
            }
            set {
                _regraPreferencia.gravar(ALERTA_SONORO, value);
            }
        }

        public static int AlturaVolume
        {
            get {
                return _regraPreferencia.pegarInt(ALTURA_VOLUME);
            }
            set {
                _regraPreferencia.gravar(ALTURA_VOLUME, value);
            }
        }

        public static int AnguloRadar
		{
			get
			{
				return 30;
			}
		}

		public static int AnguloCone
		{
			get
			{
				return 45;
			}
		}

		public static bool BeepAviso
		{
			get {
				return _regraPreferencia.pegarBool(BEEP_AVISO);
			}
            set {
                _regraPreferencia.gravar(BEEP_AVISO, value);
            }
		}

        /// <summary>
        /// Exibir a Bussola no Mapa
        /// </summary>
		public static bool Bussola
		{
			get {
				return _regraPreferencia.pegarBool(BUSSOLA, true);
			}
            set {
                _regraPreferencia.gravar(BUSSOLA, value);
            }
		}

        public static CanalAudioEnum CanalAudio
        {
            get {
                return (CanalAudioEnum) _regraPreferencia.pegarInt(CANAL_AUDIO, (int)CanalAudioEnum.Notificacao);
            }
            set {
                _regraPreferencia.gravar(CANAL_AUDIO, (int)value);
            }
        }

        public static bool HabilitarVoz
        {
            get {
                return _regraPreferencia.pegarBool(VOZ_HABILITADA, false);
            }
            set {
                _regraPreferencia.gravar(VOZ_HABILITADA, value);
            }
        }

        public static AoDesativarGPSEnum AoDesativarGPS
        {
            get {
                return (AoDesativarGPSEnum)_regraPreferencia.pegarInt(AO_DESATIVAR_GPS, (int) AoDesativarGPSEnum.FecharOPrograma);
            }
            set {
                _regraPreferencia.gravar(AO_DESATIVAR_GPS, (int)value);
            }

        }

        public static double DistanciaRadar {
            get {
                return 500;
            }
        }

        public static int DistanciaAlertaUrbano
        {
            get
            {
                return _regraPreferencia.pegarInt(DISTANCIA_ALERTA_URBANO, 50);
            }
            set {
                _regraPreferencia.gravar(DISTANCIA_ALERTA_URBANO, value);
            }
        }

        public static int DistanciaAlertaEstrada
        {
            get
            {
                return _regraPreferencia.pegarInt(DISTANCIA_ALERTA_ESTRADA, 300);
            }
            set {
                _regraPreferencia.gravar(DISTANCIA_ALERTA_ESTRADA, value);
            }
        }

        public static bool Encurtar
        {
            get {
                return _regraPreferencia.pegarBool(ENCURTAR);
            }
            set {
                _regraPreferencia.gravar(ENCURTAR, value);
            }
        }

        public static bool ExcluirAntigo
		{
			get {
				return _regraPreferencia.pegarBool(EXCLUIR_ANTIGO);
			}
            set {
                _regraPreferencia.gravar(EXCLUIR_ANTIGO, value);
            }
		}

		public static bool ExibirBotaoAdicionar
		{
			get {
				return _regraPreferencia.pegarBool(EXIBIR_BOTAO_ADICIONAR);
			}
            set {
                _regraPreferencia.gravar(EXIBIR_BOTAO_ADICIONAR, value);
            }
		}

		public static bool ExibirBotaoRemover
		{
			get {
				return _regraPreferencia.pegarBool(EXIBIR_BOTAO_REMOVER);
			}
            set {
                _regraPreferencia.gravar(EXIBIR_BOTAO_REMOVER, value);
            }
		}

        public static int GPSTempoAtualiazacao {
            get {
                return 1000;
            }
        }

        public static int GPSDistanciaAtualizacao {
            get {
                return 0;
            }
        }

        public static double GPSDeltaMax
        {
            get
            {
                return 0.014;
            }
        }

        public static double GPSDeltaPadrao
        {
            get
            {
                return 0.008;
            }
        }

        public static bool ImagemSatelite
		{
			get {
				return _regraPreferencia.pegarBool(IMAGEM_SATELITE);
			}
            set {
                _regraPreferencia.gravar(IMAGEM_SATELITE, value);
            }
		}

        public static bool InicioDesligamento
        {
            get {
                return _regraPreferencia.pegarBool(INICIO_DESLIGAMENTO);
            }
            set {
                _regraPreferencia.gravar(INICIO_DESLIGAMENTO, value);
            }
        }

        public static bool InfoTrafego
		{
			get {
				return _regraPreferencia.pegarBool(INFO_TRAFEGO);
			}
            set {
                _regraPreferencia.gravar(INFO_TRAFEGO, value);
            }
		}

		public static int IntervaloVerificacao
		{
			get {
				return _regraPreferencia.pegarInt(INTERVALO_VERIFICACAO);
			}
            set {
                _regraPreferencia.gravar(INTERVALO_VERIFICACAO, value);
            }
		}

        public static bool LigarDesligar
        {
            get {
                return _regraPreferencia.pegarBool(LIGAR_DESLIGAR);
            }
            set {
                _regraPreferencia.gravar(LIGAR_DESLIGAR, value);
            }
        }

        public static bool Lombada
		{
			get {
				return _regraPreferencia.pegarBool(LOMBADA);
			}
            set {
                _regraPreferencia.gravar(LOMBADA, value);
            }
		}

		public static float MapaZoom {
            get
            {
                return 18;
            }
        }

        public static float MapaTilt
        {
            get
            {
                return 65;
            }
        }

		public static int NivelZoom
		{
			get
			{
				return _regraPreferencia.pegarInt(NIVEL_ZOOM);
			}
            set {
                _regraPreferencia.gravar(NIVEL_ZOOM, value);
            }
		}

		public static bool Pedagio
		{
			get {
				return _regraPreferencia.pegarBool(PEDAGIO);
			}
            set {
                _regraPreferencia.gravar(PEDAGIO, value);
            }
		}

		public static bool PoliciaRodoviaria
		{
			get {
				return _regraPreferencia.pegarBool(POLICIA_RODOVIARIA);
			}
            set {
                _regraPreferencia.gravar(POLICIA_RODOVIARIA, value);
            }
		}

		public static bool RadarMovel
		{
			get {
				return _regraPreferencia.pegarBool(RADAR_MOVEL);
			}
            set {
                _regraPreferencia.gravar(RADAR_MOVEL, value);
            }
		}

		public static bool RotacionarMapa
		{
			get {
				return _regraPreferencia.pegarBool(ROTACIONAR_MAPA);
			}
            set {
                _regraPreferencia.gravar(ROTACIONAR_MAPA, value);
            }
		}

		public static bool SalvarPercurso
		{
			get {
				return _regraPreferencia.pegarBool(SALVAR_PERCURSO);
			}
            set {
                _regraPreferencia.gravar(SALVAR_PERCURSO, value);
            }
		}

        /// <summary>
        /// Exibir Sinal de GPS no Mapa
        /// </summary>
		public static bool SinalGPS
		{
			get {
				return _regraPreferencia.pegarBool(SINAL_GPS);
			}
            set {
                _regraPreferencia.gravar(SINAL_GPS, value);
            }
		}

        public static bool SobreposicaoVisual
        {
            get {
                return _regraPreferencia.pegarBool(SOBREPOSICAO_VISUAL);
            }
            set {
                _regraPreferencia.gravar(SOBREPOSICAO_VISUAL, value);
            }
        }

        public static SomAlarmeEnum SomAlarme
        {
            get {
                return (SomAlarmeEnum) _regraPreferencia.pegarInt(SOM_ALARME, (int) SomAlarmeEnum.Alarme01);
            }
            set {
                _regraPreferencia.gravar(SOM_ALARME, (int)value);
            }
        }

        public static bool SomCaixa
		{
			get {
				return _regraPreferencia.pegarBool(SOM_CAIXA);
			}
            set {
                _regraPreferencia.gravar(SOM_CAIXA, value);
            }
		}  

        public static bool SuavizarAnimacao
		{
			get {
				return _regraPreferencia.pegarBool(SUAVIZAR_ANIMACAO);
			}
            set {
                _regraPreferencia.gravar(SUAVIZAR_ANIMACAO, value);
            }
		}

        public static int TempoAlerta
        {
            get {
                return _regraPreferencia.pegarInt(TEMPO_ALERTA);
            }
            set {
                _regraPreferencia.gravar(TEMPO_ALERTA, value);
            }
        }

        public static int TempoDuracao
        {
            get {
                return _regraPreferencia.pegarInt(TEMPO_DURACAO);
            }
            set {
                _regraPreferencia.gravar(TEMPO_DURACAO, value);
            }
        }

        public static int TempoPercurso
        {
            get {
                return _regraPreferencia.pegarInt(TEMPO_PERCURSO);
            }
            set {
                _regraPreferencia.gravar(TEMPO_PERCURSO, value);
            }
        }

        public static bool VerificarIniciar
        {
            get {
                return _regraPreferencia.pegarBool(VERIFICAR_INICIAR);
            }
            set {
                _regraPreferencia.gravar(VERIFICAR_INICIAR, value);
            }
        }

        public static bool VibrarAlerta
		{
			get {
				return _regraPreferencia.pegarBool(VIBRAR_ALERTA);
			}
            set {
                _regraPreferencia.gravar(VIBRAR_ALERTA, value);
            }
		}

		public static bool VolumePersonalizado
		{
			get {
				return _regraPreferencia.pegarBool(VOLUME_PERSONALIZADO);
			}
            set {
                _regraPreferencia.gravar(VOLUME_PERSONALIZADO, value);
            }
		}

        public static string UrlAtualizacao {
            get {
                return URL_ATUALIZACAO;
            }
        }
	}
}
