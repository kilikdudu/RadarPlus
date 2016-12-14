using SQLite;
using System;


namespace Radar.Model
{
	//[Table("Colaborador")]
	public class ColaboradorInfo
	{
	
	 public string Nome { get; set; }
	 public string Email { get; set; }
	 public string Imagem { get; set; }
	 public string Pendente { get; set; }
	 public string Administrador { get; set; }
	 
	}
}
