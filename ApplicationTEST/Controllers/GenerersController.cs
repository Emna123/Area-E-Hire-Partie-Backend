using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationTEST.Models;

namespace ApplicationTEST.Controllers
{
    public class GenerersController : Controller
    {
        private readonly TodoContext _context;

        public GenerersController(TodoContext context)
        {
            _context = context;
        }

        // GET: Generers
      /*  public async Task<IActionResult> Index()
        {
            return View(await _context.Generer.ToListAsync());
        }

        // GET: Generers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generer = await _context.Generer
                .FirstOrDefaultAsync(m => m.id_generer == id);
            if (generer == null)
            {
                return NotFound();
            }

            return View(generer);
        }

        // GET: Generers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_generer,poste_domande,domaine_activite,photo_profil,salaire_min")] Generer generer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generer);
        }

        // GET: Generers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generer = await _context.Generer.FindAsync(id);
            if (generer == null)
            {
                return NotFound();
            }
            return View(generer);
        }

        // POST: Generers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_generer,poste_domande,domaine_activite,photo_profil,salaire_min")] Generer generer)
        {
            if (id != generer.id_generer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenererExists(generer.id_generer))
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
            return View(generer);
        }

        // GET: Generers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generer = await _context.Generer
                .FirstOrDefaultAsync(m => m.id_generer == id);
            if (generer == null)
            {
                return NotFound();
            }

            return View(generer);
        }

        // POST: Generers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generer = await _context.Generer.FindAsync(id);
            _context.Generer.Remove(generer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenererExists(int id)
        {
            return _context.Generer.Any(e => e.id_generer == id);
        }*/
    }
}
