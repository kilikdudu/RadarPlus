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
using Xamarin.Forms;
using Radar.Droid;
using Android.Content.Res;
using Radar.IBLL;

[assembly: Dependency(typeof(TelaAndroid))]

namespace Radar.Droid
{
    public class TelaAndroid : ITela {
        public static float Largura { get; set; }
		public static float LarguraSemPixel { get; set; }
		public static float AlturaSemPixel { get; set; }
		public static float LarguraDPI { get; set; }
		public static float AlturaDPI { get; set; }
        public static float Altura { get; set; }
        public static string Orientacao { get; set; }

        public float pegarAltura() {
            return (float)Altura;
        }

        public float pegarLargura() {
            return (float)Largura;
        }

		public float pegarLarguraSemPixel()
		{
			return (float)LarguraSemPixel;
		}

		public float pegarAlturaSemPixel()
		{
			return (float)AlturaSemPixel;
		}

		public float pegarAlturaDPI()
		{
			return (float)AlturaDPI;
		}

		public float pegarLarguraDPI()
		{
			return (float)LarguraDPI;
		}

        public string pegarOrientacao() {
            return Orientacao;
        }

    }
}