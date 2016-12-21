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
using SQLite;
using Radar.BLL;
using Radar.Model;

namespace Radar.Droid
{
    public class PreferenciaAndroid
    {
        SQLiteConnection _database;
        static object locker = new object();

        private void inicializar() {
            var sqlite = new SQLiteAndroid();
            var _database = sqlite.GetConnection();
            _database.CreateTable<PreferenciaInfo>();
        }

        private string pegarValor(string campo) {
            lock (locker)
            {
                var preferencia = _database.Table<PreferenciaInfo>().FirstOrDefault(x => x.Preferencia == campo);
                if (preferencia != null)
                    return preferencia.Valor;
            }
            return string.Empty;
        }

        public bool LigarDesligar {
            get {
                var valor = pegarValor(PreferenciaUtils.LIGAR_DESLIGAR);
                return bool.Parse(valor);
            }
        }

    }
}