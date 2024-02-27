using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGolfScorecardApp.Data;
using MvcGolfScorecardApp.Models;
using MvcGolfScorecardApp.Services;

namespace MvcGolfScorecardApp.Controllers
{
    public class ScorecardController : Controller
    {
        private readonly MvcGolfScorecardAppContext _context;
        //private readonly HandicapService _handicapService;


        public ScorecardController(MvcGolfScorecardAppContext context, HandicapService handicapService)
        {
            _context = context;
            //_handicapService = handicapService;
        }

        // GET: Scorecard
        public async Task<IActionResult> Index()
        {
            //var handicap = _handicapService.CalculateHandicap();
            var scorecard = _context.Scorecard
           .Include(s => s.Course)
           .AsNoTracking();
            return View(await scorecard.ToListAsync());
            /*
                return _context.Scorecard != null ? 
                          View(await _context.Scorecard.ToListAsync()) :
                          Problem("Entity set 'MvcGolfScorecardAppContext.Scorecard'  is null.");
            */
        }

        // GET: Scorecard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Scorecard == null)
            {
                return NotFound();
            }

            var scorecard = await _context.Scorecard
                .Include(s => s.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scorecard == null)
            {
                return NotFound();
            }

            return View(scorecard);
        }

        // GET: Scorecard/Create
        public IActionResult Create(int courseID = 0)
        {
            PopulateCoursesDropDownList();
            return View();
        }

        // POST: Scorecard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatePlayed,HoleOne,HoleTwo,HoleThree,HoleFour,HoleFive,HoleSix,HoleSeven,HoleEight,HoleNine,HoleTen,HoleEleven,HoleTwelve,HoleThirteen,HoleFourteen,HoleFifteen,HoleSixteen,HoleSeventeen,HoleEighteen, CourseId")] Scorecard scorecard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scorecard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //Their was an error so repopulate ddl and return to created view
            PopulateCoursesDropDownList(scorecard.CourseId);
            return View(scorecard);
        }


        public ActionResult GetCourseInfo(int selectedCourse)
        {
            var CourseData = (from c in _context.Course
                              where c.CourseId == selectedCourse
                              select new{c.HoleOne, c.HoleTwo, c.HoleThree, c.HoleFour, c.HoleFive, c.HoleSix, c.HoleSeven, c.HoleEight, c.HoleNine,
                              c.HoleTen, c.HoleEleven, c.HoleTwelve, c.HoleThirteen, c.HoleFourteen, c.HoleFifteen, c.HoleSixteen, c.HoleSeventeen, c.HoleEighteen}).FirstOrDefault();

            return Json(CourseData);
        }

        private void PopulateCoursesDropDownList(object selectedCourse = null)
        {
            var coursesQuery = from c in _context.Course
                                   orderby c.CourseName
                                   select c;
            ViewBag.CourseID = new SelectList(coursesQuery.AsNoTracking(), "CourseId", "CourseName", selectedCourse);
        }


        // GET: Scorecard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Scorecard == null)
            {
                return NotFound();
            }

            var scorecard = await _context.Scorecard.FindAsync(id);
            if (scorecard == null)
            {
                return NotFound();
            }
            PopulateCoursesDropDownList(scorecard.CourseId);
            return View(scorecard);
        }

        // POST: Scorecard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scorecardToUpdate = await _context.Scorecard
                .FirstOrDefaultAsync(c => c.Id == id);

            if (await TryUpdateModelAsync<Scorecard>(scorecardToUpdate,
                "",
                s => s.DatePlayed, s => s.CourseId, s => s.HoleOne, s => s.HoleTwo, s => s.HoleThree, s => s.HoleFour, s => s.HoleFive,
                s => s.HoleSix, s => s.HoleSeven, s => s.HoleEight, s => s.HoleNine, s => s.HoleTen, s => s.HoleEleven, s => s.HoleTwelve,
                s => s.HoleThirteen, s => s.HoleFourteen, s => s.HoleFifteen, s => s.HoleSixteen, s => s.HoleSeventeen, s => s.HoleEighteen))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateCoursesDropDownList(scorecardToUpdate.CourseId);
            return View(scorecardToUpdate);
        }

        // GET: Scorecard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Scorecard == null)
            {
                return NotFound();
            }

            var scorecard = await _context.Scorecard.FindAsync(id);

            if (scorecard == null)
            {
                return NotFound();
            }

            PopulateCoursesDropDownList(scorecard.CourseId);
            return View(scorecard);
        }

        // POST: Scorecard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Scorecard == null)
            {
                return Problem("Entity set 'MvcGolfScorecardAppContext.Scorecard'  is null.");
            }
            var scorecard = await _context.Scorecard.FindAsync(id);
            if (scorecard != null)
            {
                _context.Scorecard.Remove(scorecard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScorecardExists(int id)
        {
          return (_context.Scorecard?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
