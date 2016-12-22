using Xamarin.Forms;

namespace Radar.Pages
{
	public class GrupoTabbedPage : TabbedPage
	{
		public GrupoTabbedPage()
		{
			inicializaComponente();	
		}
		
		public void inicializaComponente()
		{
			var abaColaborador = new ColaboradorPage();
			abaColaborador.Icon = "ic_face_2x.png";
			abaColaborador.Title = "Colaboradores";

			var abaAdministracao = new EmpresaAdministracaoPage();
			abaAdministracao.Icon = "ic_settings_2x.png";
			abaAdministracao.Title = "Administração";
			
			var abaPendentes = new UsuarioPendentePage();
			abaPendentes.Icon = "ic_check_circle_2x.png";
			abaPendentes.Title = "Pendentes";
			Children.Add(abaColaborador);
			//Children.Add(abaAdministracao);
			Children.Add(abaPendentes);

		}
		
	}
}