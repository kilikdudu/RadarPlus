using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.IDAL
{
    public interface IRadarDAL
    {
        IList<RadarInfo> listar();
        IList<RadarInfo> listar(double latitudeCos, double longitudeCos, double latitudeSin, double longitudeSin, double distanciaCos);
        RadarInfo pegar(int idRadar);
        int gravar(RadarInfo radar);
        void excluir(int idLocal);
    }
}
