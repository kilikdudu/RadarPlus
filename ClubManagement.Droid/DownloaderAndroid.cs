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

[assembly: Dependency(typeof(DownloaderAndroid))]

namespace ClubManagement.Droid
{
    public class DownloaderAndroid : IDownloader
    {
        WebClient _cliente;
       
        public DownloaderAndroid()
        {
            _cliente = new WebClient();
            _cliente.DownloadProgressChanged += (sender, e) => {
            }; 
        }

        public void download(string url)
        {
            _cliente.OpenReadAsync(new Uri(url));
        }
    }
}