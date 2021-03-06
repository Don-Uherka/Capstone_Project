﻿using System;
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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Event.Include(e => e.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = _context.EventParticipants.Include(e => e.Participant.Id).FirstOrDefault(m => m.Id == id);
                
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate,Address1,Address2,City,State,ZipCode,Country,Latitude,Longitude,ParticipantId")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", events.ParticipantId);
            return View(events);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", events.ParticipantId);
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate,Address1,Address2,City,State,ZipCode,Country,Latitude,Longitude,ParticipantId")] Events events)
        {
            if (id != events.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(events.Id))
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
            //ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", events.ParticipantId);
            return View(events);
        }

        // GET: Events/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = _context.Event.Include(e => e).FirstOrDefault(m => m.Id == id);
            
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Event.FindAsync(id);
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
