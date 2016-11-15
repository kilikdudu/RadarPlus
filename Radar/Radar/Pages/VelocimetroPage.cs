using ClubManagement.Utils;
using Radar.BLL;
using Radar.Controls;
using Radar.Factory;
using Radar.Model;
using Radar.Utils;
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
        private float _distanciaRadar;
        private Velocimetro _velocimetro;
        private Label _GPSSentidoLabel;
        private Label _VelocidadeRadarLabel;
        private Label _DistanciaRadarLabel;
        private Image _AdicionarRadarButton;

        private Image _BussolaFundo;
        private Image _BussolaAgulha;

        private Image _PrecisaoFundoImage;
        private Image _PrecisaoImage;
        private Label _PrecisaoLabel;

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

        public float Precisao {
            get {
                return _precisao;
            }
            set {
                _precisao = value;
                if (_precisao <= 0)
                    _PrecisaoImage.Source = ImageSource.FromFile("sat04.png");
                else if (_precisao <= 5)
                    _PrecisaoImage.Source = ImageSource.FromFile("sat03.png");
                else if (_precisao <= 10)
                    _PrecisaoImage.Source = ImageSource.FromFile("sat02.png");
                else
                    _PrecisaoImage.Source = ImageSource.FromFile("sat01.png");
                _PrecisaoLabel.Text = ((int)Math.Floor(_precisao)).ToString() + " m";
            }
        }

        public float Sentido {
            get {
                return _sentido;
            }
            set {
                _sentido = value;
                //int sentido = ((int)Math.Floor(_sentido));
                _BussolaAgulha.Rotation = _sentido;
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
			_velocimetro = new Velocimetro
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				WidthRequest = TelaUtils.Largura,
				HeightRequest = TelaUtils.Altura,
				BackgroundColor = Color.White
            };

            _GPSSentidoLabel = new Label
            {
                Text = "Sentido",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_GPSSentidoLabel, new Rectangle(0.9, 0.2, 0.1, 0.1));
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

            _AdicionarRadarButton = new Image {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("mais.png"),
                WidthRequest = 180,
                HeightRequest = 180
            };
            AbsoluteLayout.SetLayoutBounds(_AdicionarRadarButton, new Rectangle(0.93, 0.975, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_AdicionarRadarButton, AbsoluteLayoutFlags.All);
            _AdicionarRadarButton.GestureRecognizers.Add(
                new TapGestureRecognizer() {
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
            AbsoluteLayout.SetLayoutBounds(_PrecisaoImage, new Rectangle(0.07, 0, 0.2, 0.2));
            AbsoluteLayout.SetLayoutFlags(_PrecisaoImage, AbsoluteLayoutFlags.All);

            _PrecisaoLabel = new Label
            {
                Text = "0 m",
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(_PrecisaoLabel, new Rectangle(0.1, 0.025, 0.1, 0.1));
            AbsoluteLayout.SetLayoutFlags(_PrecisaoLabel, AbsoluteLayoutFlags.All);

            Title = "Velocimetro";
            Padding = 5;
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
