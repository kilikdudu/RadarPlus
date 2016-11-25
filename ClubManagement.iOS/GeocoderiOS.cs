using ClubManagement.IBLL;
using System;
using System.Collections.Generic;
using System.Text;
using ClubManagement.Helpers;
using ClubManagement.iOS;
using Xamarin.Forms;
using CoreLocation;
using ClubManagement.Model;
using ClubManagement.Utils;

[assembly: Dependency(typeof(GeocoderiOS))]

namespace ClubManagement.iOS
{
    public class GeocoderiOS : IGeocoder
    {
        public void pegarAsync(float latitude, float longitude, GeoEnderecoEventHandler callback)
        {
            var location = new CLLocation(latitude, longitude);
            var geoCoder = new CLGeocoder();
            geoCoder.ReverseGeocodeLocation(location, (placemarkers, error) => {
                if (placemarkers.Length > 0) {
                    var geoEndereco = placemarkers[0];
                    var endereco = new GeoEnderecoInfo
                    {
                        Logradouro = geoEndereco.Thoroughfare,
                        Complemento = geoEndereco.SubThoroughfare,
                        Bairro = geoEndereco.SubLocality,
                        Cidade = geoEndereco.Locality,
                        Uf = geoEndereco.AdministrativeArea,
                        CEP = geoEndereco.PostalCode,
                    };
                    if (callback != null)
                    {
                        ThreadUtils.RunOnUiThread(() => {
                            callback(null, new GeoEnderecoEventArgs(endereco));
                        });
                    }
                }
            });
        }
    }
}
