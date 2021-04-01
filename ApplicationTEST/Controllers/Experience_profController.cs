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
    public class Experience_profController : Controller
    {
        private readonly TodoContext _context;

        public Experience_profController(TodoContext context)
        {
            _context = context;
        }

        // GET: Experience_prof
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experience_prof.ToListAsync());
        }

        // GET: Experience_prof/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_prof = await _context.Experience_prof
                .FirstOrDefaultAsync(m => m.id_ex == id);
            if (experience_prof == null)
            {
                return NotFound();
            }

            return View(experience_prof);
        }

        // GET: Experience_prof/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experience_prof/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_ex,poste_occupe,lieu_Exp,date_debut,date_fin,description")] Experience_prof experience_prof)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience_prof);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience_prof);
        }

        // GET: Experience_prof/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_prof = await _context.Experience_prof.FindAsync(id);
            if (experience_prof == null)
            {
                return NotFound();
            }
            return View(experience_prof);
        }

        // POST: Experience_prof/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_ex,poste_occupe,lieu_Exp,date_debut,date_fin,description")] Experience_prof experience_prof)
        {
            if (id != experience_prof.id_ex)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience_prof);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Experience_profExists(experience_prof.id_ex))
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
            return View(experience_prof);
        }

        // GET: Experience_prof/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_prof = await _context.Experience_prof
                .FirstOrDefaultAsync(m => m.id_ex == id);
            if (experience_prof == null)
            {
                return NotFound();
            }

            return View(experience_prof);
        }

        // POST: Experience_prof/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience_prof = await _context.Experience_prof.FindAsync(id);
            _context.Experience_prof.Remove(experience_prof);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Experience_profExists(int id)
        {
            return _context.Experience_prof.Any(e => e.id_ex == id);
        }
    }
}
