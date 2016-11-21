using ClubManagement.Utils;
using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.Model;
using Radar.Pages.Popup;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Pages
{
    public class VelocimetroPage: BaseVisualPage
    {
        /*
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
        */

        private Velocimetro _velocimetro;

        public override float VelocidadeAtual {
            get {
                return _velocimetro.VelocidadeAtual;
            }
            set {
                _velocimetro.VelocidadeAtual = value;
            }
        }

        public override float VelocidadeRadar {
            get {
                return _velocimetro.VelocidadeRadar;
            }
            set {
                _velocimetro.VelocidadeRadar = value;
                atualizarVelocidadeRadar(value);
            }
        }

        public VelocimetroPage()
        {
            inicializarComponente();

            _velocimetro = new Velocimetro
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				WidthRequest = TelaUtils.Largura,
				HeightRequest = TelaUtils.Altura,
				BackgroundColor = Color.White
            };

            Title = "Velocimetro";
            Padding = 5;
            /*
            Content = new AbsoluteLayout
            {
                Children = {
                    _velocimetro,
                    _GPSSentidoLabel,
                    _VelocidadeRadarLabel,
                    _DistanciaRadarLabel,
                    _AdicionarRadarButton,
                    _BussolaFundo,
                    _BussolaAgulha,
                    _PrecisaoFundoImage,
                    _PrecisaoImage,
                    _PrecisaoLabel
                }
            };
            */
            var absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.Add(_velocimetro);
            absoluteLayout.Children.Add(_VelocidadeRadarLabel);
            absoluteLayout.Children.Add(_DistanciaRadarLabel);
            if (PreferenciaUtils.Bussola)
            {
                absoluteLayout.Children.Add(_BussolaFundo);
                absoluteLayout.Children.Add(_BussolaAgulha);
                absoluteLayout.Children.Add(_GPSSentidoLabel);
            }
            if (PreferenciaUtils.SinalGPS)
            {
                absoluteLayout.Children.Add(_PrecisaoFundoImage);
                absoluteLayout.Children.Add(_PrecisaoImage);
                absoluteLayout.Children.Add(_PrecisaoLabel);
            }
            if (PreferenciaUtils.ExibirBotaoAdicionar)
                absoluteLayout.Children.Add(_AdicionarRadarButton);
            Content = absoluteLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_velocimetroPageAtual = this;
            GlobalUtils.Visual = this;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //_velocimetroPageAtual = null;
            GlobalUtils.Visual = null;
        }

        public override void atualizarPosicao(LocalizacaoInfo posicao)
        {
            //_map.atualizarPosicao(posicao);
        }

        public override void redesenhar() {
            _velocimetro.redesenhar();
        }
    }
}
