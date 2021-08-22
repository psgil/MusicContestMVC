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
    public class JudgesController : Controller
    {
        private readonly MusicContestMVCContext _context;

        public JudgesController(MusicContestMVCContext context)
        {
            _context = context;
        }

        // GET: Judges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Judge.ToListAsync());
        }

        public async Task<IActionResult> viewJudge()
        {
            return View(await _context.Judge.ToListAsync());
        }


        // GET: Judges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judge
                .FirstOrDefaultAsync(m => m.id == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // GET: Judges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Judges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,Details")] Judge judge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(judge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(judge);
        }

        // GET: Judges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judge.FindAsync(id);
            if (judge == null)
            {
                return NotFound();
            }
            return View(judge);
        }

        // POST: Judges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,Details")] Judge judge)
        {
            if (id != judge.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(judge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JudgeExists(judge.id))
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
            return View(judge);
        }

        // GET: Judges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judge
                .FirstOrDefaultAsync(m => m.id == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // POST: Judges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var judge = await _context.Judge.FindAsync(id);
            _context.Judge.Remove(judge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JudgeExists(int id)
        {
            return _context.Judge.Any(e => e.id == id);
        }
    }
}
