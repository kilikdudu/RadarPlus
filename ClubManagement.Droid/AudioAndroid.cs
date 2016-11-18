using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Xamarin.Forms;
using Radar.Droid;
using Java.IO;
using Android.Content.Res;
using System.IO;
using System.Threading.Tasks;
using ClubManagement.IBLL;
using ClubManagement.Model;

[assembly: Dependency(typeof(AudioAndroid))]

namespace Radar.Droid
{
    public class AudioAndroid: IAudio
    {
        //MediaPlayer _player;
        //int _audioIndex;
        //string[] _audioAtual;
        //MediaPlayer[] _players;
        float _volume = 15;
        AudioCanalEnum _canal = AudioCanalEnum.Nenhum;

        public AudioAndroid() {
        }

        public float Volume {
            get {
                return _volume;
            }
            set {
                _volume = value;
            }
        }

        public AudioCanalEnum Canal
        {
            get{
                return _canal;
            }
            set {
                _canal = value;
            }
        }

        private MediaPlayer criarAudio(string arquivo) {
            Context context = Android.App.Application.Context;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, Path.GetFileName(arquivo));
            if (!System.IO.File.Exists(path))
            {
                //var audioStream = context.Assets.Open("alarmes/" + arquivo);
                var audioStream = context.Assets.Open(arquivo);
                FileStream destino = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                audioStream.CopyTo(destino);
                audioStream.Close();
                destino.Close();
            }
            var player = MediaPlayer.Create(context, Android.Net.Uri.Parse(path));
            switch (_canal) {
                case AudioCanalEnum.Alarme:
                    player.SetAudioStreamType(Android.Media.Stream.Alarm);
                    break;
                case AudioCanalEnum.Musica:
                    player.SetAudioStreamType(Android.Media.Stream.Music);
                    break;
                default:
                    player.SetAudioStreamType(Android.Media.Stream.Notification);
                    break;
            }
            float volume = _volume / 15;
            player.SetVolume(volume, volume);
            return player;
        }

        /*
        private void playProximo() {
            if (_audioAtual != null && _audioIndex < _audioAtual.Length)
            {
                string arquivo = _audioAtual[_audioIndex];
                _audioIndex++;
                _player = criarAudio(arquivo);
                _player.Completion += (sender, e) =>
                {
                    playProximo();
                };
                _player.Start();
            }
            else {
                _player.Dispose();
                _player = null;
            }
        }
        */

        public void play(string[] arquivos)
        {
            /*
            _audioIndex = 0;
            _audioAtual = null;
            if (_player != null) {
                if (_player.IsPlaying)
                    _player.Stop();
                _player.Dispose();
                _player = null;
            }
            _audioIndex = 0;
            _audioAtual = arquivos;
            playProximo();
            */
            var players = new List<MediaPlayer>();
            foreach (var arquivo in arquivos)
                players.Add(criarAudio(arquivo));
            MediaPlayer player = null, playerAnterior = null;
            for (int i = players.Count - 1; i >= 0; i--)
            {
                player = players[i];
                if (playerAnterior != null)
                    player.SetNextMediaPlayer(playerAnterior);
                playerAnterior = player;
            }
            if (player != null)
                player.Start();
        }

        public void play(string arquivo) {

            /*
            _player = criarAudio(arquivo);
            _player.Start();
            */
            var player = criarAudio(arquivo);
            player.Start();
        }
    }
}