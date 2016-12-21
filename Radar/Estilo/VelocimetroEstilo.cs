using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Estilo
{
    public class VelocimetroEstilo : BaseEstilo
    {
        private VelocimetroCor _ponteiroCor;
        private VelocimetroCor _textoCor;

        public VelocimetroCor PonteiroCor {
            get {
                return _ponteiroCor;
            }
            set {
                _ponteiroCor = value;
            }
        }

        public VelocimetroCor TextoCor
        {
            get
            {
                return _textoCor;
            }
            set
            {
                _textoCor = value;
            }
        }

        public override void inicializar(ResourceDictionary resources)
        {
            _ponteiroCor = new VelocimetroCor {
                Verde = Color.FromHex("#1B6B31"),
                Vermelho = Color.FromHex("#B20000"),
                CinzaClaro = Color.FromHex("#202020"),
                Padrao = Color.FromHex("#CCCCCC")
            };
            _textoCor = new VelocimetroCor
            {
                Verde = Color.FromHex("#1B6B31"),
                Vermelho = Color.FromHex("#B20000"),
                CinzaClaro = Color.FromHex("#202020"),
                Padrao = Color.FromHex("#CCCCCC")
            };
        }
    }
}
