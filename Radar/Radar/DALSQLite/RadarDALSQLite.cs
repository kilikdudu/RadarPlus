using Radar.IDAL;
using Radar.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.DALSQLite
{
    public class RadarDALSQLite: IRadarDAL
    {
        SQLiteConnection database;
        static object locker = new object();

        public RadarDALSQLite()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<RadarInfo>();
        }

        public IList<RadarInfo> listar()
        {
            lock (locker)
            {
                return (from i in database.Table<RadarInfo>() select i).ToList();
            }
        }

        public IList<RadarInfo> listar(double latitudeCos, double longitudeCos, double latitudeSin, double longitudeSin, double distanciaCos) {
            lock (locker)
            {
                /*
                return (
                    from r in database.Table<RadarInfo>()
                    where (
                        (r.latsin * latitudeSin) + (r.latcos * latitudeCos) *
                        (r.lonsin * longitudeSin) + (r.loncos * longitudeCos) > distanciaCos
                    )
                    select r
                ).ToList();
                */
                return database.Query<RadarInfo>(
                    "select * from radar where ((latsin * ?) + (latcos * ?) * (lonsin * ?) + (loncos * ?)) > ?",
                    new object[5] { latitudeSin, latitudeCos, longitudeSin, longitudeCos, distanciaCos }
                );
            }
        }

        public RadarInfo pegar(int idRadar)
        {
            lock (locker)
            {
                return database.Table<RadarInfo>().FirstOrDefault(x => x.Id == idRadar);
            }
        }

        public int gravar(RadarInfo radar)
        {
            lock (locker)
            {
                if (radar.Id != 0)
                {
                    database.Update(radar);
                    return radar.Id;
                }
                else
                {
                    return database.Insert(radar);
                }
            }
        }

        public void excluir(int idLocal)
        {
            database.Delete<RadarInfo>(idLocal);
        }
    }
}
