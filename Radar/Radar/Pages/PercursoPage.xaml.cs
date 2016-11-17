using ClubManagement.Utils;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Radar.Controls;

namespace Radar.Pages
{
    public partial class PercursoPage : ContentPage
    {
		WrapLayout desc = new WrapLayout();

		Label tempoCorrendo = new Label();
		Label tempoParado = new Label();
		Label paradas = new Label();
		Label velocidadeMaxima = new Label();
		Label velocidadeMedia = new Label();
		Label radares = new Label();

		Image relogioIco = new Image();
		Image paradoIco = new Image();
		Image ampulhetaIco = new Image();
		Image velocimetroIco = new Image();
		Image velocimetroIco2 = new Image();
		Image radarIco = new Image();

        public PercursoPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            percursoListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            var percursos = regraPercurso.listar();
            this.BindingContext = percursos;

			desc.VerticalOptions = LayoutOptions.Center;
			desc.HorizontalOptions = LayoutOptions.Fill;
			desc.WidthRequest = TelaUtils.Largura * 0.8;

			tempoCorrendo.HorizontalOptions = LayoutOptions.Start;
			tempoParado.HorizontalOptions = LayoutOptions.Start;
			paradas.HorizontalOptions = LayoutOptions.Start;
			paradas.VerticalOptions = LayoutOptions.Center;
			velocidadeMaxima.HorizontalOptions = LayoutOptions.Start;
			velocidadeMedia.HorizontalOptions = LayoutOptions.Start;
			radares.HorizontalOptions = LayoutOptions.Start;

			relogioIco.Source = "relogio_20x20_preto.png";
			paradoIco.Source = "mao_20x20_preto.png";
			ampulhetaIco.Source = "ampulheta_20x20_preto.png";
			velocimetroIco.Source = "velocimetro_20x20_preto.png";
			velocimetroIco2.Source = "velocimetro_20x20_preto.png";
			radarIco.Source = "radar_20x20_preto.png";

			desc.Children.Add(relogioIco);
			desc.Children.Add(tempoCorrendo);
			desc.Children.Add(ampulhetaIco);
			desc.Children.Add(tempoParado);
			desc.Children.Add(paradoIco);
			desc.Children.Add(paradas);
			desc.Children.Add(velocimetroIco);
			desc.Children.Add(velocidadeMedia);
			desc.Children.Add(velocimetroIco2);
			desc.Children.Add(velocidadeMaxima);
			desc.Children.Add(radarIco);
			desc.Children.Add(radares);

        }

        async void gravarPercurso(object sender, EventArgs e)
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

					icoPlay.Source = "Play.png";
                    MensagemUtils.avisar("Gravação finalizada!");
                    MensagemUtils.pararNotificaoPercurso();
                    OnAppearing();
                }
                else {
                    MensagemUtils.avisar("Não foi possível parar a gravação!");
                }
            }
            else {
                if (regraPercurso.iniciarGravacao())
                {
					
					stackDescricaoGravando.Children.Remove(gravarLabel);
					stackDescricaoGravando.Children.Remove(infoLabel);
					stackDescricaoGravando.Children.Add(desc);


					tempoCorrendo.Text = "Tempo: 00:00:15";
					tempoParado.Text = "Parado: 00:00:15";

					paradas.Text = "Paradas: 0";

					velocidadeMedia.Text = "V Méd: 0 km/h";
					velocidadeMaxima.Text = "V Max: 0 km/h";

					radares.Text = "Radares: 0";

                    
					icoPlay.Source = "Stop.png";
                    MensagemUtils.avisar("Iniciando gravação do percurso!");
                    MensagemUtils.notificarGravacaoPercurso();
                }
                else {
                    MensagemUtils.avisar("Não foi possível iniciar a gravação!");
                }
            }
        }

        public void abrirPercurso(object sender, EventArgs e) {
        }

        public void excluirPercurso(object sender, EventArgs e) {
            PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
            PercursoBLL regraPercurso = PercursoFactory.create();
            regraPercurso.excluir(percurso.Id);
            OnAppearing();
        }

        public void simularPercurso(object sender, EventArgs e)
        {
            PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
            if (percurso != null)
                GPSUtils.simularPercurso(percurso.Id);
        }
    }
}
