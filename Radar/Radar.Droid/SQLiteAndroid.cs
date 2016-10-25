using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Radar.Droid;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLiteAndroid))]

namespace Radar.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "radar.sqlite";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {

                Context context = Android.App.Application.Context;
                Stream origem = context.Assets.Open(sqliteFilename);
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