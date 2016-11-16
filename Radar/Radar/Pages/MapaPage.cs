using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Radar.Pages
{
    public class MapaPage : BaseVisualPage
    {
        /*
        private static MapaPage _mapaPageAtual;

        public static MapaPage Atual
        {
            get
            {
                return _mapaPageAtual;
            }
            private set
            {
                _mapaPageAtual = value;
            }
        }
        */
        private RadarBLL _regraRadar = RadarFactory.create();

        private RadarMap _map;
        private BoxView _velocidadeFundo;
        private Label _velocidadeLabel;
        private float _velocidadeAtual = 0;
        private float _velocidadeRadar = 0;

        public override float VelocidadeAtual
        {
            get
            {
                return _velocidadeAtual;
            }
            set
            {
                _velocidadeAtual = value;
                _velocidadeLabel.Text = ((int)Math.Floor(_velocidadeAtual)).ToString() + "Km/h";
            }
        }

        public override float VelocidadeRadar
        {
            get
            {
                return _velocidadeRadar;
            }
            set
            {
                _velocidadeAtual = value;
            }
        }

        protected override void inicializarComponente()
        {
            base.inicializarComponente();

            _map = new RadarMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            AbsoluteLayout.SetLayoutBounds(_map, new Rectangle(0, 0, 1, 0.9));
            AbsoluteLayout.SetLayoutFlags(_map, AbsoluteLayoutFlags.All);
            _map.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && _map.VisibleRegion != null)
                    _map.atualizarAreaVisivel(_map.VisibleRegion);
            };

            _velocidadeFundo = new BoxView {
                BackgroundColor = Color.White,
            };
            AbsoluteLayout.SetLayoutBounds(_velocidadeFundo, new Rectangle(0, 1, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_velocidadeFundo, AbsoluteLayoutFlags.All);
            _velocidadeLabel = new Label
            {
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Parado"
            };
            AbsoluteLayout.SetLayoutBounds(_velocidadeLabel, new Rectangle(0, 1, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_velocidadeLabel, AbsoluteLayoutFlags.All);
        }

        public MapaPage()
        {
            inicializarComponente();

            /*
            Content = new StackLayout {
                Spacing = 0,
                Children = {
                    _map
                }
            };
            */
            Title = "Mapa";
            Padding = 5;
            Content = new AbsoluteLayout
            {
                Children = {
                    _map,
                    _GPSSentidoLabel,
                    _VelocidadeRadarLabel,
                    _DistanciaRadarLabel,
                    _BussolaFundo,
                    _BussolaAgulha,
                    _PrecisaoFundoImage,
                    _PrecisaoImage,
                    _PrecisaoLabel,
                    _velocidadeFundo,
                    _velocidadeLabel,
                    _AdicionarRadarButton
                }
            };

            //Atual = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GlobalUtils.Visual = this;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GlobalUtils.Visual = null;
        }

        public override void atualizarPosicao(LocalizacaoInfo posicao)
        {
            _map.atualizarPosicao(posicao);
        }

        public override void redesenhar()
        {
            //nada
        }
    }
}
