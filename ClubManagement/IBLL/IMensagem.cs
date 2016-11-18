﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface IMensagem
    {
        void exibirAviso(string Titulo, string Mensagem);
        bool notificar(int id, string titulo, string descricao);
        bool notificarPermanente(int id, string titulo, string descricao);
        bool pararNotificaoPermanente(int id);
        bool notificarGravacaoPercurso();
        bool pararNotificaoPercurso();
        bool enviarEmail(string para, string titulo, string mensagem);
        void vibrar(int milisegundo);
    }
}