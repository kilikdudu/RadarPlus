using ClubManagement.IBLL;
using ClubManagement.iOS;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(DownloaderiOS))]

namespace ClubManagement.iOS
{
    public class DownloaderiOS : IDownloader
    {
        public EventHandler aoCancelar
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public EventHandler aoCompletar
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public EventHandler<AoProcessarArgs> aoProcessar
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string NomeArquivo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void cancelar()
        {
            throw new NotImplementedException();
        }

        public void download(string url, string nomeArquivo)
        {
            throw new NotImplementedException();
        }
    }
}
