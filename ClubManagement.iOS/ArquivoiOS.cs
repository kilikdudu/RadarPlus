using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubManagement.IBLL;
using ClubManagement.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ArquivoiOS))]

namespace ClubManagement.iOS
{
    public class ArquivoiOS : IArquivo
    {
        public byte[] abrir(string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public string abrirTexto(string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public bool existe(string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public void salvar(string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public void salvarTexto(string nomeArquivo)
        {
            throw new NotImplementedException();
        }
    }
}