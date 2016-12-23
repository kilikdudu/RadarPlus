using System;
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
			return null;
        }

        public string abrirTexto(string nomeArquivo)
        {
			return null;
        }

        public bool existe(string nomeArquivo)
        {
			return true;
        }

        public void salvar(string nomeArquivo, byte[] buffer)
        {
			
        }

        public void salvarTexto(string nomeArquivo)
        {
			
        }
    }
}