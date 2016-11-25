using Radar.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
    public static class TelaUtils
    {
        private static ITela _tela;

        public static float Largura
        {
            get {
                if (_tela == null)
                    _tela = DependencyService.Get<ITela>();
                return _tela.pegarLargura();
            }
        }

		public static float LarguraSemPixel
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarLarguraSemPixel();
			}
		}

		public static float AlturaSemPixel
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarAlturaSemPixel();
			}
		}

		public static float LarguraDPI
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarLarguraDPI();
			}
		}

		public static float AlturaDPI
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarAlturaDPI();
			}
		}

        public static float Altura {
            get
			{
                if (_tela == null)
                    _tela = DependencyService.Get<ITela>();
                return _tela.pegarAltura();
            }
        }

		public static string Orientacao
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarOrientacao();
			}
		}

		public static string Dispositivo
		{
			get
			{
				if (_tela == null)
					_tela = DependencyService.Get<ITela>();
				return _tela.pegarDispositivo();
			}
		}
    }
}
