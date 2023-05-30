using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAPIWebApp.Models;

namespace StudentAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : Controller
    {
        private readonly StudentAPIContext _context;

        public GradesController(StudentAPIContext context)
        {
            _context = context;
        }

        // GET: Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> Index()
        {
            var studentAPIContext = _context.Grades;
            return await studentAPIContext.ToListAsync();
        }

        // GET: Grades/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> Details(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }
        /*
        // GET: Grades/Create
        [HttpPut]
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");
            return View();
        }
        */
        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Grade>> Create([FromBody] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", grade.SubjectId);
            return Ok(grade);
        }
        /*
        // GET: Grades/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", grade.SubjectId);
            return View(grade);
        }
        */
        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<ActionResult<Grade>> Edit(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", grade.SubjectId);
            return Ok(grade);
        }
        /*
        // GET: Grades/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }
        */
        // POST: Grades/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grade>> DeleteConfirmed(int id)
        {
            if (_context.Grades == null)
            {
                return Problem("Entity set 'StudentAPIContext.Grades'  is null.");
            }
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
            }
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool GradeExists(int id)
        {
          return (_context.Grades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
