using System;
using SQLite;
namespace Radar.Model
{
	[Table("preferencia")]
	public class PreferenciaInfo
	{


			private string _preferencia;
			private string _valor;


		    [PrimaryKey, Obsolete("Usando preferencia")]
			
			public string preferencia
			{
				get
				{
					return _preferencia;
				}
				set
				{
					_preferencia = value;
				}
			}

			[Obsolete("Usando valor")]
			public string valor
			{
				get
				{
					return _valor;
				}
				set
				{
					_valor = value;
				}
			}

	}
}
