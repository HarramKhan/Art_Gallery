using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Art_Gallery.Data;
using Art_Gallery.Models;

namespace Art_Gallery.Controllers
{
    public class artsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public artsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: arts
        public async Task<IActionResult> Index()
        {
            return View(await _context.art.ToListAsync());
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        
        public async Task<IActionResult> SearchResult(string name)
        {
            return View("Index", await _context.art.Where(a => a.name.Contains(name)).ToListAsync());

        }


    // GET: arts/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.art
                .FirstOrDefaultAsync(m => m.ID == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // GET: arts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: arts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,URL")] art art)
        {
            if (ModelState.IsValid)
            {
                _context.Add(art);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art);
        }

        // GET: arts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.art.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }
            return View(art);
        }

        // POST: arts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,URL")] art art)
        {
            if (id != art.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!artExists(art.ID))
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
            return View(art);
        }

        // GET: arts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.art
                .FirstOrDefaultAsync(m => m.ID == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // POST: arts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var art = await _context.art.FindAsync(id);
            _context.art.Remove(art);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool artExists(int id)
        {
            return _context.art.Any(e => e.ID == id);
        }
    }
}
