using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Radar.iOS;
using AVFoundation;
using Foundation;
using Radar.Utils;
using System.IO;
using Radar.IBLL;

[assembly: Dependency(typeof(SoundRecorderiOS))]

namespace Radar.iOS
{
    public class SoundRecorderiOS: ISoundRecorder
    {
        AVAudioRecorder recorder;
        AVAudioPlayer player;
        NSUrl audioFilePath;
        byte[] audioDataBytes;

        public void PlayRecord()
        {
            try
            {
                NSError error = null;
                AVAudioSession.SharedInstance().SetCategory(AVAudioSession.CategoryPlayback, out error);
                if (error != null)
                    throw new Exception(error.DebugDescription);

                player = AVAudioPlayer.FromData(NSData.FromArray(audioDataBytes));
                player.FinishedPlaying += (sender, e) => {
                    Console.WriteLine("send message to parent");
                    MessagingCenter.Send<ISoundRecorder, bool>(this, "finishReplaying", true);
                };
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem playing back audio: ");
                Console.WriteLine(ex.Message);
            }
        }

        public void Record()
        {
            Console.WriteLine("Begin Recording");

            var session = AVAudioSession.SharedInstance();

            NSError error = null;
            session.SetCategory(AVAudioSession.CategoryRecord, out error);
            if (error != null)
            {
                Console.WriteLine(error);
                return;
            }

            session.SetActive(true, out error);
            if (error != null)
            {
                Console.WriteLine(error);
                return;
            }

            if (!PrepareAudioRecording())
            {
                return;
            }

            if (!recorder.Record())
            {
                return;
            }
        }

        bool PrepareAudioRecording()
        {
            audioFilePath = CreateOutputUrl();

            var audioSettings = new AudioSettings
            {
                SampleRate = 44100,
                Format = AudioToolbox.AudioFormatType.MPEG4AAC,
                NumberChannels = 1,
                AudioQuality = AVAudioQuality.High
            };

            //Set recorder parameters
            NSError error;

            recorder = AVAudioRecorder.Create(audioFilePath, audioSettings, out error);
            if (error != null)
            {
                Console.WriteLine(error);
                return false;
            }

            //Set Recorder to Prepare To Record
            if (!recorder.PrepareToRecord())
            {
                recorder.Dispose();
                recorder = null;
                return false;
            }

            recorder.FinishedRecording += OnFinishedRecording;

            return true;
        }

        void OnFinishedRecording(object sender, AVStatusEventArgs e)
        {
            recorder.Dispose();
            recorder = null;
            Console.WriteLine("Done Recording (status: {0})", e.Status);
        }

        NSUrl CreateOutputUrl()
        {
            string fileName = string.Format("Myfile{0}.aac", DateTime.Now.ToString("yyyyMMddHHmmss"));
            string tempRecording = Path.Combine(Path.GetTempPath(), fileName);

            return NSUrl.FromFilename(tempRecording);
        }

        public void Stop()
        {
            if (recorder == null)
                return;

            recorder.Stop();

            NSError error = null;
            NSData audioData = NSData.FromFile(audioFilePath.Path, 0, out error);
            if (error != null)
            {
                Console.WriteLine(error);
                return;
            }

            audioDataBytes = new byte[audioData.Length];
            System.Runtime.InteropServices.Marshal.Copy(audioData.Bytes, audioDataBytes, 0, Convert.ToInt32(audioData.Length));
        }

        public void Pause()
        {
            if (player == null)
                return;

            if (recorder != null && recorder.Recording)
                return;

            player.Pause();
        }

        public void deleteRecord()
        {
            if (player != null)
            {
                player.Dispose();
                player = null;
            }

            if (recorder != null)
            {
                recorder.Dispose();
                recorder = null;
            }
        }
    }
}