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
    public class PercursoPage: ContentPage
    {
        ListView _PercursoListView;

        WrapLayout _Descricao;

        Label _tempoCorrendo;
        Label _tempoParado;
        Label _paradas;
        Label _velocidadeMaxima;
        Label _velocidadeMedia;
        Label _radares;

        Image velocimetroIco;
        Image velocimetroIco2;
        Image radarIco;


        public PercursoPage()
        {
            inicializarComponente();

            Content = new StackLayout {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill,
                Children = {
                    _PercursoListView,
                    criarBotaoGravar()
                }
            };
        }

        private View criarBotaoGravar() {
            var stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(30, 30, 30, 40),
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children = {
                    new Image {
                        Source = "Play",
                        WidthRequest = 60,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        Children = {
                            new Label {
                                Text = "Gravar Percurso!",
                                FontSize = 24,
                                FontAttributes = FontAttributes.Bold,
                                FontFamily = "Roboto-Condensed",
                                BackgroundColor = Color.Transparent,
                                HorizontalOptions = LayoutOptions.Start,
                                VerticalOptions = LayoutOptions.Center
                            },
                            new Label {
                                Text="Toque aqui para gravar percurso",
                                FontSize = 18,
                                FontFamily = "Roboto-Condensed",
                                HorizontalOptions = LayoutOptions.Start,
                                VerticalOptions = LayoutOptions.Center
                            }
                        }
                    }
                }
            };

            stackLayout.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    gravarPercurso();
                })
            });
            return stackLayout;
        }

        private void inicializarComponente()
        {
            _PercursoListView = new ListView {
                ItemTemplate = new DataTemplate(typeof(PercursoPageCell))
            };
            _PercursoListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			_PercursoListView.RowHeight = 200;
			_PercursoListView.Footer = new Label()
			{
				Text = ""
			};

            _tempoCorrendo = new Label {
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 14
            };
            _tempoCorrendo.SetBinding(Label.TextProperty, new Binding("TempoGravacaoStr"));

            _tempoParado = new Label{
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 14
            };
            _tempoParado.SetBinding(Label.TextProperty, new Binding("TempoParadoStr"));

            _paradas = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            _velocidadeMaxima = new Label
            {
                HorizontalOptions = LayoutOptions.Start
            };

            _velocidadeMedia = new Label
            {
                HorizontalOptions = LayoutOptions.Start
            };

            _radares = new Label {
                HorizontalOptions = LayoutOptions.Start
            };

            _Descricao = new WrapLayout {
                HorizontalOptions = LayoutOptions.Fill,
                WidthRequest = TelaUtils.LarguraSemPixel * 0.7,
                Spacing = 1,
                Children = {
                    new Image
                    {
                        Source = ImageSource.FromFile("relogio_20x20_preto.png")
                    },
                    _tempoCorrendo,
                    new Image {
                        Source = ImageSource.FromFile("ampulheta_20x20_preto.png")
                    },
                    _tempoParado,
                    new Image {
                        Source = ImageSource.FromFile("mao_20x20_preto.png")
                    },
                    _paradas,
                    new Image {
                        Source = ImageSource.FromFile("velocimetro_20x20_preto.png")
                    },
                    _velocidadeMedia,
                    new Image {
                        Source = ImageSource.FromFile("velocimetro_20x20_preto.png")
                    },
                    _velocidadeMaxima,
                    new Image {
                        Source = ImageSource.FromFile("radar_20x20_preto.png")
                    },
                    _radares
                }
            };
        }

        protected override void OnAppearing()
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            var percursos = regraPercurso.listar();
            if (percursos.Count > 0)
            {
                this.BindingContext = percursos;
            }

        }

        private void gravarPercurso()
        {
            //Label gravarButton = (Label)sender;
            PercursoBLL regraPercurso = PercursoFactory.create();
            if (PercursoBLL.Gravando)
            {
                if (regraPercurso.pararGravacao())
                {
                    /*
                    gravarLabel.Text = "Gravar Percurso!";
                    infoLabel.Text = "Toque aqui para iniciar a gravação";
                    stackDescricaoGravando.Children.Add(gravarLabel);
                    stackDescricaoGravando.Children.Add(infoLabel);
                    stackDescricaoGravando.Children.Remove(desc);

                    icoPlay.Source = ImageSource.FromFile("Play.png");
                    */
                    ClubManagement.Utils.MensagemUtils.avisar("Gravação finalizada!");

                    ClubManagement.Utils.MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID);

                    var percursos = regraPercurso.listar();
                    _PercursoListView.BindingContext = percursos;


                }
                else {
                    ClubManagement.Utils.MensagemUtils.avisar("Não foi possível parar a gravação!");
                }
            }
            else {

                if (regraPercurso.iniciarGravacao((s2, e2) =>
                {
                    _tempoCorrendo.Text = e2.Ponto.TempoGravacao.ToString();
                    _tempoParado.Text = e2.Ponto.TempoParadoStr;
                    _paradas.Text = e2.Ponto.QuantidadeParadaStr;
                    _velocidadeMedia.Text = e2.Ponto.VelocidadeMediaStr;
                    _velocidadeMaxima.Text = e2.Ponto.VelocidadeMaximaStr;
                    _radares.Text = e2.Ponto.QuantidadeRadarStr;
                }))
                {
                    /*
                    stackDescricaoGravando.Children.Remove(gravarLabel);
                    stackDescricaoGravando.Children.Remove(infoLabel);
                    stackDescricaoGravando.Children.Add(desc);
					
                    icoPlay.Source = ImageSource.FromFile("Stop.png");
                    */
                    ClubManagement.Utils.MensagemUtils.avisar("Iniciando gravação do percurso!");
                    ClubManagement.Utils.MensagemUtils.notificarPermanente(
                        PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID,
                        "Gravando Percurso...", "",
                        PercursoBLL.NOTIFICACAO_PARAR_PERCURSO_ID,
                        "Parar", PercursoBLL.ACAO_PARAR_GRAVACAO
                    );
                }
                else {
                    ClubManagement.Utils.MensagemUtils.avisar("Não foi possível iniciar a gravação!");
                }
            }
        }

        public void abrirPercurso(object sender, EventArgs e)
        {
        }

    }
}
