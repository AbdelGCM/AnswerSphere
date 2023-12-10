using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Data;
using AnswerSphere.Models;

namespace AnswerSphere.Controllers
{
    public class ReponsesController : Controller
    {
        private readonly AnswerContext _context;

        public ReponsesController(AnswerContext context)
        {
            _context = context;
        }

        // GET: Reponses
        public async Task<IActionResult> Index()
        {
            var reponses = await _context.Reponse.Include(r => r.Option).ToListAsync();

            var reponseOptionViewModels = reponses.Select(r => new ReponseOptionViewModel
            {
                Reponse = r,
                Option = r.Option
            }).ToList();

            return View(reponseOptionViewModels);
        }


        // GET: Reponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponse
                .Include(r => r.Option)
                .FirstOrDefaultAsync(m => m.ReponseId == id);
            if (reponse == null)
            {
                return NotFound();
            }

            return View(reponse);
        }

        // GET: Reponses/Create
        public IActionResult Create()
        {
            ViewData["OptionId"] = new SelectList(_context.Set<Option>(), "OptionId", "OptionLibelle");
            return View();
        }

        // POST: Reponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReponseId,RepondantNom,OptionId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionId"] = new SelectList(_context.Set<Option>(), "OptionId", "OptionLibelle", reponse.OptionId);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponse.FindAsync(id);
            if (reponse == null)
            {
                return NotFound();
            }
            ViewData["OptionId"] = new SelectList(_context.Set<Option>(), "OptionId", "OptionLibelle", reponse.OptionId);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReponseId,RepondantNom,OptionId")] Reponse reponse)
        {
            if (id != reponse.ReponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReponseExists(reponse.ReponseId))
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
            ViewData["OptionId"] = new SelectList(_context.Set<Option>(), "OptionId", "OptionLibelle", reponse.OptionId);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponse
                .Include(r => r.Option)
                .FirstOrDefaultAsync(m => m.ReponseId == id);
            if (reponse == null)
            {
                return NotFound();
            }

            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reponse = await _context.Reponse.FindAsync(id);
            if (reponse != null)
            {
                _context.Reponse.Remove(reponse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReponseExists(int id)
        {
            return _context.Reponse.Any(e => e.ReponseId == id);
        }
    }
}
