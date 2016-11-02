using Radar.BLL;
using Radar.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Pages
{
    public class VelocimetroPage: ContentPage
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

        private float _sentido;
        private float _precisao;
        private Velocimetro _velocimetro;
        private Label _GPSPrecisaoLabel;
        private Label _GPSSentidoLabel;
        private Label _VelocidadeRadarLabel;

        public float VelocidadeAtual {
            get {
                return _velocimetro.VelocidadeAtual;
            }
            set {
                _velocimetro.VelocidadeAtual = value;
            }
        }

        public float VelocidadeRadar {
            get {
                return _velocimetro.VelocidadeRadar;
            }
            set {
                _velocimetro.VelocidadeRadar = value;
                _VelocidadeRadarLabel.Text = ((int)Math.Floor(_velocimetro.VelocidadeRadar)).ToString() + "Km/h";
            }
        }

        public float Precisao {
            get {
                return _precisao;
            }
            set {
                _precisao = value;
                _GPSPrecisaoLabel.Text = ((int)Math.Floor(_precisao)).ToString() + "m";
            }
        }

        public float Sentido {
            get {
                return _sentido;
            }
            set {
                _sentido = value;
                _GPSSentidoLabel.Text = ((int)Math.Floor(_sentido)).ToString() + "º";
            }
        }

        /*
        public Velocimetro Velocimetro
        {
            get {
                return _velocimetro;
            }
        }
        */

        public VelocimetroPage()
        {
            _velocimetro = new Velocimetro {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = TelaUtils.Largura,
                HeightRequest = TelaUtils.Altura
            };

            _GPSPrecisaoLabel = new Label {
                Text = "Precisão",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_GPSPrecisaoLabel, new Rectangle(0.1, 0.025, 0.1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_GPSPrecisaoLabel, AbsoluteLayoutFlags.All);

            _GPSSentidoLabel = new Label
            {
                Text = "Sentido",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_GPSSentidoLabel, new Rectangle(0.9, 0.025, 0.1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_GPSSentidoLabel, AbsoluteLayoutFlags.All);

            _VelocidadeRadarLabel = new Label
            {
                Text = "Velocidade",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_VelocidadeRadarLabel, new Rectangle(1, 0.975, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_VelocidadeRadarLabel, AbsoluteLayoutFlags.All);


            Title = "Velocimetro";
            Padding = 5;
            Content = new AbsoluteLayout
            {
                Children = {
                    _velocimetro,
                    _GPSPrecisaoLabel,
                    _GPSSentidoLabel,
                    _VelocidadeRadarLabel
                }
            };
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

        public void redesenhar() {
            _velocimetro.redesenhar();
        }
    }
}
