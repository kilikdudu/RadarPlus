using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Factory
{
    public static class PercursoFactory
    {
        private static PercursoBLL _Percurso;

        public static PercursoBLL create() {
            if (_Percurso == null)
                _Percurso = new PercursoBLL();
            return _Percurso;
        }
    }
}
