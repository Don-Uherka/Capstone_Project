using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capstone_Project.Data;
using Capstone_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Project.Controllers
{
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
            var participant = db.Participants.Where(p => p.IdentityUserId == userId).SingleOrDefault();
            if(participant == null)
            {
                return RedirectToAction("Create");
            }
            return View(participant);
        }

        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            var participantDetails = db.Participants.Find(id);
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
                db.Participants.Add(participant);
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
            var participantEdit = db.Participants.Find(id);
            return View(participantEdit);
        }

        // POST: ParticipantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Participant participant)
        {
            try
            {
                db.Participants.Update(participant);
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
            var participantDelete = db.Participants.Find(id);
            return View(participantDelete);
        }

        // POST: ParticipantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Participant participant)
        {
            try
            {
                db.Participants.Remove(participant);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
