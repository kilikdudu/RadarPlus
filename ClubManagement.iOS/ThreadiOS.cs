using ClubManagement.IBLL;
using ClubManagement.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThreadiOS))]

namespace ClubManagement.iOS
{
    public class ThreadiOS : IThread
    {
        public void RunOnUiThread(Action acao)
        {
            CurrentDelegateUtils.Current.InvokeOnMainThread(acao);
        }
    }
}
