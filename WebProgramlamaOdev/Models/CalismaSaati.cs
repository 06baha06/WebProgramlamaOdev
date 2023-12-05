using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProgramlamaOdev.Models
{
	public class CalismaSaati
	{
		[Key]
		public int SaatID { get; set; }
		[Required]
		[MaxLength(100)]
		[Display(Name = "Calisma Saatleri")]
		public string Saatler { get; set; }
		public int DoktorID { get; set; }
		public Doktor Doktor { get; set; }
	}
}
