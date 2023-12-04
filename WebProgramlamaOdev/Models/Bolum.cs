using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProgramlamaOdev.Models
{
	public class Bolum
	{
		public int BolumID { get; set; }
		[Required]
		[MaxLength(100)]
		[Display(Name = "Bolum Adı")]
		public string BolumAdi { get; set; }
		public ICollection<Doktor> Doktorlar { get; set; }
	}
}
