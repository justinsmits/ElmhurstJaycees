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
    public class PressController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /Press/

        public ViewResult Index()
        {
            var presses = _db.Presses.Include("File");
            return View(presses.ToList());
        }

        //
        // GET: /Press/Details/5

        public ViewResult Details(int id)
        {
            Press press = _db.Presses.Single(p => p.Id == id);
            return View(press);
        }

        //
        // GET: /Press/Create

        public ActionResult Create()
        {
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName");
            return View();
        }

        //
        // POST: /Press/Create

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Press press)
        {
            _db.Presses.AddObject(press);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Press/Edit/5

        public ActionResult Edit(int id)
        {
            Press press = _db.Presses.Single(p => p.Id == id);
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName", press.FileID);
            return View(press);
        }

        //
        // POST: /Press/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Press press)
        {
            _db.Presses.Attach(press);
            _db.ObjectStateManager.ChangeObjectState(press, EntityState.Modified);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Press/Delete/5

        public ActionResult Delete(int id)
        {
            Press press = _db.Presses.Single(p => p.Id == id);
            return View(press);
        }

        //
        // POST: /Press/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {
            Press press = _db.Presses.Single(p => p.Id == id);
            _db.Presses.DeleteObject(press);
            _db.SaveChanges();
            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}