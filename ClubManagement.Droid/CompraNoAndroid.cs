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
using ClubManagement.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(CompraNoAndroid))]

namespace ClubManagement.Droid
{
    public class CompraNoAndroid : ICompraNoApp
    {

        private void conectar() {
        }

        public bool comprar(string idProduto)
        {
            throw new NotImplementedException();
        }

        public bool possuiProduto(string idProduto)
        {
            throw new NotImplementedException();
        }
    }
}