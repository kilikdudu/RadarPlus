using ClubManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Utils
{
    public static class NavegacaoUtils
    {
        private static NavigationPage _DetailPage;

        public static NavigationPage DetailPage {
            get {
                return _DetailPage;
            }
            set {
                _DetailPage = value;
            }
        }

        public static Task PushAsync(Page page, bool animated = true) {
            return NavigationX.create(_DetailPage).PushAsync(page, animated);
        }

    }
}
