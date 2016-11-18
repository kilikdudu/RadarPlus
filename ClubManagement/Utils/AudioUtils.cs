using ClubManagement.IBLL;
using ClubManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Utils
{
    public static class AudioUtils
    {
        private const float VOLUME_MAXIMO = 15;
        private static IAudio _audio;

        private static string pegarArquivo(AlarmeEnum audio) {
            string arquivo;
            switch (audio) {
                case AlarmeEnum.Alarm002:
                    arquivo = "alarm-002.wav";
                    break;
                case AlarmeEnum.Alarm003:
                    arquivo = "alarm-003.wav";
                    break;
                case AlarmeEnum.Alarm004:
                    arquivo = "alarm-004.wav";
                    break;
                case AlarmeEnum.Alarm005:
                    arquivo = "alarm-005.wav";
                    break;
                case AlarmeEnum.Alarm006:
                    arquivo = "alarm-006.wav";
                    break;
                case AlarmeEnum.Alarm007:
                    arquivo = "alarm-007.wav";
                    break;
                case AlarmeEnum.Alarm008:
                    arquivo = "alarm-008.wav";
                    break;
                case AlarmeEnum.Alarm009:
                    arquivo = "alarm-009.wav";
                    break;
                case AlarmeEnum.Alarm010:
                    arquivo = "alarm-010.wav";
                    break;
                case AlarmeEnum.Alarm011:
                    arquivo = "alarm-011.wav";
                    break;
                case AlarmeEnum.Alarm012:
                    arquivo = "alarm-012.wav";
                    break;
                case AlarmeEnum.Alarm013:
                    arquivo = "alarm-013.wav";
                    break;
                default:
                    arquivo = "alarm-001.wav";
                    break;
            }
            return arquivo;
        }

        private static void inicilizarAudio() {
            if (_audio == null)
            {
                _audio = DependencyService.Get<IAudio>();
                _audio.Volume = VOLUME_MAXIMO;
                _audio.Canal = AudioCanalEnum.Notificacao;
            }
        }

        public static float Volume {
            get {
                inicilizarAudio();
                return _audio.Volume;
            }
            set {
                inicilizarAudio();
                _audio.Volume = value;
            }
        }

        public static AudioCanalEnum Canal {
            get {
                inicilizarAudio();
                return _audio.Canal;
            }
            set {
                inicilizarAudio();
                _audio.Canal = value;
            }
        }

        public static void play(AlarmeEnum arquivo) {
            inicilizarAudio();
            var arquivoStr = "alarmes/" + pegarArquivo(arquivo);
            _audio.play(arquivoStr);
        }

        public static void play(string arquivo)
        {
            inicilizarAudio();
            _audio.play(arquivo);
        }

        public static void play(string[] arquivos)
        {
            inicilizarAudio();
            _audio.play(arquivos);
        }
    }
}
