using ClubManagement.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Utils
{
    public static class MensagemUtils
    {
        private static IMensagem _mensagem;

        public static void avisar(string mensagem)
        {
            avisar(String.Empty, mensagem);
        }

        public static void avisar(string titulo, string mensagem)
        {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            _mensagem.exibirAviso(titulo, mensagem);
        }

        public static bool notificar(int id, string titulo, string mensagem)
        {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.notificar(id, titulo, mensagem);
        }

        public static bool notificarPermanente(int id, string titulo, string mensagem) {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.notificarPermanente(id, titulo, mensagem);
        }

        public static bool pararNotificaoPermanente(int id) {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.pararNotificaoPermanente(id);
        }

        public static bool notificarGravacaoPercurso() {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.notificarGravacaoPercurso();
        }

        public static bool pararNotificaoPercurso() {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.pararNotificaoPercurso();
        }

        public static bool enviarEmail(string para, string titulo, string mensagem)
        {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            return _mensagem.enviarEmail(para, titulo, mensagem);
        }

        public static void vibrar(int milisegundo)
        {
            if (_mensagem == null)
                _mensagem = DependencyService.Get<IMensagem>();
            _mensagem.vibrar(milisegundo);
        }
    }
}
