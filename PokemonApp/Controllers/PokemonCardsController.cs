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
    public class PokemonCardsController : Controller
    {
        private readonly PokemonAppContext _context;

        public PokemonCardsController(PokemonAppContext context)
        {
            _context = context;
        }

        // GET: PokemonCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.PokemonCard.ToListAsync());
        }

        // GET: PokemonCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonCard = await _context.PokemonCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemonCard == null)
            {
                return NotFound();
            }

            return View(pokemonCard);
        }

        // GET: PokemonCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PokemonCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Name,PokemonId")] PokemonCard pokemonCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemonCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemonCard);
        }

        // GET: PokemonCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonCard = await _context.PokemonCard.FindAsync(id);
            if (pokemonCard == null)
            {
                return NotFound();
            }
            return View(pokemonCard);
        }

        // POST: PokemonCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Name,PokemonId")] PokemonCard pokemonCard)
        {
            if (id != pokemonCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemonCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonCardExists(pokemonCard.Id))
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
            return View(pokemonCard);
        }

        // GET: PokemonCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonCard = await _context.PokemonCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemonCard == null)
            {
                return NotFound();
            }

            return View(pokemonCard);
        }

        // POST: PokemonCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemonCard = await _context.PokemonCard.FindAsync(id);
            _context.PokemonCard.Remove(pokemonCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonCardExists(int id)
        {
            return _context.PokemonCard.Any(e => e.Id == id);
        }
    }
}
