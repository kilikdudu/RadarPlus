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
	public partial class ModoMeuRadarPage : ContentPage
	{
		private static ModoMeuRadarPage _ModoMeuRadarPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
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

			exibirBotaoAdcionar.IsToggled = Configuracao.ExibirBotaoAdcionar;

			exibirBotaoRemover.IsToggled = Configuracao.ExibirBotaoRemover;
        }

		public void exibirBotaoAdcionarToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("exibirBotaoAdcionar", 1);
			}
			else {
				regraPreferencia.gravar("exibirBotaoAdcionar", 0);
			}

		}

		public void exibirBotaoRemoverToogled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("exibirBotaoRemover", 1);
			}
			else {
				regraPreferencia.gravar("exibirBotaoRemover", 0);
			}

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

