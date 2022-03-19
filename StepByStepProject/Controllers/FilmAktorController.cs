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
    public class FilmAktorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmAktorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilmAktor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FilmAktors.Include(f => f.Actor).Include(f => f.Film);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FilmAktor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmAktor = await _context.FilmAktors
                .Include(f => f.Actor)
                .Include(f => f.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmAktor == null)
            {
                return NotFound();
            }

            return View(filmAktor);
        }

        // GET: FilmAktor/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "fullName");
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Name");
            return View();
        }

        // POST: FilmAktor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmId,ActorId,Rol,Sira")] FilmAktor filmAktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmAktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "fullName", filmAktor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Name", filmAktor.FilmId);
            return View(filmAktor);
        }

        // GET: FilmAktor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmAktor = await _context.FilmAktors.FindAsync(id);
            if (filmAktor == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "fullName", filmAktor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Name", filmAktor.FilmId);
            return View(filmAktor);
        }

        // POST: FilmAktor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,ActorId,Rol,Sira")] FilmAktor filmAktor)
        {
            if (id != filmAktor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmAktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmAktorExists(filmAktor.Id))
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id", filmAktor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "Id", filmAktor.FilmId);
            return View(filmAktor);
        }

        // GET: FilmAktor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmAktor = await _context.FilmAktors
                .Include(f => f.Actor)
                .Include(f => f.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmAktor == null)
            {
                return NotFound();
            }

            return View(filmAktor);
        }

        // POST: FilmAktor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmAktor = await _context.FilmAktors.FindAsync(id);
            _context.FilmAktors.Remove(filmAktor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmAktorExists(int id)
        {
            return _context.FilmAktors.Any(e => e.Id == id);
        }
    }
}
