using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Radar.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]

namespace Radar.iOS
{
    public class SQLiteiOS
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "radar.sqlite";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                //Stream origem = context.Assets.Open(sqliteFilename);
                Stream origem = File.Open(sqliteFilename, FileMode.Open, FileAccess.Read);
                FileStream destino = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                origem.CopyTo(destino);
                origem.Close();
                destino.Close();
                //writeStream.Write()
                //ReadWriteStream(input, writeStream);
            }
            SQLiteConnection cnn = new SQLiteConnection(path);
            return cnn;
        }
    }
}