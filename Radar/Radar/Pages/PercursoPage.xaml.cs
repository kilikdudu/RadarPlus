﻿using Radar.BLL;
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
    public partial class PercursoPage : ContentPage
    {
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
        }

        public void gravarPercurso(object sender, EventArgs e) {
            Button gravarButton = (Button)sender;
            PercursoBLL regraPercurso = PercursoFactory.create();
            if (PercursoBLL.Gravando)
            {
                if (regraPercurso.pararGravacao())
                {
                    gravarButton.Text = "Gravar Percurso!";
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
                    gravarButton.Text = "Parar Gravação!";
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