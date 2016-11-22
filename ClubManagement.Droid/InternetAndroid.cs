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
using ClubManagement.IBLL;
using Java.Lang;
using Java.IO;
using Xamarin.Forms;
using ClubManagement.Droid;

[assembly: Dependency(typeof(InternetAndroid))]

namespace ClubManagement.Droid
{
    public class InternetAndroid : IInternet
    {
        public bool estarConectado()
        {
            Runtime runtime = Runtime.GetRuntime();
            try {
                Java.Lang.Process ipProcess = runtime.Exec("/system/bin/ping -c 1 8.8.8.8");
                int exitValue = ipProcess.WaitFor();
                return (exitValue == 0);
            }
            catch (IOException e) {
                e.PrintStackTrace();
            }
            catch (InterruptedException e) {
                e.PrintStackTrace();
            }
            return false;
        }
    }
}