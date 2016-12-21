using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.Estilo
{
    public static class EstiloUtils
    {
        private static VelocimetroEstilo _velocimetro;
        private static PreferenciaEstilo _preferencia;
        private static PopupEstilo _popup;
        private static PercursoEstilo _percurso;

        public static VelocimetroEstilo Velocimentro
        {
            get {
                return _velocimetro;
            }
            set {
                _velocimetro = value;
            }
        }

        public static PreferenciaEstilo Preferencia {
            get {
                return _preferencia;
            }
            set {
                _preferencia = value;
            }
        }

        public static PopupEstilo Popup
        {
            get {
                return _popup;
            }
            set {
                _popup = value;
            }
        }

        public static PercursoEstilo Percurso
        {
            get
            {
                return _percurso;
            }
            set
            {
                _percurso = value;
            }
        }

        public static void inicializar() {
            var resources = new ResourceDictionary();

            _velocimetro = new VelocimetroEstilo();
            _preferencia = new PreferenciaEstilo();
            _popup = new PopupEstilo();
            _percurso = new PercursoEstilo();

            _velocimetro.inicializar(resources);
            _preferencia.inicializar(resources);
            _popup.inicializar(resources);
            _percurso.inicializar(resources);

            App.Current.Resources = resources;
        }
    }
}
