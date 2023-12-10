using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Data;
using Answersphere.Models;

namespace Answersphere.Controllers
{
    public class OptionController : Controller
    {
        private readonly AnswerSphereContext _context;

        public OptionController(AnswerSphereContext context)
        {
            _context = context;
        }

        // GET: Option
        public async Task<IActionResult> Index()
        {
            var answerSphereContext = _context.Option.Include(o => o.Question);
            return View(await answerSphereContext.ToListAsync());
        }

        // GET: Option/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .Include(o => o.Question)
                .FirstOrDefaultAsync(m => m.OptionId == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // GET: Option/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId");
            return View();
        }

        // POST: Option/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptionId,OptionLibelle,QuestionId")] Option option)
        {
            if (ModelState.IsValid)
            {
                _context.Add(option);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", option.QuestionId);
            return View(option);
        }

        // GET: Option/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", option.QuestionId);
            return View(option);
        }

        // POST: Option/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OptionId,OptionLibelle,QuestionId")] Option option)
        {
            if (id != option.OptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(option);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptionExists(option.OptionId))
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
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", option.QuestionId);
            return View(option);
        }

        // GET: Option/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .Include(o => o.Question)
                .FirstOrDefaultAsync(m => m.OptionId == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // POST: Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var option = await _context.Option.FindAsync(id);
            if (option != null)
            {
                _context.Option.Remove(option);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.OptionId == id);
        }
    }
}
