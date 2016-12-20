using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Radar.Model;

using Xamarin.Forms;
using ClubManagement.Utils;
using Radar.Utils;
using Radar.Controls;

namespace Radar.Pages
{
    public class NavegacaoPage : RadarMasterDetailPage
    { 
        private MenuPage masterPage;
        //private Page _paginaAtual;

        //bool carregandoPagina = false;

        protected override void OnChildAdded(Element child)
        {
            //MensagemUtils.avisar(child.ClassId  + "=" + child.GetType().ToString());
            base.OnChildAdded(child);
        }

        public NavegacaoPage()
        { 
			//this.IsGestureEnabled = false;
			//this.WidthRequest = 400;

            masterPage = new MenuPage();
            Master = masterPage;
			//Master.WidthRequest = 500;

            var navPage = new NavigationPage(new VelocimetroPage()) {
                BarBackgroundColor = Color.FromHex(TemaInfo.DarkPrimaryColor),
                BarTextColor = Color.FromHex(TemaInfo.TextIcons)
            };
			
			Detail = navPage;
            NavegacaoUtils.DetailPage = navPage;

            masterPage.ListView.ItemSelected += OnItemSelected;

            /*
            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";
            }
            */
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.OS == TargetPlatform.iOS)
                GPSUtils.inicializar();
            if (Device.OS == TargetPlatform.Android)
                GPSUtils.verificarFuncionamentoGPS();

            if (PreferenciaUtils.LigarDesligar) {
                AudioUtils.Volume = PreferenciaUtils.AlturaVolume;
                AudioUtils.Canal = PreferenciaUtils.CanalAudio;
                AudioUtils.CaixaSom = PreferenciaUtils.CaixaSom;
                AudioUtils.play("audios/radar_aberto.mp3");
            }
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItemInfo;
            if (item != null) {
                if (item.aoClicar != null) {
                    item.aoClicar(sender, new MenuEventArgs(this));
                }
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
                /*
                else {
                    if (!carregandoPagina)
                    {
                        if (_paginaAtual.GetType() != item.TargetType)
                        {
                            carregandoPagina = true;
                            _paginaAtual = (Page)Activator.CreateInstance(item.TargetType);
                            _paginaAtual.Appearing += (sender2, e2) => {
                                carregandoPagina = false;
                            };
                            Detail = new NavigationPage(_paginaAtual);
                        }
                        masterPage.ListView.SelectedItem = null;
                        IsPresented = false;
                    }
                }
                */
            }
        }
    }
}
