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

[assembly: Dependency(typeof(AudioAndroid))]

namespace Radar.Droid
{
    public class AudioAndroid: IAudio
    {
        MediaPlayer _player;
        int _audioIndex;
        string[] _audioAtual;

        public AudioAndroid() {
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
            return MediaPlayer.Create(context, Android.Net.Uri.Parse(path));
        }

        private void playProximo() {
            if (_audioAtual != null && _audioIndex < _audioAtual.Length)
            {
                string arquivo = _audioAtual[_audioIndex];
                _audioIndex++;
                _player = criarAudio(arquivo);
                //_player.SetVolume();
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

        public void play(string[] arquivos)
        {
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
        }

        public void play(string arquivo) {

            _player = criarAudio(arquivo);
            _player.Start();
        }
    }
}