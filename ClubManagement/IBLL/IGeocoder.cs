using ClubManagement.Helpers;
using ClubManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface IGeocoder
    {
        void pegarAsync(float latitude, float logradouro, GeoEnderecoEventHandler callback);
    }
}
