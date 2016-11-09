using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radar.BLL;
using Xamarin.Forms;
using Radar.iOS;
using UIKit;

[assembly: Dependency(typeof(TelaiOS))]

namespace Radar.iOS
{
    public class TelaiOS : ITela
    {
        public float pegarAltura()
        {
            return (float)UIScreen.MainScreen.Bounds.Width;
        }

        public float pegarLargura()
        {
            return (float)UIScreen.MainScreen.Bounds.Height;
        }
    }
}