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
            ViewBag.Founder = new SelectList(_context.Participant, "Name", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("Founder,Id,Name,Description,StartDate,EndDate,Address1,Address2,City,State,ZipCode,Country,Latitude,Longitude")] Events events)
        {
            
            //Get Id from logged in user to use as ParticipantId of the created Event
            //Get rid of ViewData ParticiapntID select list
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var participant = _context.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            
          
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(IndexEvents));
            }
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", events.ParticipantId);
            return View(events);
        }
        //GET: Events
        public async Task<IActionResult> IndexEvents()
        {
            var applicationDbContext = _context.Event.Include(e => e);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult JoinEvent(int id)
        {
            EventParticipants eventParticipants = new EventParticipants();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            eventParticipants.EventId = id;
            var participant = _context.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            var eventcheck = _context.EventParticipants.Where(e => e.ParticipantId == participant.Id && e.EventId == id).FirstOrDefault();
            eventParticipants.ParticipantId = participant.Id;
            if(eventcheck == null)
            {
                eventParticipants.EventId = id;
                eventParticipants.ParticipantId = participant.Id;
            }
            else
            {
                eventParticipants = eventcheck;
            }
            //eventParticipants.Id = id;
            _context.Update(eventParticipants);
            _context.SaveChanges();
            return RedirectToAction(nameof(IndexEvents));
        }
        public IActionResult MyEvents()
        {
            var joinEvent = from s in _context.Event
                                        join st in _context.EventParticipants on s.Id equals st.EventId into st2
                                        from st in st2.DefaultIfEmpty()
                                        select new ParticipantEventAttendanceVM { EventsVM = s, EventParticipantsVM = st };
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participant = _context.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            var result = joinEvent.Where(e => e.EventParticipantsVM.ParticipantId == participant.Id);
                 
            return View(result);
        }
        public IActionResult FavoriteEvent(int id)
        {
            EventParticipants eventParticipants = new EventParticipants();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            //var participant = _context.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            //eventParticipants.ParticipantId = participant.Id;
            var isfavorite = _context.EventParticipants.Where(e => e.Id == id).FirstOrDefault();
            //eventParticipants.EventId = id;
            eventParticipants = isfavorite;
            if (isfavorite.Favorite)
            {
                eventParticipants.Favorite = false;
            }
            else
            {
                eventParticipants.Favorite = true;
            }
            //need to check database and delete old and replace with new "checked"
            
            _context.Update(eventParticipants);
            _context.SaveChanges();
            return RedirectToAction(nameof(MyEvents));
        }
    }
}
