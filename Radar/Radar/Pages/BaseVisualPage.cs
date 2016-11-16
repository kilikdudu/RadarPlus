﻿using Radar.Controls;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Pages
{
    public abstract class BaseVisualPage: ContentPage
    {
        protected float _sentido;
        protected float _precisao;
        protected GPSSinalEnum _GPSForcaSinal;
        protected float _distanciaRadar;
        protected Label _GPSSentidoLabel;
        protected Label _VelocidadeRadarLabel;
        protected Label _DistanciaRadarLabel;
        protected Image _AdicionarRadarButton;

        protected Image _BussolaFundo;
        protected Image _BussolaAgulha;

        protected Image _PrecisaoFundoImage;
        protected Image _PrecisaoImage;
        protected Label _PrecisaoLabel;

        public abstract float VelocidadeAtual
        {
            get; set;
        }

        protected void atualizarVelocidadeRadar(float velocidadeRadar)
        {
            _VelocidadeRadarLabel.Text = ((int)Math.Floor(velocidadeRadar)).ToString() + "Km/h";
        }

        public abstract float VelocidadeRadar
        {
            get; set; 
        }

        public float DistanciaRadar
        {
            get
            {
                return _distanciaRadar;
            }
            set
            {
                _distanciaRadar = value;
                _DistanciaRadarLabel.Text = ((int)Math.Floor(_distanciaRadar)).ToString() + "m";
            }
        }

        public float Precisao
        {
            get
            {
                return _precisao;
            }
            set
            {
                _precisao = value;
                GPSSinalEnum sinal = GPSSinalEnum.Nenhum;
                if (_precisao <= 0)
                    sinal = GPSSinalEnum.Nenhum;
                else if (_precisao <= 5)
                    sinal = GPSSinalEnum.Fraco;
                else if (_precisao <= 10)
                    sinal = GPSSinalEnum.Medio;
                else
                    sinal = GPSSinalEnum.Fraco;
                if (sinal != _GPSForcaSinal)
                {
                    _GPSForcaSinal = sinal;
                    switch (_GPSForcaSinal)
                    {
                        case GPSSinalEnum.Forte:
                            _PrecisaoImage.Source = ImageSource.FromFile("sat03.png");
                            break;
                        case GPSSinalEnum.Medio:
                            _PrecisaoImage.Source = ImageSource.FromFile("sat02.png");
                            break;
                        case GPSSinalEnum.Fraco:
                            _PrecisaoImage.Source = ImageSource.FromFile("sat01.png");
                            break;
                        default:
                            _PrecisaoImage.Source = ImageSource.FromFile("sat04.png");
                            break;
                    }
                }
                _PrecisaoLabel.Text = ((int)Math.Floor(_precisao)).ToString() + " m";
            }
        }

        public float Sentido
        {
            get
            {
                return _sentido;
            }
            set
            {
                _sentido = value;
                _BussolaAgulha.Rotation = _sentido;
                _GPSSentidoLabel.Text = ((int)Math.Floor(_sentido)).ToString() + "º";
            }
        }

        protected virtual void inicializarComponente() {
            _GPSSentidoLabel = new Label
            {
                Text = "Sentido",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_GPSSentidoLabel, new Rectangle(0.9, 0.12, 0.15, 0.15));
            //AbsoluteLayout.SetLayoutBounds(_PrecisaoLabel, new Rectangle(0.11, 0.12, 0.15, 0.15));
            AbsoluteLayout.SetLayoutFlags(_GPSSentidoLabel, AbsoluteLayoutFlags.All);

            _VelocidadeRadarLabel = new Label
            {
                Text = "Velocidade",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            if (Device.OS == TargetPlatform.iOS)
            {

            }
            AbsoluteLayout.SetLayoutBounds(_VelocidadeRadarLabel, new Rectangle(1, 0.950, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_VelocidadeRadarLabel, AbsoluteLayoutFlags.All);

            _DistanciaRadarLabel = new Label
            {
                Text = "0 m",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_DistanciaRadarLabel, new Rectangle(1, 0.975, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_DistanciaRadarLabel, AbsoluteLayoutFlags.All);

            _AdicionarRadarButton = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("mais.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_AdicionarRadarButton, new Rectangle(0.93, 0.975, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_AdicionarRadarButton, AbsoluteLayoutFlags.All);
            _AdicionarRadarButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => {
                        //AudioUtils.play(AudioEnum.Alarm001);
                        //MensagemUtils.avisar("teste");
                        var downloader = new DownloaderAtualizacao();
                        downloader.download();
                        /*
                        try
                        {
                            LocalizacaoInfo local = GPSUtils.UltimaLocalizacao;
                            if (local != null)
                            {
                                RadarBLL regraRadar = RadarFactory.create();
                                regraRadar.gravar(local);
                                MensagemUtils.avisar("Radar incluído com sucesso.");
                            }
                            else
                                MensagemUtils.avisar("Nenhum movimento registrado pelo GPS.");
                        }
                        catch (Exception e) {
                            MensagemUtils.avisar(e.Message);
                        }
                        */
                    }
                )
                });

            _BussolaFundo = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("icones/bussolacorpo.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_BussolaFundo, new Rectangle(0.93, 0, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_BussolaFundo, AbsoluteLayoutFlags.All);

            _BussolaAgulha = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("icones/bussolaagulha.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_BussolaAgulha, new Rectangle(0.93, 0, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_BussolaAgulha, AbsoluteLayoutFlags.All);

            _PrecisaoFundoImage = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("bussolacorpo.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_PrecisaoFundoImage, new Rectangle(0.07, 0, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_PrecisaoFundoImage, AbsoluteLayoutFlags.All);

            _PrecisaoImage = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("sat04.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_PrecisaoImage, new Rectangle(0.11, 0.04, 0.15, 0.15));
            AbsoluteLayout.SetLayoutFlags(_PrecisaoImage, AbsoluteLayoutFlags.All);

            _PrecisaoLabel = new Label
            {
                Text = "0 m",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            //AbsoluteLayout.SetLayoutBounds(_PrecisaoLabel, new Rectangle(0.1, 0.025, 0.1, 0.1));
            AbsoluteLayout.SetLayoutBounds(_PrecisaoLabel, new Rectangle(0.11, 0.12, 0.15, 0.15));
            AbsoluteLayout.SetLayoutFlags(_PrecisaoLabel, AbsoluteLayoutFlags.All);
        }

        public abstract void redesenhar();
        public abstract void atualizarPosicao(LocalizacaoInfo local);
    }
}