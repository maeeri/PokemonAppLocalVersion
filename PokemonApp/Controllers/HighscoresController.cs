using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class HighscoresController : Controller
    {
        private readonly PokemonAppContext _context;

        public HighscoresController(PokemonAppContext context)
        {
            _context = context;
        }

        // GET: Highscores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Highscore.ToListAsync());
        }

        // GET: Highscores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // GET: Highscores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Highscores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Victories,Losses")] Highscore highscore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highscore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highscore);
        }

        // GET: Highscores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscore.FindAsync(id);
            if (highscore == null)
            {
                return NotFound();
            }
            return View(highscore);
        }

        // POST: Highscores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Victories,Losses")] Highscore highscore)
        {
            if (id != highscore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highscore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighscoreExists(highscore.Id))
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
            return View(highscore);
        }

        // GET: Highscores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // POST: Highscores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highscore = await _context.Highscore.FindAsync(id);
            _context.Highscore.Remove(highscore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighscoreExists(int id)
        {
            return _context.Highscore.Any(e => e.Id == id);
        }
    }
}
