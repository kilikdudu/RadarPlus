using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.BLL;
using Radar.Factory;
using Xamarin.Forms;

namespace Radar.Pages {
    public partial class ModoAudioPage : ContentPage {
		private static ModoAudioPage _ModoAudioPage;
		PreferenciaBLL regraPreferencia = PreferenciaFactory.create();
		public static ModoAudioPage Atual
		{
			get
			{
				return _ModoAudioPage;
			}
			private set
			{
				_ModoAudioPage = value;
			}
		}
        public ModoAudioPage() {
            InitializeComponent();
            Title = "Áudio";
            Content = new ScrollView() { Content = teststack };

			volumePersonalizado.IsToggled = Configuracao.SomCaixa;

			somCaixa.IsToggled = Configuracao.VolumePersonalizado;

        }
		public void volumePersonalizadoToogled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("volumePersonalizado", 1);
			}
			else {
				regraPreferencia.gravar("volumePersonalizado", 0);
			}
		}

		public void somCaixaToogled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				regraPreferencia.gravar("somCaixa", 1);
			}
			else {
				regraPreferencia.gravar("somCaixa", 0);
			}
		}

		protected override void OnAppearing()
		{

			base.OnAppearing();
			_ModoAudioPage = this;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_ModoAudioPage = null;
		}
    }
}
