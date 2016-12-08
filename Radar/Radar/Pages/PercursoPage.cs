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
        Label velocidadeMedia;
        Label radares;

        Image _relogioIco;
        Image paradoIco;
        Image ampulhetaIco;
        Image velocimetroIco;
        Image velocimetroIco2;
        Image radarIco;

        public PercursoPage()
        {
            inicializarComponente();
        }

        private void inicializarComponente()
        {
            _PercursoListView = new ListView {
                ItemTemplate = new DataTemplate(typeof(PercursoPageCell))
            };
            _PercursoListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));

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

            _relogioIco = new Image
            {
                Source = ImageSource.FromFile("relogio_20x20_preto.png")
            };

            _Descricao = new WrapLayout {
                HorizontalOptions = LayoutOptions.Fill,
                WidthRequest = TelaUtils.LarguraSemPixel * 0.7,
                Spacing = 1,
                Children = {
                    _relogioIco,
                    _tempoCorrendo,
                    ampulhetaIco,
                    _tempoParado,
                    paradoIco,
                    _paradas,
                    velocimetroIco,
                    velocidadeMedia,
                    velocimetroIco2,
                    _velocidadeMaxima,
                    radarIco,
                    radares
                }
            };
        }

        protected override void OnAppearing()
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            var percursos = regraPercurso.listar();

            velocidadeMedia.HorizontalOptions = LayoutOptions.Start;
            radares.HorizontalOptions = LayoutOptions.Start;

            relogioIco.Source = ImageSource.FromFile("relogio_20x20_preto.png");
            paradoIco.Source = ImageSource.FromFile("mao_20x20_preto.png");
            ampulhetaIco.Source = ImageSource.FromFile("ampulheta_20x20_preto.png");
            velocimetroIco.Source = ImageSource.FromFile("velocimetro_20x20_preto.png");
            velocimetroIco2.Source = ImageSource.FromFile("velocimetro_20x20_preto.png");
            radarIco.Source = ImageSource.FromFile("radar_20x20_preto.png");

            desc.Children.Add(_relogioIco);
            desc.Children.Add(_tempoCorrendo);
            desc.Children.Add(ampulhetaIco);
            desc.Children.Add(_tempoParado);
            desc.Children.Add(paradoIco);
            desc.Children.Add(_paradas);
            desc.Children.Add(velocimetroIco);
            desc.Children.Add(velocidadeMedia);
            desc.Children.Add(velocimetroIco2);
            desc.Children.Add(_velocidadeMaxima);
            desc.Children.Add(radarIco);
            desc.Children.Add(radares);

            if (percursos.Count > 0)
            {
                //percursoListView.SetBinding(Label.TextProperty, new Binding("Data"));
                this.BindingContext = percursos;

            }

        }

        void gravarPercurso(object sender, EventArgs e)
        {
            //Label gravarButton = (Label)sender;
            PercursoBLL regraPercurso = PercursoFactory.create();
            if (PercursoBLL.Gravando)
            {
                if (regraPercurso.pararGravacao())
                {
                    gravarLabel.Text = "Gravar Percurso!";
                    infoLabel.Text = "Toque aqui para iniciar a gravação";
                    stackDescricaoGravando.Children.Add(gravarLabel);
                    stackDescricaoGravando.Children.Add(infoLabel);
                    stackDescricaoGravando.Children.Remove(desc);

                    icoPlay.Source = ImageSource.FromFile("Play.png");
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

                    velocidadeMedia.Text = e2.Ponto.VelocidadeMediaStr;

                    _velocidadeMaxima.Text = e2.Ponto.VelocidadeMaximaStr;

                    radares.Text = e2.Ponto.QuantidadeRadarStr;
                }))
                {

                    stackDescricaoGravando.Children.Remove(gravarLabel);
                    stackDescricaoGravando.Children.Remove(infoLabel);
                    stackDescricaoGravando.Children.Add(desc);

                    icoPlay.Source = ImageSource.FromFile("Stop.png");
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
