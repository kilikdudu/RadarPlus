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
using Xamarin.Forms;
using Radar.Droid;
using Android.Media;
using Java.Lang;
using System.IO;

[assembly: Dependency(typeof(SoundRecorderAndroid))]

namespace Radar.Droid
{
    public class SoundRecorderAndroid: ISoundRecorder
    {
        AudioRecord audRecorder;
        AudioTrack audioTrack;
        volatile bool _isRecording = false;
        private byte[] audioBuffer;
        private int audioData;
        public static string wavPath;
        byte[] audioDataBytes;

        public void PlayRecord()
        {
            new Thread(delegate ()
            {
                PlayAudioTrack(audioDataBytes);
            }).Start();
        }

        public void Record()
        {
            _isRecording = true;
            new Thread(delegate ()
            {
                RecordAudio();
            }).Start();
        }

        public void Stop()
        {
            if (_isRecording == true)
            {
                _isRecording = false;
                audRecorder.Stop();
                audioDataBytes = File.ReadAllBytes(wavPath);
                audRecorder.Release();
            }
        }

        private void PlayAudioTrack(byte[] audBuffer)
        {
            try
            {
                audioTrack = new AudioTrack(
                    Android.Media.Stream.Music,
                    11025,  
                    ChannelOut.Mono,
                    Android.Media.Encoding.Pcm16bit,
                    audBuffer.Length,
                    AudioTrackMode.Stream
                );

                audioTrack.SetNotificationMarkerPosition(audBuffer.Length / 2);
                //audioTrack.SetPlaybackPositionUpdateListener(this);
                audioTrack.Play();

                audioTrack.Write(audBuffer, 0, audBuffer.Length);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Show something I'm giving up on you!!!");
                MessagingCenter.Send<ISoundRecorder, bool>(this, "ErrorWhileReplaying", true);
            }

        }

        private void RecordAudio()
        {
            if (File.Exists(wavPath))
                File.Delete(wavPath);

            System.IO.Stream outputStream = System.IO.File.Open(wavPath, FileMode.CreateNew);
            BinaryWriter bWriter = new BinaryWriter(outputStream);

            int bufferSize = AudioRecord.GetMinBufferSize(11025,
                ChannelIn.Mono, Android.Media.Encoding.Pcm16bit);

            audioBuffer = new byte[bufferSize];

            audRecorder = new AudioRecord(
                // Hardware source of recording.
                AudioSource.Mic,
                // Frequency
                11025,
                // Mono or stereo
                ChannelIn.Mono,
                // Audio encoding
                Android.Media.Encoding.Pcm16bit,
                // Length of the audio clip.
                bufferSize
            );
            audRecorder.StartRecording();

            while (_isRecording == true)
            {
                try
                {
                    /// Keep reading the buffer while there is audio input.
                    audioData = audRecorder.Read(audioBuffer, 0, audioBuffer.Length);
                    bWriter.Write(audioBuffer);
                }
                catch (System.Exception ex)
                {
                    System.Console.Out.WriteLine(ex.Message);
                    MessagingCenter.Send<ISoundRecorder, bool>(this, "finishReplaying", true);
                    break;
                }
            }

            outputStream.Close();
            bWriter.Close();
        }

        public void Pause()
        {
            try
            {
                if (audioTrack == null)
                    return;

                if (audRecorder != null && audRecorder.RecordingState == RecordState.Recording)
                    return;

                audioTrack.Pause();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Show something I'm giving up on you!!!");
                MessagingCenter.Send<ISoundRecorder, bool>(this, "ErrorWhileReplaying", true);
            }

        }

        public void deleteRecord()
        {
            if (audioTrack != null)
            {
                //audioTrack.Dispose();
                //audioTrack = null;
                audioTrack.Release();
            }

            if (audRecorder != null)
            {
                //audRecorder.Dispose();
                //audRecorder = null;
                audRecorder.Release();
            }
        }

        public void OnMarkerReached(AudioTrack track)
        {
            Console.WriteLine("send message to parent");
            MessagingCenter.Send<ISoundRecorder, bool>(this, "finishReplaying", true);
        }
    }
}