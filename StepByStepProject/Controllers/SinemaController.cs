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
    public class SinemaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinemaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sinema
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sinema.Include(s => s.Ilce);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sinema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinema = await _context.Sinema
                .Include(s => s.Ilce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinema == null)
            {
                return NotFound();
            }

            return View(sinema);
        }

        // GET: Sinema/Create
        public IActionResult Create()
        {
            ViewData["IlceId"] = new SelectList(_context.Ilce, "Id", "Id");
            return View();
        }

        // POST: Sinema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SinemaAd,IlceId,Iletisim,Adres")] Sinema sinema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IlceId"] = new SelectList(_context.Ilce, "Id", "Id", sinema.IlceId);
            return View(sinema);
        }

        // GET: Sinema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinema = await _context.Sinema.FindAsync(id);
            if (sinema == null)
            {
                return NotFound();
            }
            ViewData["IlceId"] = new SelectList(_context.Ilce, "Id", "Id", sinema.IlceId);
            return View(sinema);
        }

        // POST: Sinema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SinemaAd,IlceId,Iletisim,Adres")] Sinema sinema)
        {
            if (id != sinema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinemaExists(sinema.Id))
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
            ViewData["IlceId"] = new SelectList(_context.Ilce, "Id", "Id", sinema.IlceId);
            return View(sinema);
        }

        // GET: Sinema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinema = await _context.Sinema
                .Include(s => s.Ilce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinema == null)
            {
                return NotFound();
            }

            return View(sinema);
        }

        // POST: Sinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinema = await _context.Sinema.FindAsync(id);
            _context.Sinema.Remove(sinema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinemaExists(int id)
        {
            return _context.Sinema.Any(e => e.Id == id);
        }
    }
}
