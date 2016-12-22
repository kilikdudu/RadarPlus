using Radar.DALFactory;
using Radar.IDAL;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public class GastoBLL
    {
        private IGastoDAL _db;

        public GastoBLL() {
            _db = GastoDALFactory.create();
        }

        public IList<GastoInfo> listar(int idGasto) {
            return _db.listar(idGasto);
        }

        public GastoInfo pegar(int id) {
            return _db.pegar(id);
        }

        public int gravar(GastoInfo gasto) {
            return _db.gravar(gasto);
        }

        public void excluir(int id) {
            _db.excluir(id);
        }
    }
}
