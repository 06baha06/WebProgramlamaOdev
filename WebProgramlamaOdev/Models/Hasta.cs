using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaOdev.Models
{
    public class Hasta
    {
        public int HastaID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "HastaAdSoyad")]
        public string HastaAdSoyad { get; set; }
        [Required]
        [Display(Name = "HastaTC")]
        public int HastaTC { get; set; }
        [Required]
        [Display(Name = "Hasta Sifre")]
        public int HastaPass { get; set; }
    }
}
