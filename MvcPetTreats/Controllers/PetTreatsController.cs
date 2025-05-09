using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcPetTreats.Data;
using MvcPetTreats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPetTreats.Controllers
{
    public class PetTreatsController : Controller
    {
        private readonly MvcPetTreatsContext _context;

        public PetTreatsController(MvcPetTreatsContext context)
        {
            _context = context;
        }

        // GET: PetTreats
        public async Task<IActionResult> Index(string petTreatType, string searchString)
        {
            IQueryable<string> typeQuery = from t in _context.PetTreat
                                            orderby t.Type
                                            select t.Type;
            var treats = from t in _context.PetTreat
                         select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                treats = treats.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(petTreatType))
            {
                treats = treats.Where(x => x.Type == petTreatType);
            }

            var petTreatTypeVM = new PetTreatTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                PetTreats = await treats.ToListAsync()
            };

            return View(petTreatTypeVM);
        }

        // GET: PetTreats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.PetTreat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treat == null)
            {
                return NotFound();
            }

            return View(treat);
        }

        // GET: PetTreats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetTreats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpirationDate,Type,Flavor,Price")] PetTreat treat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treat);
        }

        // GET: PetTreats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.PetTreat.FindAsync(id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        // POST: PetTreats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpirationDate,Type,Flavor,Price")] PetTreat treat)
        {
            if (id != treat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetTreatExists(treat.Id))
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
            return View(treat);
        }

        // GET: PetTreats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.PetTreat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treat == null)
            {
                return NotFound();
            }

            return View(treat);
        }

        // POST: PetTreats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treat = await _context.PetTreat.FindAsync(id);
            _context.PetTreat.Remove(treat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetTreatExists(int id)
        {
            return _context.PetTreat.Any(e => e.Id == id);
        }
    }
}
