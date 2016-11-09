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
		private static ModoPercursoPage _ModoPercursoPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
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
            //Content = new ScrollView() { Content = teststack };

			salvarPercurso.IsToggled = Configuracao.SalvarPercurso;

			excluirAntigos.IsToggled = Configuracao.ExcluirAntigos;
        }

		public void salvarPercursoToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("salvarPercurso", 1);
			}
			else {
				regraPreferencia.gravar("salvarPercurso", 0);
			}

		}

		public void excluirAntigosToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("excluirAntigos", 1);
			}
			else {
				regraPreferencia.gravar("excluirAntigos", 0);
			}

		}

        async void tempoPercursoTapped(object sender, EventArgs e) {

            var page = new TempoPercursoPopUp();

            await Navigation.PushPopupAsync(page);
            // or
            //await Navigation.PushAsync(page);
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

