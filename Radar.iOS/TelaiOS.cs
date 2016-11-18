using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using Radar.BLL;
using Xamarin.Forms;
using Radar.iOS;
using UIKit;
using Radar.IBLL;

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

		public string pegarOrientacao()
		{
			UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
			Console.WriteLine("Orientacao: " + orientation);
			return orientation.ToString();
		}
    }
}