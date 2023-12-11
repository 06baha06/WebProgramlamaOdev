using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaOdev.Models;

namespace WebProgramlamaOdev.Controllers
{
    public class RandevuController : Controller
    {
        private BolumlerContext _context = new BolumlerContext();


        //localhost:7090/Randevu/GetDoktorlar?bolumId=1 doktor deneme

        public JsonResult GetDoktorlar(int bolumId)
        {
            var doktorList = _context.Doktorlar
                .Where(d => d.BolumID == bolumId)
                .Select(d => new { Value = d.DoktorID, Text = d.DoktorAdi })
                .ToList();

            return Json(doktorList);
        }
        public JsonResult GetSaat(int doktorId)
        {
            var saatList = _context.Saatler
                .Where(d => d.SaatID == doktorId)
                .Select(d => new { Value = d.SaatID, Text = d.Saatler })
                .ToList();

            return Json(saatList);
        }
        // GET: Randevu
        public async Task<IActionResult> Index()
        {
            var bolumlerContext = _context.Randevular.Include(r => r.Bolum).Include(r => r.Doktor).Include(r => r.Hasta).Include(r => r.Saat);
            return View(await bolumlerContext.ToListAsync());
        }

        // GET: Randevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Bolum)
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevu/Create
        public IActionResult Create()
        {
            ViewData["BolumID"] = new SelectList(_context.Bolumler, "BolumID", "BolumAdi");
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorAdi");
            ViewData["HastaID"] = new SelectList(_context.Hastalar, "HastaID", "HastaAdSoyad");
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "Saatler");
            return View();
        }

        // POST: Randevu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuID,HastaID,BolumID,DoktorID,SaatID")] Randevu randevu)
        {
            var username = HttpContext.Session.GetString("Sessionuser");

            _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Randevu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["BolumID"] = new SelectList(_context.Bolumler, "BolumID", "BolumAdi", randevu.BolumID);
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorAdi", randevu.DoktorID);
            ViewData["HastaID"] = new SelectList(_context.Hastalar, "HastaID", "HastaAdSoyad", randevu.HastaID);
            ViewData["SaatID"] = new SelectList(_context.Saatler, "SaatID", "Saatler", randevu.SaatID);
            return View(randevu);
        }

        // POST: Randevu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuID,HastaID,BolumID,DoktorID,SaatID")] Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

           
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Randevu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Bolum)
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .Include(r => r.Saat)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevular == null)
            {
                return Problem("Entity set 'BolumlerContext.Randevular'  is null.");
            }
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return (_context.Randevular?.Any(e => e.RandevuID == id)).GetValueOrDefault();
        }
    }
}
