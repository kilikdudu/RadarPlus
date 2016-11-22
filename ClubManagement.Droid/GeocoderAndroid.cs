using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClubManagement.IBLL;
using ClubManagement.Model;
using Xamarin.Forms;
using ClubManagement.Droid;
using System.Threading;
using Android.Locations;
using ClubManagement.Helpers;

[assembly: Dependency(typeof(GeocoderAndroid))]

namespace ClubManagement.Droid
{
    public class GeocoderAndroid : IGeocoder
    {
        public void pegarAsync(float latitude, float longitude, GeoEnderecoEventHandler callback)
        {
            new Thread(new ThreadStart(() => {
                Context context = Android.App.Application.Context;
                var geo = new Geocoder(context);
                var addresses = geo.GetFromLocation(latitude, longitude, 1);

                var geoEndereco = addresses.Take(1).SingleOrDefault();
                if (geoEndereco != null)
                {
                    var endereco = new GeoEnderecoInfo {
                        Logradouro = geoEndereco.Thoroughfare,
                        Complemento = geoEndereco.SubThoroughfare,
                        Bairro = geoEndereco.SubLocality,
                        Cidade = geoEndereco.Locality,
                        Uf = geoEndereco.AdminArea,
                        CEP = geoEndereco.PostalCode,
                    };
                    if (callback != null) {
                        CurrentActivityUtils.Current.RunOnUiThread(() => {
                            callback(null, new GeoEnderecoEventArgs(endereco));
                        });
                    }
                }
            })).Start();
        }
    }
}