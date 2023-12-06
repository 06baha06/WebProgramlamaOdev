using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaOdev.Models
{
    public class Hasta
    {
        public int HastaID { get; set; }
        [Required]
        [Display(Name = "HastaTC")]
        public int HastaTC { get; set; }
        [Required]
        [Display(Name = "Hasta Sifre")]
        public int HastaPass { get; set; }
    }
}
