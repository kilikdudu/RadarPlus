using SQLite;
using System;
using System.Collections.Generic;

namespace Radar.Model
{
	//[Table("Grupo")]
	public class ResumoItemInfo
	{

		public string Descricao { get; set; }
		public string Valor { get; set; }
        /// <summary>
        /// DISGRAÇA DE CAMPO FUDIDO DO CAPETA!!!
        /// </summary>
        public string Foto { get; set; }
	 
	}
}
