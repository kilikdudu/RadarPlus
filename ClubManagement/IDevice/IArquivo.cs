using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IDevice
{
    public interface IArquivo
    {
        bool existe(string nomeArquivo);
        string abrirTexto(string nomeArquivo);
        void salvarTexto(string nomeArquivo);
        byte[] abrir(string nomeArquivo);
        void salvar(string nomeArquivo);
    }
}
