using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ClubManagement.IBLL;
using Xamarin.Forms;
using ClubManagement.iOS;

[assembly: Dependency(typeof(InternetiOS))]

namespace ClubManagement.iOS
{
    public class InternetiOS : IInternet
    {
        public bool estarConectado()
        {
            return false;
        }
    }
}