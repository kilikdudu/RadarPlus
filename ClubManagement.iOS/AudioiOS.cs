using AVFoundation;
using ClubManagement.IBLL;
using Foundation;
using Radar.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioiOS))]

namespace Radar.iOS
{
    public class AudioiOS : IAudio
    {
        public void play(string[] arquivos)
        {
            throw new NotImplementedException();
        }

        public bool play(string arquivo)
        {
            string alarme = "alarmes/" + arquivo;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, arquivo);
            if (!System.IO.File.Exists(path))
            {
                Stream origem = File.Open(alarme, FileMode.Open, FileAccess.Read);
                FileStream destino = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                origem.CopyTo(destino);
                origem.Close();
                destino.Close();
            }

            NSUrl songURL = new NSUrl(path);
            NSError err;
            AVAudioPlayer player = new AVAudioPlayer(songURL, "wav", out err);
            player.Volume = 15;
            player.NumberOfLoops = 0;
            player.Play();

            return true;
        }

        void IAudio.play(string arquivo)
        {
            throw new NotImplementedException();
        }
    }
}
