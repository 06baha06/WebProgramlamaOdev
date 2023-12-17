using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using WebProgramlamaOdev.Models;
using WebProgramlamaOdev.Services;

namespace WebProgramlamaOdev.Controllers
{
	public class HomeController : Controller
	{
		private BolumlerContext _context = new BolumlerContext();
		private LanguageService _localization;
		public HomeController(LanguageService localization)
		{
			_localization = localization;
		}

		static List<Admin> admins = new List<Admin>()
		{
			new Admin() {AdminEmail="abc",AdminPass="sau"},
		};

		public IActionResult Index()
		{
			ViewBag.Welcome = _localization.Getkey("welcome").Value;
			var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
			return View();
		}
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
				{
					Expires = DateTimeOffset.UtcNow.AddYears(1)
				});
			return Redirect(Request.Headers["Referer"].ToString());
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
            foreach (var item in _context.Hastalar)
            {
                
                if (item.HastaTC == hasta.HastaTC && item.HastaPass == hasta.HastaPass)
                {
                    HttpContext.Session.SetString("Sessionuser", item.HastaAdSoyad);
                    HttpContext.Session.SetInt32("Sessionuserid", item.HastaID);

                    
                    return RedirectToAction("Create","Randevu");
                }

            }

            return View();
        }

		public IActionResult RandevuControl()
		{
			var userId = HttpContext.Session.GetInt32("Sessionuserid");

			// Kullanıcının kendi randevularını çek
			var appointments = _context.Randevular
                .Include(r => r.Bolum)
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Saat)
                .Where(a => a.HastaID == userId)
				.ToList();

			return View(appointments);
		}

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}