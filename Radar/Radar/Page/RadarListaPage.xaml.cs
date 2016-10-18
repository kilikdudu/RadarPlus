using Radar.BLL;
using Radar.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radar.Page
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
            this.BindingContext = regraRadar.listar().Take(10);
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;

            //Navigation.PushAsync(new ImovelForm((ImovelDTO)((ListView)sender).SelectedItem));
            //((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void OnDelete(object sender, EventArgs e)
        {

        }
    }
}
