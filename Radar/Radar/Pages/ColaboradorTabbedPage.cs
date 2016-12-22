﻿using Xamarin.Forms;

namespace Radar.Pages
{
	public class ColaboradorTabbedPage : TabbedPage
	{
		public ColaboradorTabbedPage()
		{
			var abaColaborador = new ColaboradorPage();
			abaColaborador.Icon = "grupo_40.png";
			abaColaborador.Title = "Colaboradores";

			var abaUsuarioPendente = new UsuarioPendentePage();
			abaUsuarioPendente.Icon = "config_40.png";
			abaUsuarioPendente.Title = "Usuários Pendentes";
			
			var abaEmpresas = new EmpresaAdministracaoPage();
			abaEmpresas.Icon = "config_40.png";
			abaEmpresas.Title = "Empresas";
			
			Children.Add(abaColaborador);
			Children.Add(abaUsuarioPendente);
			Children.Add(abaEmpresas);

		}
	}
}