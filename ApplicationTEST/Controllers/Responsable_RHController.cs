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
    public class Responsable_RHController : Controller
    {
        private readonly TodoContext _context;

        public Responsable_RHController(TodoContext context)
        {
            _context = context;
        }

        // GET: Responsable_RH
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsable_RH.ToListAsync());
        }

        // GET: Responsable_RH/Details/5
<<<<<<< Updated upstream
        public async Task<IActionResult> Details(int? id)
=======
       /* public async Task<IActionResult> Details(int? id)
>>>>>>> Stashed changes
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsable_RH = await _context.Responsable_RH
                .FirstOrDefaultAsync(m => m.id_resp == id);
            if (responsable_RH == null)
            {
                return NotFound();
            }

            return View(responsable_RH);
        }

        // GET: Responsable_RH/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsable_RH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_resp,e_mail,mdp,code")] Responsable_RH responsable_RH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsable_RH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsable_RH);
        }

        // GET: Responsable_RH/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsable_RH = await _context.Responsable_RH.FindAsync(id);
            if (responsable_RH == null)
            {
                return NotFound();
            }
            return View(responsable_RH);
        }

        // POST: Responsable_RH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_resp,e_mail,mdp,code")] Responsable_RH responsable_RH)
        {
            if (id != responsable_RH.id_resp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsable_RH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Responsable_RHExists(responsable_RH.id_resp))
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
            return View(responsable_RH);
        }

        // GET: Responsable_RH/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsable_RH = await _context.Responsable_RH
                .FirstOrDefaultAsync(m => m.id_resp == id);
            if (responsable_RH == null)
            {
                return NotFound();
            }
<<<<<<< Updated upstream

            return View(responsable_RH);
        }

        // POST: Responsable_RH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsable_RH = await _context.Responsable_RH.FindAsync(id);
            _context.Responsable_RH.Remove(responsable_RH);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Responsable_RHExists(int id)
        {
            return _context.Responsable_RH.Any(e => e.id_resp == id);
=======

            return View(responsable_RH);
>>>>>>> Stashed changes
        }

        // POST: Responsable_RH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsable_RH = await _context.Responsable_RH.FindAsync(id);
            _context.Responsable_RH.Remove(responsable_RH);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Responsable_RHExists(int id)
        {
            return _context.Responsable_RH.Any(e => e.id_resp == id);
        }*/
    }
}
