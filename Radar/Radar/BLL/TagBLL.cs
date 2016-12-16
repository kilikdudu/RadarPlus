using Radar.DALFactory;
using Radar.DALSQLite;
using Radar.IDAL;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Utils;
using Xamarin.Forms.Maps;

namespace Radar.BLL
{
    public class TagBLL
    {
        //private const int TIPO_RADAR_NORMAL = 1;

        private ITagDAL _db;
       
        public TagBLL() {
            _db = TagDALFactory.create();
        }

        public IList<TagInfo> listar()
        {
            return _db.listar();
        }

        public IList<TagInfo> listarTag(int idTag)
        {
            return _db.listarTag(idTag);
        }

        public TagInfo pegar(int idTag)
        {
            return _db.pegar(idTag);
        }

        public int gravar(TagInfo radar)
        {
			return _db.gravar(radar);
        }

		       
        public void excluir(int idTag)
        {
            _db.excluir(idTag);
        }
       	
    }
}
