using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;
using Radar.Model;

namespace Radar.Pages.Popup {
    public partial class SomAlertaPopUp : PopupPage {

        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public SomAlertaPopUp() {
            InitializeComponent();
           // Content = new ScrollView() { Content = list };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (PreferenciaUtils.SomAlarme)
            {
                case SomAlarmeEnum.Alarme01:
                    SwitchAlarme01.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme02:
                    SwitchAlarme02.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme03:
                    SwitchAlarme03.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme04:
                    SwitchAlarme04.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme05:
                    SwitchAlarme05.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme06:
                    SwitchAlarme06.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme07:
                    SwitchAlarme07.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme08:
                    SwitchAlarme08.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme09:
                    SwitchAlarme09.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme10:
                    SwitchAlarme10.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme11:
                    SwitchAlarme11.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme12:
                    SwitchAlarme12.IsToggled = true;
                    break;
                case SomAlarmeEnum.Alarme13:
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

                //regraPreferencia.gravar("somAlarme", 001);
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme01;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                //regraPreferencia.gravar("somAlarme", 000);
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme02Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme02.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme03.IsToggled = false; SwitchAlarme04.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme02;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme03Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme03.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme04.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme03;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme04Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme04.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme04;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme05Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme05.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme06.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme05;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme06Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme06.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme07.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme06;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme07Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme07.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme07;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme08Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme08.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme09.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme08;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme09Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme09.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme10.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme09;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme10Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme10.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme10;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme11Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme11.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme12.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme11;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme12Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme12.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme11.IsToggled = false; SwitchAlarme13.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme12;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
            }
        }

        public void alarme13Toggled(object sender, ToggledEventArgs e1) {

            if (SwitchAlarme13.IsToggled == true) {
                SwitchAlarme01.IsToggled = false; SwitchAlarme02.IsToggled = false; SwitchAlarme03.IsToggled = false;
                SwitchAlarme04.IsToggled = false; SwitchAlarme05.IsToggled = false; SwitchAlarme06.IsToggled = false;
                SwitchAlarme07.IsToggled = false; SwitchAlarme08.IsToggled = false; SwitchAlarme09.IsToggled = false;
                SwitchAlarme10.IsToggled = false; SwitchAlarme11.IsToggled = false; SwitchAlarme12.IsToggled = false;

                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Alarme13;
                new AvisoSonoroBLL().play(PreferenciaUtils.SomAlarme);
            } else {
                PreferenciaUtils.SomAlarme = SomAlarmeEnum.Nenhum;
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
