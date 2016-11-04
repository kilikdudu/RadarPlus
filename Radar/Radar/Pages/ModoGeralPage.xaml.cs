using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;
using Radar.BLL;
using Radar.Factory;

namespace Radar
{
	public partial class ModoGeralPage : ContentPage
	{
		private static ModoGeralPage _ModoGeralPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

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

			intervaloVerificacao.IsToggled = Configuracao.IntervaloVerificacao;
        }

		public void intervaloVerificacaoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("intervaloVerificacao", 1);
			}
			else {
				regraPreferencia.gravar("intervaloVerificacao", 0);
			}
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

