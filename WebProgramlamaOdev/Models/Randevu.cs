using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProgramlamaOdev.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        public int HastaID { get; set; }
        public Hasta Hasta { get; set; }
        public int BolumID { get; set; }
        public Bolum Bolum { get; set; }
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
        public int SaatID { get; set; }
        public CalismaSaati Saat { get; set; }
        
    }
}
