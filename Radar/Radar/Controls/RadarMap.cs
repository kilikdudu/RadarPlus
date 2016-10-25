using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Radar.Model;
using Radar.BLL;
using Radar.Factory;

namespace Radar.Controls
{
    public class RadarMap: Map
    {
        private LocalizacaoInfo _localAtual;

        private Dictionary<string, RadarPin> _radares = new Dictionary<string, RadarPin>();

        public delegate void MapRotacaoEventHandler(object sender, LocalizacaoInfo local);
        public delegate void DesenharRadarEventHandler(object sender, RadarPin radar);
        public MapRotacaoEventHandler AoAtualizaPosicao;
        public DesenharRadarEventHandler AoDesenharRadar;

        public Dictionary<string, RadarPin> Radares
        {
            get
            {
                return _radares;
            }
        }

        public void atualizarPosicao(LocalizacaoInfo local)
        {
            //if (AoRotacinar != null && _rotacao != value)
            _localAtual = local;
            if (AoAtualizaPosicao != null)
            {
                AoAtualizaPosicao(this, local);
                //this.VisibleRegion = new MapSpan(new Position(local.Latitude, local.Longitude), Configuracao.GPSDeltaPadrao, Configuracao.GPSDeltaPadrao);
            }
        }

        public void atualizarAreaVisivel(MapSpan region)
        {
            //var center = region.Center;
            var latitudeDelta = region.LatitudeDegrees / 2;
            var longitudeDelta = region.LongitudeDegrees / 2;

            if (!(latitudeDelta <= Configuracao.GPSDeltaMax && longitudeDelta <= Configuracao.GPSDeltaMax))
                return;

            RadarBLL regraRadar = RadarFactory.create();
            foreach (RadarInfo radar in regraRadar.listar(region.Center.Latitude, region.Center.Longitude, latitudeDelta, longitudeDelta))
            {
                adicionarRadar(radar);
            }
        }

        private string imagemRadar(RadarInfo radar)
        {
            string imagem = string.Empty;
            if (radar.Velocidade >= 20 && radar.Velocidade < 30)
                imagem = "20_radar.png";
            else if (radar.Velocidade >= 30 && radar.Velocidade < 40)
                imagem = "30_radar.png";
            else if (radar.Velocidade >= 40 && radar.Velocidade < 50)
                imagem = "40_radar.png";
            else if (radar.Velocidade >= 50 && radar.Velocidade < 60)
                imagem = "50_radar.png";
            else if (radar.Velocidade >= 60 && radar.Velocidade < 70)
                imagem = "60_radar.png";
            else if (radar.Velocidade >= 70 && radar.Velocidade < 80)
                imagem = "70_radar.png";
            else if (radar.Velocidade >= 80 && radar.Velocidade < 90)
                imagem = "80_radar.png";
            else if (radar.Velocidade >= 90 && radar.Velocidade < 100)
                imagem = "90_radar.png";
            else if (radar.Velocidade >= 100 && radar.Velocidade < 110)
                imagem = "100_radar.png";
            else if (radar.Velocidade >= 110 && radar.Velocidade < 120)
                imagem = "110_radar.png";
            else
                imagem = "cameramais.png";
            return imagem;
        }

        private void adicionarRadar(RadarInfo radar)
        {
            string radarId = radar.Latitude.ToString() + "|" + radar.Longitude.ToString();
            if (!Radares.ContainsKey(radarId))
            {
                RadarPin ponto = new RadarPin()
                {
                    Id = radar.Latitude.ToString() + "|" + radar.Longitude.ToString(),
                    Pin = new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(radar.Latitude, radar.Longitude),
                        Label = radar.Velocidade.ToString() + "km/h"
                    },
                    Sentido = radar.Direcao,
                    Velocidade = radar.Velocidade,
                    Imagem = imagemRadar(radar)
                };
                Radares.Add(ponto.Id, ponto);
                if (AoDesenharRadar != null)
                    AoDesenharRadar(this, ponto);
            }
        }
    }
}
