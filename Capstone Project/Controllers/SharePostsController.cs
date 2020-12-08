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
    public class SharePostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharePostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SharePosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SharePosts.Include(s => s.Participant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SharePosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharePost = await _context.SharePosts
                .Include(s => s.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sharePost == null)
            {
                return NotFound();
            }

            return View(sharePost);
        }

        // GET: SharePosts/Create
        public IActionResult Create()
        {
            ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id");
            return View();
        }

        // POST: SharePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anonymous,Content,ParticipantId")] SharePost sharePost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sharePost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", sharePost.ParticipantId);
            return View(sharePost);
        }

        // GET: SharePosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharePost = await _context.SharePosts.FindAsync(id);
            if (sharePost == null)
            {
                return NotFound();
            }
            ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", sharePost.ParticipantId);
            return View(sharePost);
        }

        // POST: SharePosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anonymous,Content,ParticipantId")] SharePost sharePost)
        {
            if (id != sharePost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sharePost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SharePostExists(sharePost.Id))
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
            ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Id", sharePost.ParticipantId);
            return View(sharePost);
        }

        // GET: SharePosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharePost = await _context.SharePosts
                .Include(s => s.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sharePost == null)
            {
                return NotFound();
            }

            return View(sharePost);
        }

        // POST: SharePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sharePost = await _context.SharePosts.FindAsync(id);
            _context.SharePosts.Remove(sharePost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SharePostExists(int id)
        {
            return _context.SharePosts.Any(e => e.Id == id);
        }
    }
}
