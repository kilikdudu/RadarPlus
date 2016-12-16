using Radar.Model;
using System;


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
