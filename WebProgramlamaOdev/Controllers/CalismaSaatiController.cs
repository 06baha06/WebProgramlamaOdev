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
    public class CalismaSaatiController : Controller
    {
		private BolumlerContext _context = new BolumlerContext();

		// GET: CalismaSaati
		public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var bolumlerContext = _context.Saatler.Include(c => c.Doktor);
            return View(await bolumlerContext.ToListAsync());
        }

        // GET: CalismaSaati/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Saatler == null)
            {
                return NotFound();
            }

            var calismaSaati = await _context.Saatler
                .Include(c => c.Doktor)
                .FirstOrDefaultAsync(m => m.SaatID == id);
            if (calismaSaati == null)
            {
                return NotFound();
            }

            return View(calismaSaati);
        }

        // GET: CalismaSaati/Creat
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorAdi");
            return View();
        }

        // POST: CalismaSaati/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaatID,Saatler,DoktorID")] CalismaSaati calismaSaati)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }

            _context.Add(calismaSaati);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: CalismaSaati/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Saatler == null)
            {
                return NotFound();
            }

            var calismaSaati = await _context.Saatler.FindAsync(id);
            if (calismaSaati == null)
            {
                return NotFound();
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktorlar, "DoktorID", "DoktorAdi", calismaSaati.DoktorID);
            return View(calismaSaati);
        }

        // POST: CalismaSaati/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaatID,Saatler,DoktorID")] CalismaSaati calismaSaati)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != calismaSaati.SaatID)
            {
                return NotFound();
            }

           
                    _context.Update(calismaSaati);
                    await _context.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: CalismaSaati/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Saatler == null)
            {
                return NotFound();
            }

            var calismaSaati = await _context.Saatler
                .Include(c => c.Doktor)
                .FirstOrDefaultAsync(m => m.SaatID == id);
            if (calismaSaati == null)
            {
                return NotFound();
            }

            return View(calismaSaati);
        }

        // POST: CalismaSaati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (_context.Saatler == null)
            {
                return Problem("Entity set 'BolumlerContext.Saatler'  is null.");
            }
            var calismaSaati = await _context.Saatler.FindAsync(id);
            if (calismaSaati != null)
            {
                _context.Saatler.Remove(calismaSaati);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalismaSaatiExists(int id)
        {
          return (_context.Saatler?.Any(e => e.SaatID == id)).GetValueOrDefault();
        }
    }
}
