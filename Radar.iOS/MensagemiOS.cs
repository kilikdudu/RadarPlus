﻿using Radar.iOS;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(MensagemiOS))]

namespace Radar.iOS
{
    public class MensagemiOS: IMensagem
    {
        public void exibirAviso(string Titulo, string Mensagem)
        {
        }

        public bool notificar(int id, string titulo, string mensagem)
        {
            return true;
        }

        public bool notificarGravacaoPercurso()
        {
            return true;
        }

        public bool notificarPermanente(int id, string titulo, string descricao)
        {
            throw new NotImplementedException();
        }

        public bool pararNotificaoPercurso() {
            return true;
        }

        public bool pararNotificaoPermanente(int id)
        {
            throw new NotImplementedException();
        }
    }
}