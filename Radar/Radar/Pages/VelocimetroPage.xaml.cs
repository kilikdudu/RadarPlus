using Radar.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radar.Pages
{
    public partial class VelocimetroPage : ContentPage
    {
        private static VelocimetroPage _velocimetroPageAtual;

        public static VelocimetroPage Atual
        {
            get
            {
                return _velocimetroPageAtual;
            }
            private set
            {
                _velocimetroPageAtual = value;
            }
        }

        public Velocimetro Velocimentro {
            get {
                return this.FindByName<Velocimetro>("velocimentroControl");
            }
        }

        public VelocimetroPage()
        {
            InitializeComponent();
            //Title = "Velocimetro";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _velocimetroPageAtual = this;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _velocimetroPageAtual = null;
        }
    }
}
