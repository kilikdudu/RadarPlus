using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;

namespace Radar
{
	public partial class ModoPercursoPage : ContentPage
	{
		private static ModoPercursoPage _ModoPercursoPage;
		public ObservableCollection<PreferenciaLabelInfo> Labels { get; set; }
		public static ModoPercursoPage Atual
		{
			get
			{
				return _ModoPercursoPage;
			}
			private set
			{
				_ModoPercursoPage = value;
			}
		}
        public ModoPercursoPage() 
        {
            InitializeComponent();
                Title = "Percursos";
            Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
		{
			base.OnAppearing();
			_ModoPercursoPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoPercursoPage = null;
		}
	}
}

