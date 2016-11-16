using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Radar.Model;
using Radar.BLL;
using Radar.Factory;
using Radar.Pages.Popup;
using Rg.Plugins.Popup.Extensions;

namespace Radar
{
	public partial class ModoPercursoPage : ContentPage
	{
        public ModoPercursoPage() 
        {
            InitializeComponent();
            Title = "Percursos";
            //Content = new ScrollView() { Content = teststack };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            salvarPercurso.IsToggled = PreferenciaUtils.SalvarPercurso;
            excluirAntigos.IsToggled = PreferenciaUtils.ExcluirAntigo;
        }


        public void salvarPercursoToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("salvarPercurso", 1);
			}
			else {
				regraPreferencia.gravar("salvarPercurso", 0);
			}
            */
            PreferenciaUtils.SalvarPercurso = e.Value;
        }

		public void excluirAntigosToggled(object sender, ToggledEventArgs e)
		{
            /*
			if (e.Value == true)
			{
				regraPreferencia.gravar("excluirAntigos", 1);
			}
			else {
				regraPreferencia.gravar("excluirAntigos", 0);
			}
            */
            PreferenciaUtils.ExcluirAntigo = e.Value;
        }

        async void tempoPercursoTapped(object sender, EventArgs e) {

            var page = new TempoPercursoPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
        }
	}
}

