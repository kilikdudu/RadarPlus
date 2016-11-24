using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.IBLL
{
    public interface ITela
    {
        float pegarLargura();
        float pegarAltura();
		float pegarLarguraSemPixel();
		string pegarOrientacao();
		float pegarAlturaSemPixel();
		float pegarLarguraDPI();
		float pegarAlturaDPI();
	}
}
