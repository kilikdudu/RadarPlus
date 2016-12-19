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
using Xamarin.Forms;
using System.Net;
using ClubManagement.Droid;
using ClubManagement.Utils;
using ClubManagement.IBLL;

[assembly: Dependency(typeof(DownloaderAndroid))]

namespace ClubManagement.Droid
{
    public class DownloaderAndroid : IDownloader
    {
        WebClient _cliente;
        EventHandler _aoCompletar;
        EventHandler _aoCancelar;
        EventHandler<AoProcessarArgs> _aoProcessar;

        public DownloaderAndroid()
        {
            _cliente = new WebClient();
            _cliente.DownloadProgressChanged += (sender, e) => {
                if (_aoProcessar != null) {
                    Device.BeginInvokeOnMainThread(() => {
                        _aoProcessar(sender, new AoProcessarArgs(e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive));
                    });
                }
            };
            _cliente.DownloadFileCompleted += (sender, e) => {
                if (e.Cancelled)
                {
                    if (_aoCancelar != null)
                        _aoCancelar(sender, e);
                }
                else {
                    if (_aoCompletar != null)
                        _aoCompletar(sender, e);
                }
            };
        }

        private string _nomeArquivo;

        public string NomeArquivo {
            get {
                return _nomeArquivo;
            }
        }

        public EventHandler aoCompletar
        {
            get
            {
                return _aoCompletar;
            }

            set
            {
                _aoCompletar = value;
            }
        }

        public EventHandler<AoProcessarArgs> aoProcessar
        {
            get
            {
                return _aoProcessar;
            }

            set
            {
                _aoProcessar = value;
            }
        }

        public EventHandler aoCancelar
        {
            get
            {
                return _aoCancelar;
            }

            set
            {
                _aoCancelar = value;
            }
        }

        public void download(string url, string nomeArquivo)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            _nomeArquivo = System.IO.Path.Combine(documentsPath, nomeArquivo);
            _cliente.DownloadFileAsync(new Uri(url), _nomeArquivo);
        }

        public void cancelar()
        {
            _cliente.CancelAsync();
        }
    }
}