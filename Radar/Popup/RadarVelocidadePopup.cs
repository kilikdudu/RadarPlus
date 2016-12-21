using ClubManagement.Model;
using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using Radar.Pages;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Popup
{
    public class RadarVelocidadePopup: BaseSliderPopUp
    {
        private RadarInfo _radar;
        private RadarListaPage _parent;

        public RadarVelocidadePopup(RadarInfo radar, RadarListaPage parent) {
            _radar = radar;
            _parent = parent;
        }

        protected override void inicializarComponente()
        {
            SalvarVisivel = true;
            base.inicializarComponente();
        }

        protected override double Maximo
        {
            get {
                return 110;
            }
        }

        protected override double Minimo {
            get {
                return 0;
            }
        }

        protected override double Valor {
            get {
                return _radar.Velocidade;
            }
            set {
                int velocidade = (int)Math.Floor(value);
                velocidade = velocidade - (velocidade % 10);
                if (_radar.Velocidade != velocidade && velocidade >= 20 && velocidade <= 110)
                {
                    _radar.Velocidade = velocidade;
                }
            }
        }

        protected override string getTitulo()
        {
            return "Velocidade";
        }

        protected override void salvar() {
            var regraRadar = RadarFactory.create();
            regraRadar.gravar(_radar);
            if (_parent != null)
                _parent.atualizarRadar();
        }

        protected override string formatarTexto(double valor)
        {
            int velocidade = (int)Math.Floor(valor);
            velocidade = velocidade - (velocidade % 10);
            return velocidade.ToString() + " Km/h";
        }
    }
}
