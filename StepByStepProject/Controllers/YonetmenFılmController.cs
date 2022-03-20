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
    public class YonetmenFılmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YonetmenFılmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YonetmenFılm
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.YonetmenFılm.Include(y => y.Film).Include(y => y.Yonetmen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: YonetmenFılm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmenFılm = await _context.YonetmenFılm
                .Include(y => y.Film)
                .Include(y => y.Yonetmen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetmenFılm == null)
            {
                return NotFound();
            }

            return View(yonetmenFılm);
        }

        // GET: YonetmenFılm/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "FilmAd");
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmen, "Id", "fullName");
            return View();
        }

        // POST: YonetmenFılm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmId,YonetmenId,Sira,YonetmenTip")] YonetmenFılm yonetmenFılm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetmenFılm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "FilmAd", yonetmenFılm.FilmId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmen, "Id", "fullName", yonetmenFılm.YonetmenId);
            return View(yonetmenFılm);
        }

        // GET: YonetmenFılm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmenFılm = await _context.YonetmenFılm.FindAsync(id);
            if (yonetmenFılm == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "FilmAd", yonetmenFılm.FilmId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmen, "Id", "fullName", yonetmenFılm.YonetmenId);
            return View(yonetmenFılm);
        }

        // POST: YonetmenFılm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,YonetmenId,Sira,YonetmenTip")] YonetmenFılm yonetmenFılm)
        {
            if (id != yonetmenFılm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetmenFılm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmenFılmExists(yonetmenFılm.Id))
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
            ViewData["FilmId"] = new SelectList(_context.Film, "Id", "FilmAd", yonetmenFılm.FilmId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmen, "Id", "fullName", yonetmenFılm.YonetmenId);
            return View(yonetmenFılm);
        }

        // GET: YonetmenFılm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmenFılm = await _context.YonetmenFılm
                .Include(y => y.Film)
                .Include(y => y.Yonetmen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetmenFılm == null)
            {
                return NotFound();
            }

            return View(yonetmenFılm);
        }

        // POST: YonetmenFılm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetmenFılm = await _context.YonetmenFılm.FindAsync(id);
            _context.YonetmenFılm.Remove(yonetmenFılm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmenFılmExists(int id)
        {
            return _context.YonetmenFılm.Any(e => e.Id == id);
        }
    }
}
