using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoMeuRadarPage : ContentPage
	{
		private static ModoMeuRadarPage _ModoMeuRadarPage;
		public ObservableCollection<PreferenciaLabelInfo> Labels { get; set; }
		public static ModoMeuRadarPage Atual
		{
			get
			{
				return _ModoMeuRadarPage;
			}
			private set
			{
				_ModoMeuRadarPage = value;
			}
		}
        public ModoMeuRadarPage()
        {
            InitializeComponent();
            Title = "Meus Radares";
            Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
			_ModoMeuRadarPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoMeuRadarPage = null;
		}
	}
}

