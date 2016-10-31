using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.Model;
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
    public class MapaPage : ContentPage
    {
        private RadarMap _map;
        private RadarBLL _regraRadar = RadarFactory.create();

        private static MapaPage _mapaPageAtual;

        public static MapaPage Atual
        {
            get {
                return _mapaPageAtual;
            }
            private set {
                _mapaPageAtual = value;
            }
        }

        public MapaPage()
        {
            _map = new RadarMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // You can use MapSpan.FromCenterAndRadius 
            //map.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (37, -122), Distance.FromMiles (0.3)));
            // or create a new MapSpan object directly
            //map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

            // add the slider
            /*
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                if (map.VisibleRegion != null)
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };
            */

            Content = new StackLayout {
                Spacing = 0,
                Children = {
                    _map
                }
            };

            // for debugging output only
            _map.PropertyChanged += (sender, e) => {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && _map.VisibleRegion != null)
                    _map.atualizarAreaVisivel(_map.VisibleRegion);
            };

            Atual = this;
        }

        public void atualizarPosicao(LocalizacaoInfo posicao) {
            /*
            posicao.Latitude = -16.702400;
            posicao.Longitude = -49.231129;
            posicao.Sentido = 180;
            posicao.Velocidade = 30;
            */
            //_regraRadar.calcularLocalizacao(posicao);
            _map.atualizarPosicao(posicao);
            //map.MoveToRegion(new MapSpan(new Position(posicao.Latitude, posicao.Longitude), Configuracao.GPSDeltaPadrao, Configuracao.GPSDeltaPadrao));
        }
    }
}
