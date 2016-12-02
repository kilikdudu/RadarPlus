﻿using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Radar.Model;

using Xamarin.Forms;
using ClubManagement.Utils;
using Radar.Utils;

namespace Radar.Pages
{
    public class NavegacaoPage : MasterDetailPage
    {
        private MenuPage masterPage;
        private Page _paginaAtual;

        bool carregandoPagina = false;

		public NavegacaoPage(bool pagina = false)
        {
			
            masterPage = new MenuPage();
            Master = masterPage;
			if (pagina == true )
			{
				_paginaAtual = new MapaPage(true);
			}
			else {
				_paginaAtual = new VelocimetroPage();
			}
            var nav = new NavigationPage(_paginaAtual);
			nav.BarBackgroundColor = Color.FromHex(TemaInfo.DarkPrimaryColor);
			nav.BarTextColor = Color.FromHex(TemaInfo.TextIcons);

			Detail = nav;

            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.OS == TargetPlatform.iOS)
                GPSUtils.inicializar();
            if (Device.OS == TargetPlatform.Android)
                GPSUtils.verificarFuncionamentoGPS();

        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItemInfo;
            if (item != null)
            {
                if (item.aoClicar != null)
                {
                    item.aoClicar(sender, e);
                }
                else {
                    if (!carregandoPagina)
                    {
                        if (_paginaAtual.GetType() != item.TargetType)
                        {
                            carregandoPagina = true;
                            _paginaAtual = (Page)Activator.CreateInstance(item.TargetType);
                            _paginaAtual.Appearing += (sender2, e2) =>
                            {
                                carregandoPagina = false;
                            };
                            Detail = new NavigationPage(_paginaAtual);
                        }
                        masterPage.ListView.SelectedItem = null;
                        IsPresented = false;
                    }
                }
            }
        }
    }
}
