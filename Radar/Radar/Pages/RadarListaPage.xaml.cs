using Radar.BLL;
using Radar.Factory;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radar.Pages
{
    public partial class RadarListaPage : ContentPage
    {
        public RadarListaPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            RadarBLL regraRadar = RadarFactory.create();
            RadarListView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            this.BindingContext = regraRadar.listar(true);
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;

            //Navigation.PushAsync(new ImovelForm((ImovelDTO)((ListView)sender).SelectedItem));
            //((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void excluirRadar(object sender, EventArgs e)
        {
            RadarInfo radar = (RadarInfo)((MenuItem)sender).BindingContext;
            RadarBLL regraRadar = RadarFactory.create();
            regraRadar.excluir(radar.Id);
            OnAppearing();
        }
    }
}
