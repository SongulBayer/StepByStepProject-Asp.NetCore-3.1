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
    public class YonetmenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YonetmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yonetmen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yonetmen.Include(y => y.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yonetmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmen = await _context.Yonetmen
                .Include(y => y.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetmen == null)
            {
                return NotFound();
            }

            return View(yonetmen);
        }

        // GET: Yonetmen/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
            return View();
        }

        // POST: Yonetmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,CountryId,Gender,BirthDate")] Yonetmen yonetmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", yonetmen.CountryId);
            return View(yonetmen);
        }

        // GET: Yonetmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmen = await _context.Yonetmen.FindAsync(id);
            if (yonetmen == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", yonetmen.CountryId);
            return View(yonetmen);
        }

        // POST: Yonetmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,CountryId,Gender,BirthDate")] Yonetmen yonetmen)
        {
            if (id != yonetmen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmenExists(yonetmen.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", yonetmen.CountryId);
            return View(yonetmen);
        }

        // GET: Yonetmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmen = await _context.Yonetmen
                .Include(y => y.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetmen == null)
            {
                return NotFound();
            }

            return View(yonetmen);
        }

        // POST: Yonetmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetmen = await _context.Yonetmen.FindAsync(id);
            _context.Yonetmen.Remove(yonetmen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmenExists(int id)
        {
            return _context.Yonetmen.Any(e => e.Id == id);
        }
    }
}
