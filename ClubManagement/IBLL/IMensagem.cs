using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface IMensagem
    {
        void exibirAviso(string Titulo, string Mensagem);
        bool notificar(int id, string titulo, string descricao);
        bool notificar(int id, string titulo, string descricao, double velocidade);
        bool notificarPermanente(int id, string titulo, string descricao, int idParar, string textoParar, string acaoParar);
        bool pararNotificaoPermanente(int id);
		bool notificariOS(int id, string titulo, string descricao, double velocidade, string audio);

		//bool notificarGravacaoPercurso();
		//bool pararNotificaoPercurso();
		bool enviarEmail(string para, string titulo, string mensagem);
        void vibrar(int milisegundo);
    }
}
