using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StepByStepProject.Data;
using StepByStepProject.Models;

namespace StepByStepProject.Controllers
{
    public class GosterimlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GosterimlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gosterimler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gosterimler.Include(g => g.Film).Include(g => g.Salon).Include(g => g.Sinema);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gosterimler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosterimler = await _context.Gosterimler
                .Include(g => g.Film)
                .Include(g => g.Salon)
                .Include(g => g.Sinema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gosterimler == null)
            {
                return NotFound();
            }

            return View(gosterimler);
        }

        // GET: Gosterimler/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
            ViewData["SinemaId"] = new SelectList(_context.Sinema, "Id", "Id");
            return View();
        }

        // POST: Gosterimler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmId,SalonId,Baslangic,Bitis,AltYazi,SinemaId")] Gosterimler gosterimler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gosterimler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Id", gosterimler.FilmId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", gosterimler.SalonId);
            ViewData["SinemaId"] = new SelectList(_context.Sinema, "Id", "Id", gosterimler.SinemaId);
            return View(gosterimler);
        }

        // GET: Gosterimler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosterimler = await _context.Gosterimler.FindAsync(id);
            if (gosterimler == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Id", gosterimler.FilmId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", gosterimler.SalonId);
            ViewData["SinemaId"] = new SelectList(_context.Sinema, "Id", "Id", gosterimler.SinemaId);
            return View(gosterimler);
        }

        // POST: Gosterimler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,SalonId,Baslangic,Bitis,AltYazi,SinemaId")] Gosterimler gosterimler)
        {
            if (id != gosterimler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gosterimler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GosterimlerExists(gosterimler.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Id", gosterimler.FilmId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id", gosterimler.SalonId);
            ViewData["SinemaId"] = new SelectList(_context.Sinema, "Id", "Id", gosterimler.SinemaId);
            return View(gosterimler);
        }

        // GET: Gosterimler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosterimler = await _context.Gosterimler
                .Include(g => g.Film)
                .Include(g => g.Salon)
                .Include(g => g.Sinema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gosterimler == null)
            {
                return NotFound();
            }

            return View(gosterimler);
        }

        // POST: Gosterimler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gosterimler = await _context.Gosterimler.FindAsync(id);
            _context.Gosterimler.Remove(gosterimler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GosterimlerExists(int id)
        {
            return _context.Gosterimler.Any(e => e.Id == id);
        }
    }
}
