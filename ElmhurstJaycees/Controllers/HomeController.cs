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
    public class HomeController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /Home/

        public ViewResult Index()
        {
            ViewBag.Events = _db.Events.Where(x => x.DisplayStartDate < DateTime.Now && x.DisplayEndDate > DateTime.Now).OrderBy(x => x.Date);
            var home = _db.Homes.Include("File").Single();
            return View(home);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            ViewBag.FileId = new SelectList(_db.Files, "FileID", "FileName");
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Home home)
        {
            if (ModelState.IsValid)
            {
                _db.Homes.AddObject(home);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FileId = new SelectList(_db.Files, "FileID", "FileName", home.FileId);
            return View(home);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            Home home = _db.Homes.Single(h => h.Id == id);
            ViewBag.FileId = new SelectList(_db.Files, "FileID", "FileName", home.FileId);
            return View(home);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Home home)
        {

            _db.Homes.Attach(home);
            _db.ObjectStateManager.ChangeObjectState(home, EntityState.Modified);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            Home home = _db.Homes.Single(h => h.Id == id);
            return View(home);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {
            Home home = _db.Homes.Single(h => h.Id == id);
            _db.Homes.DeleteObject(home);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}