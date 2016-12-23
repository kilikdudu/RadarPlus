﻿using SQLite;
using System;
using System.Collections.Generic;

namespace Radar.Model
{
	//[Table("Grupo")]
	public class ResumoInfo
	{
        public ResumoInfo()
        {
            Items = new List<ResumoItemInfo>();
        }

		public string Nome { get; set; }
		public string Imagem { get; set; }
		public IList<ResumoItemInfo> Items { get; set;}
		
	}
}