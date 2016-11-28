﻿using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public delegate void ProcessarPontoEventHandler(object sender, ProcessarPontoEventArgs e);

    public class ProcessarPontoEventArgs : EventArgs {

        public ProcessarPontoEventArgs(PercursoPontoInfo ponto) {
            Ponto = ponto;
        }

        public PercursoPontoInfo Ponto { get; set; }
    }
}