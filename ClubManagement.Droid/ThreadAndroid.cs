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
using ClubManagement.Droid;
using ClubManagement.Utils;
using ClubManagement.IDevice;

[assembly: Dependency(typeof(ThreadAndroid))]

namespace ClubManagement.Droid
{
    public class ThreadAndroid : IThread
    {
        public void RunOnUiThread(Action acao)
        {
            if (CurrentActivityUtils.Current == null)
                throw new Exception("'CurrentActivityUtils.Current' não foi inicializado!");
            CurrentActivityUtils.Current.RunOnUiThread(acao);
        }
    }
}