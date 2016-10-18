using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Factory
{
    public static class RadarFactory
    {
        private static RadarBLL _Radar;

        public static RadarBLL create() {
            if (_Radar == null)
                _Radar = new RadarBLL();
            return _Radar;
        }
    }
}
