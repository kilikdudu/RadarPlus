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
    public class TagDALSQLite: ITagDAL
    {
        SQLiteConnection database;
        static object locker = new object();

        public TagDALSQLite()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TagInfo>();
        }

        public IList<TagInfo> listar()
        {
            lock (locker)
			{
				return database.Table<TagInfo>().Take(20000).ToList();
			}
        }

        public IList<TagInfo> listarTag(int tagId)
        {
            lock (locker)
            {
                
                return (
                    from r in database.Table<TagInfo>()
					where (r.Id == tagId)
                    select r
                ).ToList();
            }
        }

        
  	    public TagInfo pegar(int idTag)
        {
            lock (locker)
            {
                return database.Table<TagInfo>().FirstOrDefault(x => x.Id == idTag);
            }
        }

        public int gravar(TagInfo tag)
        {
            lock (locker)
            {
                if (tag.Id != 0)
                {
                    return database.Update(tag);
                    //return radar.Id;
                }
                else
                {
                    return database.Insert(tag);
                }
            }
        }


        public void excluir(int idLocal)
        {
            database.Delete<TagInfo>(idLocal);
        }

		
	}
}
