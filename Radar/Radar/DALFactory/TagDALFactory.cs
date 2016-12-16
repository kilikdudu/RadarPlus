using Radar.DALSQLite;
using Radar.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.DALFactory
{
    public class TagDALFactory
    {
        private static ITagDAL _Tag;

        public static ITagDAL create()
        {
            if (_Tag == null)
                _Tag = new TagDALSQLite();
            return _Tag;
        }
    }
}
