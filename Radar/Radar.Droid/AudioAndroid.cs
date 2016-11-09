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
using Radar.Utils;
using Android.Media;
using Xamarin.Forms;
using Radar.Droid;
using Java.IO;
using Android.Content.Res;
using System.IO;

[assembly: Dependency(typeof(AudioAndroid))]

namespace Radar.Droid
{
    public class AudioAndroid: IAudio
    {
        //AudioTrack _audioTrack;
        MediaPlayer _player;

        public AudioAndroid() {
            /*
            int minSize = AudioTrack.GetMinBufferSize(44100, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit);
            _audioTrack = new AudioTrack(
                Android.Media.Stream.Music,
                44100,
                ChannelOut.Mono,
                Android.Media.Encoding.Pcm16bit,
                minSize,
                AudioTrackMode.Stream
            );
            _audioTrack.Play();
            */
        }

        public bool play(string arquivo) {

            Context context = Android.App.Application.Context;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, arquivo);
            if (!System.IO.File.Exists(path))
            {
                var audioStream = context.Assets.Open("alarmes/" + arquivo);
                FileStream destino = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                audioStream.CopyTo(destino);
                audioStream.Close();
                destino.Close();
            }
            _player = MediaPlayer.Create(context, Android.Net.Uri.Parse(path));
            _player.Start();

            /*
            Context context = Android.App.Application.Context;
            var audioStream = context.Assets.Open(arquivo);
            var ms = new MemoryStream();
            audioStream.CopyTo(ms);
            byte[] audioBuffer = new byte[ms.Length];
            ms.Read(audioBuffer, 0, (int) ms.Length);
            ms.Close();
            _audioTrack.Write(audioBuffer, 0, audioBuffer.Length);
            */
            return true;
        }
    }
}