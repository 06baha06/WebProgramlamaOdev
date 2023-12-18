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
    public class HastaController : Controller
    {
        private BolumlerContext _context = new BolumlerContext();

        // GET: Hasta
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            return _context.Hastalar != null ? 
                          View(await _context.Hastalar.ToListAsync()) :
                          Problem("Entity set 'BolumlerContext.Hastalar'  is null.");
        }

        // GET: Hasta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.HastaID == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: Hasta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hasta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastaID,HastaAdSoyad,HastaTC,HastaPass")] Hasta hasta)
        {
           
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                

            return RedirectToAction("HastaGiris", "Home");
        }

        // GET: Hasta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: Hasta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HastaID,HastaTC,HastaPass")] Hasta hasta)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != hasta.HastaID)
            {
                return NotFound();
            }

            
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
               
                   
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Hasta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.HastaID == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: Hasta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Sessionuseradm") is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (_context.Hastalar == null)
            {
                return Problem("Entity set 'BolumlerContext.Hastalar'  is null.");
            }
            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta != null)
            {
                _context.Hastalar.Remove(hasta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
          return (_context.Hastalar?.Any(e => e.HastaID == id)).GetValueOrDefault();
        }
    }
}
