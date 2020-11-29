using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capstone_Project.Data;
using Capstone_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Project.Controllers
{
    [Authorize(Roles = "Participant")]
    public class ParticipantController : Controller
    {
        public ApplicationDbContext db;
        public ParticipantController(ApplicationDbContext db)
        {
            this.db = db;
        }
        // GET: ParticipantController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participant = db.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
            if (participant == null)
            {
                return RedirectToAction("Create");
            }
            return View(participant);
        }

        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            var participantDetails = db.Participant.Find(id);
            return View(participantDetails);
        }

        // GET: ParticipantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant participant)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                participant.IdentityUserId = userId;
                db.Participant.Add(participant);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Edit/5
        public ActionResult Edit(int id)
        {
            var participantEdit = db.Participant.Find(id);
            return View(participantEdit);
        }

        // POST: ParticipantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Participant participant)
        {
            try
            {
                db.Participant.Update(participant);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Delete/5
        public ActionResult Delete(int id)
        {
            var participantDelete = db.Participant.Find(id);
            return View(participantDelete);
        }

        // POST: ParticipantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Participant participant)
        {
            try
            {
                db.Participant.Remove(participant);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //Get
        public ActionResult CreateEvent()
        {

            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(Events events)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var participant = db.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
                //Find logged in Participant and add their Id to this Event object
                //What properties of the 'Event' will be set by the user on the view,
                //and which properties need to be hardcoded here?
                //hardcoded properties will be lat and long
                db.Event.Add(events);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EventDetails(int id)
        {
            var EventDetail = db.Event.Find(id);
            return View(EventDetail);
        }
        public ActionResult CreatePost()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var participant = db.Participant.Where(p => p.IdentityUserId == userId).FirstOrDefault();
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PostDetails(int id)
        {
            var PostDetail = db.Posts.Find(id);
            return View(PostDetail);
        }
    }
}
