using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.IBLL
{
    public interface IGPS
    {
        bool inicializar();
        bool estaAtivo();
        void abrirPreferencia();
    }
}
