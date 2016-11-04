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
using Radar.BLL;
using Radar.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThreadAndroid))]

namespace Radar.Droid
{
    public class ThreadAndroid : IThread
    {
        public static Activity CurrentActivity;

        public void RunOnUiThread(Action acao)
        {
            CurrentActivity.RunOnUiThread(acao);
        }
    }
}