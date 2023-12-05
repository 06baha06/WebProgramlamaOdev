using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProgramlamaOdev.Models;

namespace WebProgramlamaOdev.Controllers
{
	public class HomeController : Controller
	{
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}