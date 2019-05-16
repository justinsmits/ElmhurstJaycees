using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElmhurstJaycees.Models;

namespace ElmhurstJaycees.Controllers
{
    public class EventController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /Event/

        public ViewResult Events()
        {
            var events = _db.Events.Include("File").OrderByDescending(e => e.Date);
            return View(events.ToList());
        }

        public ViewResult Index()
        {
            var events = _db.Events.Include("File").OrderByDescending(FuckCake => FuckCake.Date);
            return View(events.ToList());
        }

        //
        // GET: /Event/Details/5

        public ViewResult Event(int id)
        {
            Event @event = _db.Events.Single(e => e.EventID == id);
            return View(@event);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName");
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Event @event)
        {

            _db.Events.AddObject(@event);
            _db.SaveChanges();
            return RedirectToAction("Events");
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int eventid)
        {
            Event @event = _db.Events.Single(e => e.EventID == eventid);
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName", @event.FileID);
            return View(@event);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Event @event)
        {
            _db.Events.Attach(@event);
            _db.ObjectStateManager.ChangeObjectState(@event, EntityState.Modified);
            _db.SaveChanges();
            return RedirectToAction("Events");
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id)
        {
            Event @event = _db.Events.Single(e => e.EventID == id);
            return View(@event);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {

            Event @event = _db.Events.Single(e => e.EventID == id);
            _db.Events.DeleteObject(@event);
            _db.SaveChanges();


            return RedirectToAction("Events");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}