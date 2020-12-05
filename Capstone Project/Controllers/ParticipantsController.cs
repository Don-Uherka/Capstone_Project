using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone_Project.Data;
using Capstone_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Capstone_Project.Controllers
{
    [Authorize(Roles = "Participant")]
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Participants/Info
        public IActionResult Info()
        {
            
            return View();
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Participant.Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,LastName,Address1,Address2,City,State,ZipCode,Country,Log,Anonymous,IdentityUserId")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                participant.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Info));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", participant.IdentityUserId);
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", participant.IdentityUserId);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,LastName,Address1,Address2,City,State,ZipCode,Country,Log,Anonymous,IdentityUserId")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", participant.IdentityUserId);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participant.FindAsync(id);
            _context.Participant.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participant.Any(e => e.Id == id);
        }
        // GET: Events/Create
        public IActionResult CreateEvent()
        {
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("Id,Name,Description,StartDate,EndDate,Address1,Address2,City,State,ZipCode,Country,Latitude,Longitude,ParticipantId")] Events events)
        {
            //Get Id from logged in user to use as ParticipantId of the created Event
            //Get rid of ViewData ParticiapntID select list
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participant = _context.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            var Event = _context.Event;
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", events.ParticipantId);
            return View(events);
        }
        //GET: Events
        //public async Task<IActionResult> IndexEvents()
        //{
        //    var applicationDbContext = _context.Event.Include(e => e.Participant);
        //    return View(await applicationDbContext.ToListAsync());
        //}
    }
}
