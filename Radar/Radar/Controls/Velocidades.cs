using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Controls {
    class Velocidades {
        private float velocidadeAtual;
        public float VelocidadeAtual
        {
            get { return velocidadeAtual; }
            set { velocidadeAtual = 40; }
        }
        private float velocidadeRadar;
        public float VelocidadeRadar
        {
            get { return velocidadeRadar; }
            set { velocidadeAtual = 60; }
        }

    }
}
