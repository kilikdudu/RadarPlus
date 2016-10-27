using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Utils
{
    public interface IMensagem
    {
        void exibirAviso(string Titulo, string Mensagem);
        bool notificar(int id, string titulo, string descricao);
        bool notificarGravacaoPercurso();
        bool pararNotificaoPercurso();
    }
}
