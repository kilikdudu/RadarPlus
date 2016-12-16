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
			var abaGrupo = new ColaboradorPage();
			abaGrupo.Icon = "ic_face_2x.png";
			abaGrupo.Title = "Colaboradores";

			var abaAdministracao = new GrupoAdministracaoPage();
			abaAdministracao.Icon = "ic_settings_2x.png";
			abaAdministracao.Title = "Administração";
			
			var abaPendentes = new UsuarioPendentePage();
			abaPendentes.Icon = "ic_check_circle_2x.png";
			abaPendentes.Title = "Pendentes";
			Children.Add(abaGrupo);
			Children.Add(abaAdministracao);
			Children.Add(abaPendentes);

		}
		
	}
}