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
using ClubManagement.IBLL;
using Xamarin.Forms;
using ClubManagement.Droid;
using System.IO;

[assembly: Dependency(typeof(ArquivoAndroid))]

namespace ClubManagement.Droid
{
    public class ArquivoAndroid : IArquivo
    {
        public byte[] abrir(string nomeArquivo)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, nomeArquivo);
            return File.ReadAllBytes(filePath);
        }

        public string abrirTexto(string nomeArquivo)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, nomeArquivo);
            return File.ReadAllText(filePath);
        }

        public bool existe(string nomeArquivo)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, nomeArquivo);
            return File.Exists(filePath);
        }

        public void salvar(string nomeArquivo, byte[] buffer)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, nomeArquivo);
            File.WriteAllBytes(filePath, buffer);
        }

        public void salvarTexto(string nomeArquivo)
        {
            throw new NotImplementedException();
        }
    }
}