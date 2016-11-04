using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.BLL
{
    public static class ThreadUtils
    {
        private static IThread _thread;

        public static void RunOnUiThread(Action acao) {
            if (_thread == null)
                _thread = DependencyService.Get<IThread>();
            _thread.RunOnUiThread(acao);
        }
    }
}
