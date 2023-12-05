using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProgramlamaOdev.Models
{
	public class BolumlerContext:DbContext
	{
		public DbSet<Bolum>? Bolumler { get; set; }
		public DbSet<Doktor>? Doktorlar { get; set; }
		public DbSet<CalismaSaati>? Saatler { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Randevu1;Trusted_Connection=True");
		}
	}
}
