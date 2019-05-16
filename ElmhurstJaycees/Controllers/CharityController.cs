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
    public class CharityController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /Charity/

        public ViewResult Index()
        {
            ViewBag.Events = _db.Events.Where(x => x.DisplayStartDate < DateTime.Now && x.DisplayEndDate > DateTime.Now).OrderBy(x => x.Date);
            var char1 = _db.Charities.Single();
            return View(char1);
        }

        //
        // GET: /Charity/Details/5

        public ViewResult Details(int id)
        {
            Charity charity = _db.Charities.Single(c => c.Id == id);
            return View(charity);
        }

        //
        // GET: /Charity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Charity/Create

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Charity charity)
        {
            if (ModelState.IsValid)
            {
                _db.Charities.AddObject(charity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charity);
        }

        //
        // GET: /Charity/Edit/5

        public ActionResult Edit(int id)
        {
            Charity charity = _db.Charities.Single(c => c.Id == id);
            return View(charity);
        }

        //
        // POST: /Charity/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Charity charity)
        {

            _db.Charities.Attach(charity);
            _db.ObjectStateManager.ChangeObjectState(charity, EntityState.Modified);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Charity/Delete/5

        public ActionResult Delete(int id)
        {
            Charity charity = _db.Charities.Single(c => c.Id == id);
            return View(charity);
        }

        //
        // POST: /Charity/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {
            Charity charity = _db.Charities.Single(c => c.Id == id);
            _db.Charities.DeleteObject(charity);
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