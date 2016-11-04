using Radar.DALFactory;
using Radar.IDAL;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
	public class PreferenciaBLL
	{
		private IPreferenciaDAL _preferenciaDB;

		public PreferenciaBLL()
		{
			_preferenciaDB = PreferenciaDALFactory.create();
		}

		public IList<PreferenciaInfo> listar()
		{
			IList<PreferenciaInfo> preferencias = _preferenciaDB.listar();

			return preferencias;
		}

		public string pegar(string preferencia)
		{
			PreferenciaInfo _preferencia = _preferenciaDB.pegar(preferencia);
			if (_preferencia != null)
			{
				return _preferencia.valor;
			}
			else {
				return "0";
			}
		}

		public bool pegarBooleano(string preferencia)
		{
			PreferenciaInfo _preferencia = _preferenciaDB.pegar(preferencia);
			if (_preferencia != null)
			{
				if (_preferencia.valor == "1")
				{
					return true;
				}
				else {
					return false;
				}

			}
			else {
				return false;
			}
		}

		public int gravar(string preferencia, int valor)
		{
			PreferenciaInfo pref = new PreferenciaInfo() { 
				preferencia = preferencia,
				valor = valor.ToString()
			};
			//percurso.Id = _percursoDB.gravar(percurso);
			return _preferenciaDB.gravar(pref);
			//return percurso.Id;
		}


		public void excluir(string preferencia)
		{
			
		}

}
}
