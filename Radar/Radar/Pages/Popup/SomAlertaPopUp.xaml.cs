using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class SomAlertaPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public SomAlertaPopUp() {
            InitializeComponent();
           // Content = new ScrollView() { Content = list };
            switch (Configuracao.SomAlarme) {
                case "1":
                    SwitchAlarme01.IsToggled = true;
                    break;
                case "2":
                    SwitchAlarme02.IsToggled = true;
                    break;
                case "3":
                    SwitchAlarme03.IsToggled = true;
                    break;
                case "4":
                    SwitchAlarme04.IsToggled = true;
                    break;
                case "5":
                    SwitchAlarme05.IsToggled = true;
                    break;
                case "6":
                    SwitchAlarme06.IsToggled = true;
                    break;
                case "7":
                    SwitchAlarme07.IsToggled = true;
                    break;
                case "8":
                    SwitchAlarme08.IsToggled = true;
                    break;
                case "9":
                    SwitchAlarme09.IsToggled = true;
                    break;
                case "10":
                    SwitchAlarme10.IsToggled = true;
                    break;
                case "11":
                    SwitchAlarme11.IsToggled = true;
                    break;
                case "12":
                    SwitchAlarme12.IsToggled = true;
                    break;
                case "13":
                    SwitchAlarme13.IsToggled = true;
                    break;

            }
            
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        public void alarme01Toggled(object sender, ToggledEventArgs e1) {
                    
            if (SwitchAlarme01.IsToggled == true) {
                SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false; SwitchAlarme04.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 001);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme02Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme02.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme03.IsToggled = false; SwitchAlarme04.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 002);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme03Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme03.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme04.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 003);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme04Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme04.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 004);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme05Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme05.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 005);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme06Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme06.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 006);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme07Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme07.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 007);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme08Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme08.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 008);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme09Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme09.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 009);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme10Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme10.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 010);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme11Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme11.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 011);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme12Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme12.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme11.IsToggled = false; SwitchAlarme13.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 012);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }

        public void alarme13Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme13.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false;

                regraPreferencia.gravar("somAlarme", 013);
            } else {
                regraPreferencia.gravar("somAlarme", 000);
            }
        }
        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}
