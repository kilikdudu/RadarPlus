using ClubManagement.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Utils
{
    public class DownloaderUtils
    {
        private IDownloader _cliente;
        private ProgressBarPopUp _janela;

        public DownloaderUtils() {
            _cliente = DependencyService.Get<IDownloader>();
        }

        public void download(string url) {
            _janela = new ProgressBarPopUp();
            Application.Current.MainPage.Navigation.PushModalAsync(_janela);
            _cliente.download(url);
        }
    }
}
