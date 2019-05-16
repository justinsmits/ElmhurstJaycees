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
    public class AboutController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /About/

        public ViewResult Index()
        {
            ViewBag.Events = _db.Events.Where(x => x.DisplayStartDate < DateTime.Now && x.DisplayEndDate > DateTime.Now).OrderBy(x => x.Date);
            return View(_db.Abouts.Single());
        }

        //
        // GET: /About/Details/5

        public ViewResult Details(int id)
        {
            About about = _db.Abouts.Single(a => a.Id == id);
            return View(about);
        }

        //
        // GET: /About/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /About/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                _db.Abouts.AddObject(about);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        //
        // GET: /About/Edit/5

        public ActionResult Edit(int id)
        {
            About about = _db.Abouts.Single(a => a.Id == id);
            return View(about);
        }

        //
        // POST: /About/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                _db.Abouts.Attach(about);
                _db.ObjectStateManager.ChangeObjectState(about, EntityState.Modified);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        //
        // GET: /About/Delete/5

        public ActionResult Delete(int id)
        {
            About about = _db.Abouts.Single(a => a.Id == id);
            return View(about);
        }

        //
        // POST: /About/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                About about = _db.Abouts.Single(a => a.Id == id);
                _db.Abouts.DeleteObject(about);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}