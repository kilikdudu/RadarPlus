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

		public float pegarLarguraSemPixel()
		{
			return (float)UIScreen.MainScreen.Bounds.Width;
		}

		public float pegarAlturaSemPixel()
		{
			return (float)UIScreen.MainScreen.Bounds.Height;
		}

		public string pegarOrientacao()
		{
			UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
			Console.WriteLine("Orientacao: " + orientation);
			return orientation.ToString();
		}

		public float pegarLarguraDPI()
		{
			return (float)UIScreen.MainScreen.Bounds.Width;
		}

		public float pegarAlturaDPI()
		{

			return (float)UIScreen.MainScreen.Bounds.Height;
		}

		public string pegarDispositivo()
		{
			UIDevice ui = new UIDevice();
			return ui.UserInterfaceIdiom.ToString();

		}
	}
}