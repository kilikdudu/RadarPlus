using ClubManagement.Helpers;
using ClubManagement.IBLL;
using ClubManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Utils
{
    public static class GeocoderUtils
    {
        private static IGeocoder _geocoder;

        public static void pegarAsync(float latitude, float longitude, GeoEnderecoEventHandler callback)
        {
            if (_geocoder == null)
                _geocoder = DependencyService.Get<IGeocoder>();
            _geocoder.pegarAsync(latitude, longitude, callback);
        }
    }
}
