using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone_Project.Data;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers
{
    public class EventParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventParticipants
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventParticipants.ToListAsync());
        }

        // GET: EventParticipants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipants = await _context.EventParticipants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventParticipants == null)
            {
                return NotFound();
            }

            return View(eventParticipants);
        }

        // GET: EventParticipants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventParticipants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Favorite,EventId,ParticipantId")] EventParticipants eventParticipants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventParticipants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventParticipants);
        }

        // GET: EventParticipants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipants = await _context.EventParticipants.FindAsync(id);
            if (eventParticipants == null)
            {
                return NotFound();
            }
            return View(eventParticipants);
        }

        // POST: EventParticipants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Favorite,EventId,ParticipantId")] EventParticipants eventParticipants)
        {
            if (id != eventParticipants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventParticipants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventParticipantsExists(eventParticipants.Id))
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
            return View(eventParticipants);
        }

        // GET: EventParticipants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipants = await _context.EventParticipants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventParticipants == null)
            {
                return NotFound();
            }

            return View(eventParticipants);
        }

        // POST: EventParticipants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventParticipants = await _context.EventParticipants.FindAsync(id);
            _context.EventParticipants.Remove(eventParticipants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventParticipantsExists(int id)
        {
            return _context.EventParticipants.Any(e => e.Id == id);
        }
    }
}
