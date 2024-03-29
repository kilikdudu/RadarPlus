﻿using Radar.BLL;
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
            var excluiPercurso = new MenuItem
            {
                Text = "Excluir"
            };

            excluiPercurso.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            excluiPercurso.Clicked += (sender, e) =>
            {
                PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
                PercursoBLL regraPercurso = PercursoFactory.create();
                regraPercurso.excluir(percurso.Id);

                ListView percursoListView = this.Parent as ListView;

                percursoListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));

                var percursos = regraPercurso.listar();
                percursoListView.BindingContext = percursos;
                percursoListView.ItemTemplate = new DataTemplate(typeof(PercursoPageCell));
            };

            var simulaPercurso = new MenuItem
            {
                Text = "Simular"
            };

            simulaPercurso.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            simulaPercurso.Clicked += (sender, e) =>
            {
                PercursoInfo percurso = (PercursoInfo)((MenuItem)sender).BindingContext;
                if (percurso != null)
                    GPSUtils.simularPercurso(percurso.Id);
                OnAppearing();
            };

            ContextActions.Add(simulaPercurso);
            ContextActions.Add(excluiPercurso);

            desc.HorizontalOptions = LayoutOptions.Fill;
            desc.VerticalOptions = LayoutOptions.CenterAndExpand;
            desc.Spacing = 1;

            tempoCorrendo.HorizontalOptions = LayoutOptions.Start;
            tempoParado.HorizontalOptions = LayoutOptions.Start;
            paradas.HorizontalOptions = LayoutOptions.Start;
            paradas.VerticalOptions = LayoutOptions.Center;
            velocidadeMaxima.HorizontalOptions = LayoutOptions.Start;
            velocidadeMedia.HorizontalOptions = LayoutOptions.Start;
            radares.HorizontalOptions = LayoutOptions.Start;

            relogioIco.Source = ImageSource.FromFile("relogio_20x20_preto.png");
            paradoIco.Source = ImageSource.FromFile("mao_20x20_preto.png");
            ampulhetaIco.Source = ImageSource.FromFile("ampulheta_20x20_preto.png");
            velocimetroIco.Source = ImageSource.FromFile("velocimetro_20x20_preto.png");
            velocimetroIco2.Source = ImageSource.FromFile("velocimetro_20x20_preto.png");
            radarIco.Source = ImageSource.FromFile("radar_20x20_preto.png");

			tempoCorrendo.SetBinding(Label.TextProperty, new Binding("TempoGravacaoStr", stringFormat: "Tempo: {0}"));
			tempoCorrendo.FontSize = 14;
			tempoParado.SetBinding(Label.TextProperty, new Binding("TempoParadoStr", stringFormat: "Parado: {0}"));
			tempoParado.FontSize = 14;

            paradas.SetBinding(Label.TextProperty, new Binding("QuantidadeParadaStr", stringFormat: "Paradas: {0}"));
            paradas.FontSize = 14;
            velocidadeMedia.SetBinding(Label.TextProperty, new Binding("VelocidadeMediaStr", stringFormat: "V Méd: {0}"));
            velocidadeMedia.FontSize = 14;
            velocidadeMaxima.SetBinding(Label.TextProperty, new Binding("VelocidadeMaximaStr", stringFormat: "V Max: {0}"));
            velocidadeMaxima.FontSize = 14;
            radares.SetBinding(Label.TextProperty, new Binding("QuantidadeRadarStr", stringFormat: "Radares: {0}"));
            radares.FontSize = 14;

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

            Frame cardLeft = new Frame()
            {
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 90),
                WidthRequest = TelaUtils.LarguraSemPixel * 0.2

            };

            StackLayout cardLeftStack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill

            };

            Image percursoIco = new Image()
            {
                Source = ImageSource.FromFile("percursos.png"),
                WidthRequest = cardLeft.WidthRequest * 0.3,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            BoxView linha = new BoxView()
            {
                HeightRequest = 1,
                BackgroundColor = Color.FromHex(TemaInfo.DividerColor),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start
            };

            Label distanciaText = new Label()
            {
                FontSize = 14,
                TextColor = Color.FromHex(TemaInfo.PrimaryColor),
                FontFamily = "Roboto-Condensed",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };
            distanciaText.SetBinding(Label.TextProperty, new Binding("DistanciaTotalStr"));

            cardLeftStack.Children.Add(percursoIco);
            cardLeftStack.Children.Add(distanciaText);
            cardLeft.Content = cardLeftStack;

            Frame cardRigth = new Frame()
            {
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = TelaUtils.LarguraSemPixel * 0.7

            };
            if (TelaUtils.Orientacao == "Landscape")
            {
                cardLeft.Margin = new Thickness(0, 0, 0, 70);
                cardLeft.WidthRequest = TelaUtils.LarguraSemPixel * 0.15;
                cardRigth.WidthRequest = TelaUtils.LarguraSemPixel * 0.5;
            }
            if (TelaUtils.Orientacao == "LandscapeLeft" || TelaUtils.Orientacao == "LandscapeRight")
            {
                cardLeft.Margin = new Thickness(0, 0, 0, 70);
                cardLeft.WidthRequest = TelaUtils.LarguraSemPixel * 0.15;
                cardRigth.WidthRequest = TelaUtils.LarguraSemPixel * 0.5;
            }
            StackLayout cardRigthStackVer = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 1

            };


            Label titulo = new Label()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 26,
                FontFamily = "Roboto-Condensed",
                TextColor = Color.FromHex(TemaInfo.PrimaryColor)
            };
            titulo.SetBinding(Label.TextProperty, new Binding("Titulo"));

            Label endereco = new Label()
            {
                //Text = "Rua H-149, 1-73 Cidade Vera Cruz/ Aparecida de Goiânia",
                WidthRequest = TelaUtils.LarguraSemPixel * 0.7,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 16,
                FontFamily = "Roboto-Condensed",
                //HorizontalTextAlignment = TextAlignment.Start
            };
            endereco.SetBinding(Label.TextProperty, new Binding("Endereco"));


            cardRigthStackVer.Children.Add(titulo);
            cardRigthStackVer.Children.Add(linha);
            cardRigthStackVer.Children.Add(endereco);
            cardRigthStackVer.Children.Add(desc);

            cardRigth.Content = cardRigthStackVer;

            View = new StackLayout()
            {
                Margin = new Thickness(5, 0, 5, 0),
				VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                WidthRequest = TelaUtils.LarguraSemPixel,
                Children =
                {
                    cardLeft,
                    cardRigth
                }
            };

        }

        public void inicializarComponente() {

        }
    }
}
