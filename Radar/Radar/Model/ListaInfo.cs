﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
	public  class ListaInfo
	{
		

		public  string Titulo
		{
			get; set;
		
		}
		public  string Imagem
		{
			get; set;

		}
		public EventHandler aoClicar { get; set; }
	}
}

