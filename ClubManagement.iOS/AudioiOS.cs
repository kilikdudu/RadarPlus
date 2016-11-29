using AVFoundation;
using ClubManagement.IBLL;
using Foundation;
using Radar.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using ClubManagement.Model;
using AudioToolbox;
using System.Threading.Tasks;
using CoreMedia;

[assembly: Dependency(typeof(AudioiOS))]

namespace Radar.iOS
{
    public class AudioiOS : IAudio
    {
        float _volume = 15;
        AudioCanalEnum _canal = AudioCanalEnum.Nenhum;
        IList<string> _audioAtual = new List<string>();
        int _audioIndex = 0;
        AVAudioPlayer _player;

        public AudioCanalEnum Canal
        {
            get {
                return _canal;
            }

            set
            {
                _canal = value;
            }
        }

        public float Volume {
            get {
                return _volume;
            }
            set {
                _volume = value;
            }
        }

		private AVAudioPlayer criarAudio(string arquivo)
		{

			NSUrl songURL = new NSUrl(arquivo);
			NSError err;
			AVAudioPlayer player = new AVAudioPlayer(songURL, "wav", out err);
			player.Volume = Volume;
			player.NumberOfLoops = 0;

			NSUrl url = NSUrl.FromFilename(arquivo);
			//SystemSound notificationSound = SystemSound.FromFile(NotificationSoundPath);
			SystemSound mySound = new SystemSound(url);

			mySound.AddSystemSoundCompletion(SystemSound.Vibrate.PlaySystemSound);
			var asset = AVAsset.FromUrl(NSUrl.FromFilename(arquivo));

			CMTime audioDuration = asset.Duration;
			double tempo = (double)audioDuration.Value / (double)audioDuration.TimeScale;
			esperaFinalizarSom(tempo)
			mySound.PlaySystemSound();


			return player;
		}

		public async void esperaFinalizarSom(double tempo)
		{
			await Task.Delay((int)Math.Floor(tempo) * 1000);
		}

		private async void playProximo()
		{
			if (_audioAtual != null && _audioIndex < _audioAtual.Count)
			{
				string arquivo = _audioAtual[_audioIndex];
				_audioIndex++;

				_player = criarAudio(arquivo);
				_player.FinishedPlaying += (sender, e) =>
				{
					playProximo();
				};

				playProximo();
				//_player.Play();

			}
			else {
				//_player.Dispose();
				_player = null;
			}
		}

		public void play(string[] arquivos)
        {
            _audioIndex = 0;
            _audioAtual = null;
            if (_player != null)
            {
                if (_player.Playing)
                    _player.Stop();
                _player.Dispose();
                _player = null;
            }
            _audioIndex = 0;
			if(arquivos != null)
            _audioAtual = arquivos;
            playProximo();
        }

        public void play(string arquivo)
        {
            var player = criarAudio(arquivo);
            player.Play();
        }
    }
}
