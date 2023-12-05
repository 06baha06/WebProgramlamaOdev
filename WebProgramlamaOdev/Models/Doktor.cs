using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProgramlamaOdev.Models
{
	public class Doktor
	{
		[Key]
		public int DoktorID { get; set; }
		[Required]
		[MaxLength(100)]
		[Display(Name="Doktor Adı")]
		public string DoktorAdi { get; set;}
		[Required]
		[MaxLength(100)]
		[Display(Name = "Doktor Soyadı")]
		public string DoktorSoyadi { get; set; }
		public int BolumID { get; set; }
		public  Bolum Bolum { get; set;}
		public ICollection<CalismaSaati> Saatler { get; set; } //saatler

	}
}
