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

        public static double DistanciaRadar {
            get {
                return 500;
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

		public static bool InfoTrafego
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("infoTrafego");
			}
		}

		public static bool IntervaloVerificacao
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("intervaloVerificacao");
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

		public static bool NivelZoom
		{
			get
			{
				PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
				return regraPreferencia.pegarBooleano("nivelZoom");
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
