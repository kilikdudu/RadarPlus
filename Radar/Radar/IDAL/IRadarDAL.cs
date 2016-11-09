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
        IList<RadarInfo> listar(bool usuario);
        IList<RadarInfo> listar(double latitudeCos, double longitudeCos, double latitudeSin, double longitudeSin, double distanciaCos);
        IList<RadarInfo> listar(double latitude, double longitude, double latitudeDelta, double longitudeDelta);
        RadarInfo pegar(int idRadar);
        int gravar(RadarInfo radar);
        void excluir(int idLocal);
    }
}
