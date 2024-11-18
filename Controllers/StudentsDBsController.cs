using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gibjohn_Tutoring.Data;
using Gibjohn_Tutoring.Models;

namespace Gibjohn_Tutoring.Controllers
{
    public class StudentsDBsController : Controller
    {
        private readonly Gibjohn_TutoringContext _context;

        public StudentsDBsController(Gibjohn_TutoringContext context)
        {
            _context = context;
        }

        // GET: StudentsDBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentsDB.ToListAsync());
        }

        // GET: StudentsDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsDB = await _context.StudentsDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsDB == null)
            {
                return NotFound();
            }

            return View(studentsDB);
        }

        // GET: StudentsDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password")] StudentsDB studentsDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsDB);
        }

        // GET: StudentsDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsDB = await _context.StudentsDB.FindAsync(id);
            if (studentsDB == null)
            {
                return NotFound();
            }
            return View(studentsDB);
        }

        // POST: StudentsDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password")] StudentsDB studentsDB)
        {
            if (id != studentsDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsDBExists(studentsDB.Id))
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
            return View(studentsDB);
        }

        // GET: StudentsDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsDB = await _context.StudentsDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsDB == null)
            {
                return NotFound();
            }

            return View(studentsDB);
        }

        // POST: StudentsDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsDB = await _context.StudentsDB.FindAsync(id);
            if (studentsDB != null)
            {
                _context.StudentsDB.Remove(studentsDB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsDBExists(int id)
        {
            return _context.StudentsDB.Any(e => e.Id == id);
        }
    }
}
