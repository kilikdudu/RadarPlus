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
    public class PercursoPage: ContentPage
    {
        StackLayout _RootLayout;
        ListView _PercursoListView;

        //WrapLayout _Descricao;

        Label _tempoCorrendo;
        Label _tempoParado;
        Label _paradas;
        Label _velocidadeMaxima;
        Label _velocidadeMedia;
        Label _radares;

        View _GravarButton;
        View _PararButton;


        public PercursoPage()
        {
            inicializarComponente();

            _RootLayout = new StackLayout {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill,
                Children = {
                    _PercursoListView,
                    (!PercursoBLL.Gravando) ? _GravarButton : _PararButton
                }
            };
            Content = _RootLayout;
        }

        private View criarPararButton() {
            var stackLayout = new StackLayout
            {
                Style = EstiloUtils.PercursoGravarStackLayoutMain,
                Children = {
                    new Image {
                        Source = ImageSource.FromFile("Stop.png"),
                        Style = EstiloUtils.PercursoGravarImagem
                    },
                    new StackLayout {
                        Style = EstiloUtils.PercursoGravarStackLayoutInterno,
                        Children = {
                            new Label {
                                Text = "Parar Percurso!",
                                Style = EstiloUtils.PercursoGravarTitulo
                            },
                            new WrapLayout {
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
                            }
                        }
                    }
                }
            };

            stackLayout.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    pararPercurso();
                })
            });
            return stackLayout;
        }

        private View criarGravarButton() {
            var stackLayout = new StackLayout
            {
                Style = EstiloUtils.PercursoGravarStackLayoutMain,
                Children = {
                    new Image {
                        Source = ImageSource.FromFile("Play.png"),
                        Style = EstiloUtils.PercursoGravarImagem
                    },
                    new StackLayout {
                        Style = EstiloUtils.PercursoGravarStackLayoutInterno,
                        Children = {
                            new Label {
                                Text = "Gravar Percurso!",
                                Style = EstiloUtils.PercursoGravarTitulo
                            },
                            new Label {
                                Text="Toque aqui para gravar percurso",
                                Style = EstiloUtils.PercursoGravarDescricao
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
                FontSize = 14,
                Text = "Tempo: 00:00:00"
            };
            //_tempoCorrendo.SetBinding(Label.TextProperty, new Binding("TempoGravacaoStr"));

            _tempoParado = new Label{
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 14,
                Text = "Parado: 00:00:00"
            };
            //_tempoParado.SetBinding(Label.TextProperty, new Binding("TempoParadoStr"));

            _paradas = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Text = "Paradas: 0"
            };

            _velocidadeMaxima = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "V Méd: 0 Km/h"
            };

            _velocidadeMedia = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "V Max: 0 Km/h"
            };

            _radares = new Label {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Radares: 0"
            };

            _GravarButton = criarGravarButton();
            _PararButton = criarPararButton();
        }

        protected override void OnAppearing()
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            var percursos = regraPercurso.listar();
            this.BindingContext = percursos;
        }

        private void gravarPercurso()
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            if (regraPercurso.iniciarGravacao((s, e) =>
            {
                _tempoCorrendo.Text = "Tempo: " + e.Percurso.TempoGravacaoStr;
                _tempoParado.Text = "Parado: " + e.Percurso.TempoParadoStr;
                _paradas.Text = "Paradas: " + e.Percurso.QuantidadeParadaStr;
                _velocidadeMedia.Text = "V Méd: " + e.Percurso.VelocidadeMediaStr;
                _velocidadeMaxima.Text = "V Max: " +  e.Percurso.VelocidadeMaximaStr;
                _radares.Text = "Radares: " + e.Percurso.QuantidadeRadarStr;
            }))
            {
                _RootLayout.Children.Remove(_GravarButton);
                _RootLayout.Children.Add(_PararButton);
                MensagemUtils.avisar("Iniciando gravação do percurso!");
                MensagemUtils.notificarPermanente(
                    PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID,
                    "Gravando Percurso...", "",
                    PercursoBLL.NOTIFICACAO_PARAR_PERCURSO_ID,
                    "Parar", PercursoBLL.ACAO_PARAR_GRAVACAO
                );
            }
            else {
                MensagemUtils.avisar("Não foi possível iniciar a gravação!");
            }
        }

        private async void pararPercurso()
        {
            var retorno = await DisplayActionSheet("Tem certeza que deseja parar a gravação?", null, null, "Parar", "Continuar gravando");
            if (retorno == "Parar")
            {

                PercursoBLL regraPercurso = PercursoFactory.create();
                if (regraPercurso.pararGravacao())
                {
                    _RootLayout.Children.Remove(_PararButton);
                    _RootLayout.Children.Add(_GravarButton);

                    MensagemUtils.avisar("Gravação finalizada!");
                    MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID);

                    var percursos = regraPercurso.listar();
                    _PercursoListView.BindingContext = percursos;
                }
                else {
                    MensagemUtils.avisar("Não foi possível parar a gravação!");
                }
            }
        }

        public void abrirPercurso(object sender, EventArgs e)
        {
        }

    }
}
