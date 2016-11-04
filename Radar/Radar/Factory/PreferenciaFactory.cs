using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Factory
{
	public static class PreferenciaFactory
	{
		private static PreferenciaBLL _Preferencia;

		public static PreferenciaBLL create()
		{
			if (_Preferencia == null)
				_Preferencia = new PreferenciaBLL();
			return _Preferencia;
		}
	}
}
