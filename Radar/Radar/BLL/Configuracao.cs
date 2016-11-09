using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.Factory;

namespace Radar.BLL
{
    public static class Configuracao
    {
		public static bool AlertaInteligente
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("alertaInteligente");
			}
		}

        public static bool AlertaSonoro
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("alertaSonoro");
            }

        }

        public static string AlturaVolume
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("alturaVolume");
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
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("beepAviso");
			}
		}

		public static bool Bussola
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("bussola");
			}

		}

        public static string CanalAudio
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("canalAudio");
            }
        }

        public static bool Desabilitar
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("desabilitar");
            }

        }

        public static string DesativarGPS
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("desativarGPS");
            }

        }

        public static double DistanciaRadar {
            get {
                return 500;
            }
        }

        public static string DistanciaAlertaUrbano
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("distanciaAlertaUrbano");
            }
        }

        public static string DistanciaAlertaEstrada
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("distanciaAlertaEstrada");
            }
        }

        public static bool Encurtar
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("encurtar");
            }

        }

        public static bool ExcluirAntigos
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("excluirAntigos");
			}
		}

		public static bool ExibirBotaoAdcionar
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("exibirBotaoAdcionar");
			}
		}

		public static bool ExibirBotaoRemover
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("exibirBotaoRemover");
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

        

        public static bool ImagenSatelite
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("imagenSatelite");
			}
		}

        public static bool InicioDesligamento
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("inicioDesligamento");
            }

        }

        public static bool InfoTrafego
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("infoTrafego");
			}
		}

		public static string IntervaloVerificacao
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegar("intervaloVerificacao");
			}
		}

        public static bool LigarDesligar
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("ligarDesligar");
            }

        }

        public static bool Lombada
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("lombada");
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

		public static string NivelZoom
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegar("nivelZoom");
			}
		}

		public static bool Pedagio
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("pedagio");
			}
		}

		public static bool PoliciaRodoviaria
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("policiaRodoviaria");
			}
		}

		public static bool RadarMovel
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("radarMovel");
			}
		}

		public static bool RotacionarMapa
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("rotacionarMapa");
			}
		}

		public static bool SalvarPercurso
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("salvarPercurso");
			}
		}


		public static bool SinalGPS
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("sinalGPS");
			}
		}

        public static bool SobreposicaoVisual
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("sobreposicaoVisual");
            }
        }

        public static string SomAlarme
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("somAlarme");
            }
        }

        public static bool SomCaixa
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("somCaixa");
			}
		}  

        public static bool SuavizarAnimacao
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("suavizarAnimacao");
			}
		}

        public static string TempoAlerta
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("tempoAlerta");
            }
        }

        public static string TempoDuracao
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("tempoDuracao");
            }
        }

        public static string TempoPercurso
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegar("tempoPercurso");
            }
        }

        public static bool VerificarIniciar
        {
            get
            {
                PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
                return regraPreferencia.pegarBooleano("verificarIniciar");
            }
        }

        public static bool VibrarAlerta
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("vibrarAlerta");
			}
		}

		public static bool VolumePersonalizado
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("volumePersonalizado");
			}
		}

	}
}
