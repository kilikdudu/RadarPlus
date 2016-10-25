using Radar.IDAL;
using Radar.Model;
using SQLite;
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

        /// <summary>
        /// Lista os radares dentro de um certo raio usando Seno e Coseno.
        /// </summary>
        /// <param name="latitudeCos">Coseno da Latitude</param>
        /// <param name="longitudeCos">Coseno da Longitude</param>
        /// <param name="latitudeSin">Seno da Latitude</param>
        /// <param name="longitudeSin">Seno da Longitude</param>
        /// <param name="distanciaCos">Coseno do raio da distancia</param>
        /// <returns>Lista de radares no raio</returns>
        public IList<RadarInfo> listar(double latitudeCos, double longitudeCos, double latitudeSin, double longitudeSin, double distanciaCos) {
            lock (locker)
            {
                string query =
                    "select * from radar where (" +
                    "((latsin * " + latitudeSin.ToString().Replace(',', '.') + ") + (latcos * " + latitudeCos.ToString().Replace(',', '.') + ")) * " +
                    "((loncos * " + longitudeCos.ToString().Replace(',', '.') + ") + (lonsin * " + longitudeSin.ToString().Replace(',', '.') + "))" +
                    ") > " + distanciaCos.ToString().Replace(',', '.');
                return database.Query<RadarInfo>(query);
                /*
                return database.Query<RadarInfo>(
                    "select * from radar where ((latsin * ?) + (latcos * ?) * (loncos * ?) + (lonsin * ?)) > ?",
                    new object[5] { latitudeSin, latitudeCos, longitudeCos, longitudeSin, distanciaCos }
                );
                */
            }
        }

        /// <summary>
        /// Lista dos radares dentro de uma região
        /// </summary>
        /// <param name="latitude">Latitude do centro da região</param>
        /// <param name="longitude">Longitude do centro da região</param>
        /// <param name="latitudeDelta">Delta da latitude</param>
        /// <param name="longitudeDelta">Delta da longitude</param>
        /// <returns>Lista de radares da região</returns>
        public IList<RadarInfo> listar(double latitude, double longitude, double latitudeDelta, double longitudeDelta)
        {
            lock (locker)
            {
                return database.Query<RadarInfo>(
                    "select * from radar where lon between ? and ? and lat between ? and ?",
                    new object[4] {
                        longitude - longitudeDelta,
                        longitude + longitudeDelta,
                        latitude - latitudeDelta,
                        latitude + latitudeDelta
                    }
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
