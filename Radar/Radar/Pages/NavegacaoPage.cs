using Radar.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Radar.Model;

using Xamarin.Forms;

namespace Radar.Pages
{
    public class NavegacaoPage : MasterDetailPage
    {
        MenuPage masterPage;

        public NavegacaoPage()
        {
            masterPage = new MenuPage();
            Master = masterPage;
			var  nav = new NavigationPage(new VelocimetroPage());
			nav.BarBackgroundColor = Color.FromHex(TemaInfo.DarkPrimaryColor);
			nav.BarTextColor = Color.FromHex(TemaInfo.PrimaryText);

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
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItemInfo;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
