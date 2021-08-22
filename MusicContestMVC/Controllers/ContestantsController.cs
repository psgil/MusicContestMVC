using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicContestMVC.Data;
using MusicContestMVC.Models;

namespace MusicContestMVC.Controllers
{
    public class ContestantsController : Controller
    {
        private readonly MusicContestMVCContext _context;

        public ContestantsController(MusicContestMVCContext context)
        {
            _context = context;
        }

        // GET: Contestants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contestant.ToListAsync());
        }

        // GET: Contestants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestant
                .FirstOrDefaultAsync(m => m.id == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // GET: Contestants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contestants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,Address")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contestant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contestant);
        }

        // GET: Contestants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestant.FindAsync(id);
            if (contestant == null)
            {
                return NotFound();
            }
            return View(contestant);
        }

        // POST: Contestants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,Address")] Contestant contestant)
        {
            if (id != contestant.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contestant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestantExists(contestant.id))
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
            return View(contestant);
        }

        // GET: Contestants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestant
                .FirstOrDefaultAsync(m => m.id == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // POST: Contestants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contestant = await _context.Contestant.FindAsync(id);
            _context.Contestant.Remove(contestant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestantExists(int id)
        {
            return _context.Contestant.Any(e => e.id == id);
        }
    }
}
