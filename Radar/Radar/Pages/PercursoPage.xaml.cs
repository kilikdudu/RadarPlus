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
using System.Diagnostics;

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
			percursoListView.ItemTemplate = new DataTemplate(typeof(PercursoPageCell));
			percursoListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));

			var percursos = regraPercurso.listar();

			//desc.VerticalOptions = LayoutOptions.Center;
			desc.HorizontalOptions = LayoutOptions.Fill;
			desc.WidthRequest = TelaUtils.LarguraSemPixel * 0.7;
			desc.Spacing = 1;


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

			if (percursos.Count > 0)
			{
				//percursoListView.SetBinding(Label.TextProperty, new Binding("Data"));
				this.BindingContext = percursos;

			}

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

		public void abrirPercurso(object sender, EventArgs e)
		{
		}

		public void excluirPercurso(object sender, EventArgs e)
		{
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

		public class PercursoPageCell : ViewCell
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

			public PercursoPageCell()
			{
				MenuItem excluirPercurso = new MenuItem();
			
				excluirPercurso.CommandParameter = "{Binding .}";
				excluirPercurso.Text = "Excluir";
				excluirPercurso.IsDestructive = true;
				excluirPercurso.Clicked += async (object sender, EventArgs e) => { 
				PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
					PercursoBLL regraPercurso = PercursoFactory.create();
					regraPercurso.excluir(percurso.Id);
					OnAppearing();
				};
					
				MenuItem simularPercurso = new MenuItem();

				simularPercurso.CommandParameter = "{Binding .}";
				simularPercurso.Text = "Simular";
				simularPercurso.Clicked += async (object sender, EventArgs e) =>
				{
					PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
					if (percurso != null)
						GPSUtils.simularPercurso(percurso.Id);
					OnAppearing();
				};
				this.ContextActions.Add(simularPercurso);
				this.ContextActions.Add(excluirPercurso);


				//desc.VerticalOptions = LayoutOptions.Center;
				desc.HorizontalOptions = LayoutOptions.Fill;
				desc.Spacing = 1;
				desc.VerticalOptions = LayoutOptions.Fill;
				desc.Spacing = 1;

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

				tempoCorrendo.Text = "Tempo: 00:00:15";
				tempoParado.Text = "Parado: 00:00:15";

				paradas.Text = "Paradas: 0";

				velocidadeMedia.Text = "V Méd: 0 km/h";
				velocidadeMaxima.Text = "V Max: 0 km/h";

				radares.Text = "Radares: 0";

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

				StackLayout main = new StackLayout()
				{
					Margin = new Thickness(5, 0, 5, 0),
					VerticalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Fill,
					WidthRequest = TelaUtils.LarguraSemPixel
				};

				Frame cardLeft = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,
					Margin = new Thickness(0, 0, 0, 0),
					WidthRequest = main.WidthRequest * 0.2

				};

				StackLayout cardLeftStack = new StackLayout()
				{
					Orientation = StackOrientation.Vertical
				
				};

				Image percursoIco = new Image()
				{
					Source = "percursos.png",
					WidthRequest = cardLeft.WidthRequest / 2,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				BoxView linha = new BoxView()
				{
					HeightRequest = 1,
					BackgroundColor = Color.FromHex(TemaInfo.DividerColor),
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				Label distanciaText = new Label()
				{
					Text = "14 km",
					//FontSize = 20,
					TextColor = Color.FromHex(TemaInfo.PrimaryColor),
					FontFamily = "Roboto-Condensed",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				cardLeftStack.Children.Add(percursoIco);
				cardLeftStack.Children.Add(linha);
				cardLeftStack.Children.Add(distanciaText);
				cardLeft.Content = cardLeftStack;

				Frame cardRigth = new Frame()
				{
					HorizontalOptions = LayoutOptions.Start,
					WidthRequest = main.WidthRequest * 0.7

				};

				StackLayout cardRigthStackVer = new StackLayout()
				{
					Orientation = StackOrientation.Vertical,
					Spacing = 1

				};


				Label titulo = new Label()
				{
					Text = "31/0ut, 17:41",
					HorizontalOptions = LayoutOptions.StartAndExpand,
					FontSize = 26,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex(TemaInfo.PrimaryColor)
				};


				Label endereco = new Label()
				{
					Text = "Rua H-149, 1-73 Cidade Vera Cruz/ Aparecida de Goiânia",
					WidthRequest = main.WidthRequest * 0.7,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					//FontSize = 20,
					FontFamily = "Roboto-Condensed",
					//HorizontalTextAlignment = TextAlignment.Start
				};


				cardRigthStackVer.Children.Add(titulo);
				cardRigthStackVer.Children.Add(linha);
				cardRigthStackVer.Children.Add(endereco);
				cardRigthStackVer.Children.Add(desc);

				cardRigth.Content = cardRigthStackVer;

				//if (main.WidthRequest > 320)
				//{

					main.Children.Add(cardLeft);
				//}
				main.Children.Add(cardRigth);

				View = main;

			}


		}
	}
}
