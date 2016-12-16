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
using Android;

[assembly: UsesPermission(Manifest.Permission.ModifyAudioSettings)]

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
        Ringtone _ultimoRingtone;
        MediaPlayer _ultimoMediaPlayer;
        IList<MediaPlayer> _players;


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

        public bool CaixaSom { get; set; }

        private string pegarArquivo(string arquivo) {
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
            return path;
        }

        private void tocar(string arquivo) {
            Context context = Android.App.Application.Context;

            /*
            if (CaixaSom)
            {
                AudioManager audioManager = (AudioManager)context.GetSystemService(Context.AudioService);
                //audioManager.Mode = Mode.Normal;
                var maxVolume = audioManager.GetStreamMaxVolume(Android.Media.Stream.Music);
                var volume = (int)Math.Floor(maxVolume * (_volume / 15));
                audioManager.SetStreamVolume(Android.Media.Stream.Music, volume, VolumeNotificationFlags.PlaySound);
                //audioManager.Mode = Mode.InCall;
                audioManager.SpeakerphoneOn = true;
            }
            */

            var path = pegarArquivo(arquivo);
            switch (_canal)
            {
                case AudioCanalEnum.Alarme:
                    if (_ultimoRingtone != null)
                        _ultimoRingtone.Stop();
                    _ultimoRingtone = RingtoneManager.GetRingtone(context, Android.Net.Uri.Parse(path));
                    _ultimoRingtone.StreamType = Android.Media.Stream.Alarm;
                    _ultimoRingtone.Play();
                    break;
                case AudioCanalEnum.Musica:
                case AudioCanalEnum.Notificacao:
                    if (_ultimoMediaPlayer != null)
                        _ultimoMediaPlayer.Stop();
                    _ultimoMediaPlayer = MediaPlayer.Create(context, Android.Net.Uri.Parse(path));
                    float volume = _volume / 15;
                    _ultimoMediaPlayer.SetVolume(volume, volume);
                    _ultimoMediaPlayer.SetAudioStreamType(Android.Media.Stream.Music);
                    _ultimoMediaPlayer.Start();
                    break;
                    /*
                    if (_ultimoRingtone != null)
                        _ultimoRingtone.Stop();
                    _ultimoRingtone = RingtoneManager.GetRingtone(context, Android.Net.Uri.Parse(path));
                    _ultimoRingtone.StreamType = Android.Media.Stream.Notification;
                    _ultimoRingtone.Play();
                    break;
                    */
            }
        }

        private MediaPlayer criarAudio(string arquivo) {
            var path = pegarArquivo(arquivo);
            Context context = Android.App.Application.Context;
            var player = MediaPlayer.Create(context, Android.Net.Uri.Parse(path));
            player.SetAudioStreamType(Android.Media.Stream.Music);
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
            if (_players != null && _players.Count > 0) {
                foreach (var playerOld in _players) {
                    if (playerOld != null && playerOld.IsPlaying) {
                        playerOld.Stop();
                    }
                }
            }

            _players = new List<MediaPlayer>();
            foreach (var arquivo in arquivos)
                _players.Add(criarAudio(arquivo));
            MediaPlayer player = null, playerAnterior = null;
            for (int i = _players.Count - 1; i >= 0; i--)
            {
                player = _players[i];
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
            //var player = criarAudio(arquivo);
            //player.Start();
            tocar(arquivo);
        }
    }
}