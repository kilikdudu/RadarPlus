using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
    public static class AudioUtils
    {
        private static IAudio _audio;

        private static string pegarArquivo(AudioEnum audio) {
            string arquivo;
            switch (audio) {
                case AudioEnum.Alarm002:
                    arquivo = "alarm-002.wav";
                    break;
                case AudioEnum.Alarm003:
                    arquivo = "alarm-003.wav";
                    break;
                case AudioEnum.Alarm004:
                    arquivo = "alarm-004.wav";
                    break;
                case AudioEnum.Alarm005:
                    arquivo = "alarm-005.wav";
                    break;
                case AudioEnum.Alarm006:
                    arquivo = "alarm-006.wav";
                    break;
                case AudioEnum.Alarm007:
                    arquivo = "alarm-007.wav";
                    break;
                case AudioEnum.Alarm008:
                    arquivo = "alarm-008.wav";
                    break;
                case AudioEnum.Alarm009:
                    arquivo = "alarm-009.wav";
                    break;
                case AudioEnum.Alarm010:
                    arquivo = "alarm-010.wav";
                    break;
                case AudioEnum.Alarm011:
                    arquivo = "alarm-011.wav";
                    break;
                case AudioEnum.Alarm012:
                    arquivo = "alarm-012.wav";
                    break;
                case AudioEnum.Alarm013:
                    arquivo = "alarm-013.wav";
                    break;
                default:
                    arquivo = "alarm-001.wav";
                    break;
            }
            return arquivo;
        }

        public static bool play(AudioEnum arquivo) {
            if (_audio == null)
                _audio = DependencyService.Get<IAudio>();
            return _audio.play(pegarArquivo(arquivo));
        }
    }
}
