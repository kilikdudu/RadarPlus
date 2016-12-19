using AVFoundation;
using ClubManagement.IBLL;
using Foundation;
using Radar.iOS;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ClubManagement.Model;
using AudioToolbox;
using System.Threading.Tasks;
using CoreMedia;
using UIKit;

[assembly: Dependency(typeof(AudioiOS))]

namespace Radar.iOS
{
    public class AudioiOS : IAudio
    {
        private const string BACKGROUND = "Background";

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

        public bool CaixaSom { get; set; }

        AVAudioPlayer criarAudio(string arquivo)
		{
			//UIApplicationState sharedApplication = new UIApplicationState();
			NSUrl songURL = new NSUrl(arquivo);
			NSError err;

			var state = UIApplication.SharedApplication.ApplicationState;
			if (state.ToString() != BACKGROUND)
			{
				AVAudioPlayer player = new AVAudioPlayer(songURL, "mp3", out err);
				player.Volume = Volume;
				player.NumberOfLoops = 0;
				return player;
			}
			else {

				NSUrl url = NSUrl.FromFilename(arquivo);
				//SystemSound notificationSound = SystemSound.FromFile(NotificationSoundPath);
				SystemSound mySound = new SystemSound(url);

				mySound.AddSystemSoundCompletion(SystemSound.Vibrate.PlaySystemSound);
				var asset = AVAsset.FromUrl(NSUrl.FromFilename(arquivo));

				CMTime audioDuration = asset.Duration;
				double tempo = audioDuration.Value / audioDuration.TimeScale;

				mySound.PlaySystemSound();
				esperaFinalizarSom(tempo);
			}

			return null;
		}

		public void esperaFinalizarSom(double tempo)
		{
			int tempoInt = Convert.ToInt32(tempo);
			if (tempoInt > 5 )
			{
				tempoInt = Convert.ToInt32(tempo) * 1000 + 1000;
			}
			else {
				tempoInt = Convert.ToInt32(tempo) * 1000 + 1000;
			}

			Task.Delay(tempoInt).Wait();
		}

		private void playProximo()
		{
			if (_audioAtual != null && _audioIndex < _audioAtual.Count)
			{
				string arquivo = _audioAtual[_audioIndex];
				_audioIndex++;
				_player = criarAudio(arquivo);
				var state = UIApplication.SharedApplication.ApplicationState;
				if (state.ToString() != BACKGROUND)
				{
					_player.FinishedPlaying += (sender, e) =>
					{
						playProximo();

					} ;
					_player.Play();
				}
				else {
					playProximo();
				}


			}
			else {
				//_player.Dispose();
				_player = null;
			}
		}

		public void play(string[] arquivos)
        {
            stop();
            if (arquivos != null)
            _audioAtual = arquivos;
            playProximo();
        }

        public void play(string arquivo)
        {
            stop();
			_player = criarAudio(arquivo);
			var state = UIApplication.SharedApplication.ApplicationState;
			if (state.ToString() != BACKGROUND)
			{
                _player.Play();
			}
        }

        public void stop() {
            if (_player != null)
            {
                 if (_player.Playing)
                    _player.Stop();
                _player.Dispose();
                _player = null;
            }
            _audioIndex = 0;
            _audioAtual = null;
        }
    }
}

