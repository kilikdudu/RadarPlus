using Radar.BLL;
using Radar.Factory;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar {
    public partial class ModoAutoInicioPage : ContentPage {
        private static ModoAutoInicioPage _ModoAutoInicioPage;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public static ModoAutoInicioPage Atual
        {
            get
            {
                return _ModoAutoInicioPage;
            }
            private set
            {
                _ModoAutoInicioPage = value;
            }
        }
        public ModoAutoInicioPage() {
            InitializeComponent();
            Title = "Auto Inicio/Desligamento";
            Content = new ScrollView() { Content = teststack };
            habilitar.IsToggled = Configuracao.InicioDesligamento;

        }
        public void habilitarToggled(object sender, ToggledEventArgs e) {
            if (e.Value == true) {
                regraPreferencia.gravar("inicioDesligamento", 1);
            } else {
                regraPreferencia.gravar("inicioDesligamento", 0);
            }
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            _ModoAutoInicioPage = this;
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            _ModoAutoInicioPage = null;
        }
    }
}
