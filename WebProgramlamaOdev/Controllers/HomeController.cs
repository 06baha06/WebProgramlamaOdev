using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using WebProgramlamaOdev.Models;

namespace WebProgramlamaOdev.Controllers
{
	public class HomeController : Controller
	{
		private BolumlerContext _context = new BolumlerContext();
		
		static List<Admin> admins = new List<Admin>()
		{
			new Admin() {AdminEmail="abc",AdminPass="sau"},
		};

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Giris(Admin adm)
		{
			foreach (var item in admins) 
			{
				if(item.AdminEmail == adm.AdminEmail && item.AdminPass == adm.AdminPass)
				{
                    HttpContext.Session.SetString("Sessionuser",item.AdminEmail);

                    return View("Logged");
                }
                
            }

			return View();
		}
        public IActionResult Cikis()
        {
			HttpContext.Session.Clear();
            return View("Index");
        }
        public IActionResult HastaGiris(Hasta hasta)
        {
            //var hasta = _context.Hastalar.FirstOrDefault(h => h.HastaTC == HttpContext.Request.Form["HastaTC"] && h.HastaPass == HttpContext.Request.Form["HastaPass"]);
            //if (_context.Hastalar.HastaTc != null)
            //{
            //    // Veritabanında hasta bulundu, belirli bir işlemi gerçekleştir.
            //    // Örneğin, hasta bilgilerini kullanarak bir sayfa göster.
            //    return View("Logged");
            //}
            //return View();
            //foreach (var item in hasta)
            //{
            //    if (item.HastaTC == hasta.HastaTC && item.HastaPass == HttpContext.Request.Form["HastaPass"])
            //    {
            //        HttpContext.Session.SetInt32("Sessionuser", item.HastaTC);

            //        return View("Logged");
            //    }

            //}

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}