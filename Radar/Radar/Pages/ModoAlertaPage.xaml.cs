using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoAlertaPage : ContentPage
	{
		private static ModoAlertaPage _ModoAlertaPage;
		public ObservableCollection<PreferenciaLabelInfo> Labels { get; set; }
		public static ModoAlertaPage Atual
		{
			get
			{
				return _ModoAlertaPage;
			}
			private set
			{
                _ModoAlertaPage = value;
			}
		}
        
        public ModoAlertaPage() {
            InitializeComponent();
            Title = "Alertas";
            Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
            _ModoAlertaPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            _ModoAlertaPage = null;
		}
	}
}

