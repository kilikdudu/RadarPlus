using SQLite;
using System;


namespace Radar.Model
{
	[Table("Tag")]
	public class TagInfo
	{
	
	[AutoIncrement, PrimaryKey]
     public int Id { get; set; }
	 public string Descricao { get; set; }
	 public string Cor { get; set; }
	 
	}
}
