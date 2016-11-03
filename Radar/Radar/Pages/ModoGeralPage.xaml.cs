using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoGeralPage : ContentPage
	{
		private static ModoGeralPage _ModoGeralPage;
		public ObservableCollection<PreferenciaLabelInfo> Labels { get; set; }
		public static ModoGeralPage Atual
		{
			get
			{
				return _ModoGeralPage;
			}
			private set
			{
                _ModoGeralPage = value;
			}
		}
        public ModoGeralPage() 
        {
            InitializeComponent();
            Title = "Gerais";
            Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
            _ModoGeralPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            _ModoGeralPage = null;
		}
	}
}

