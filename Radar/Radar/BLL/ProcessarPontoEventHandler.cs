using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public delegate void ProcessarPontoEventHandler(object sender, ProcessarPontoEventArgs e);

    public class ProcessarPontoEventArgs : EventArgs
    {

        public ProcessarPontoEventArgs(PercursoInfo percurso, LocalizacaoInfo local, bool alterado)
        {
            Percurso = percurso;
            Local = local;
            Alterado = alterado;
        }

        public PercursoInfo Percurso { get; set; }
        public LocalizacaoInfo Local { get; set; }
        public bool Alterado { get; set; }
    }
}
