using ClubManagement.IBLL;
using System;
using System.Collections.Generic;
using System.Text;
using ClubManagement.Helpers;
using ClubManagement.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeocoderiOS))]

namespace ClubManagement.iOS
{
    public class GeocoderiOS : IGeocoder
    {
        public void pegarAsync(float latitude, float logradouro, GeoEnderecoEventHandler callback)
        {
            throw new NotImplementedException();
        }
    }
}
