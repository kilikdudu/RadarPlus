using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
    public static class MensagemUtils
    {
        public static void avisar(string mensagem)
        {
            avisar(String.Empty, mensagem);
        }

        public static void avisar(string titulo, string mensagem)
        {
            DependencyService.Get<IMensagem>().exibirAviso(titulo, mensagem);
        }

        public static bool notificar(int id, string titulo, string mensagem)
        {
            return DependencyService.Get<IMensagem>().notificar(id, titulo, mensagem);
        }
    }
}
