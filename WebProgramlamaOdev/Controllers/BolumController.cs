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
    public class BolumController : Controller
    {
        private BolumlerContext _context = new BolumlerContext();

        // GET: Bolum
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            return _context.Bolumler != null ? 
                          View(await _context.Bolumler.ToListAsync()) :
                          Problem("Entity set 'BolumlerContext.Bolumler'  is null.");
        }

        // GET: Bolum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolumler
                .FirstOrDefaultAsync(m => m.BolumID == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // GET: Bolum/Creat
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Bolum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("BolumID,BolumAdi")] Bolum bolum)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(bolum);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(bolum);
        //}

        [HttpPost]
        public IActionResult Create (Bolum y)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            _context.Add(y);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: Bolum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolumler.FindAsync(id);
            if (bolum == null)
            {
                return NotFound();
            }
            return View(bolum);
        }

        // POST: Bolum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BolumID,BolumAdi")] Bolum bolum)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != bolum.BolumID)
            {
                return NotFound();
            }

            
                    _context.Update(bolum);
                    await _context.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Bolum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolumler
                .FirstOrDefaultAsync(m => m.BolumID == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // POST: Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (_context.Bolumler == null)
            {
                return Problem("Entity set 'BolumlerContext.Bolumler'  is null.");
            }
            var bolum = await _context.Bolumler.FindAsync(id);
            if (bolum != null)
            {
                _context.Bolumler.Remove(bolum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumExists(int id)
        {
          return (_context.Bolumler?.Any(e => e.BolumID == id)).GetValueOrDefault();
        }
    }
}
