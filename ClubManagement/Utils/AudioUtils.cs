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
