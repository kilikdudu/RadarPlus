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
        public ModoMeuRadarPage()
        {
            InitializeComponent();
            Title = "Meus Radares";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            exibirBotaoAdcionar.IsToggled = PreferenciaUtils.ExibirBotaoAdicionar;
            exibirBotaoRemover.IsToggled = PreferenciaUtils.ExibirBotaoRemover;
        }


        public void exibirBotaoAdcionarToggled(object sender, ToggledEventArgs e)
		{
            PreferenciaUtils.ExibirBotaoAdicionar = e.Value;
        }

		public void exibirBotaoRemoverToggled(object sender, ToggledEventArgs e)
		{
            PreferenciaUtils.ExibirBotaoRemover = e.Value;
        }
	}
}

