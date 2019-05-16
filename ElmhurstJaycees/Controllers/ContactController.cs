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
    public class ContactController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        //
        // GET: /Contact/

        public ViewResult Index()
        {
            ViewBag.Events = _db.Events.Where(x => x.DisplayStartDate < DateTime.Now && x.DisplayEndDate > DateTime.Now).OrderBy(x => x.Date);
            var contacts = _db.Contacts.Include("File");
            var contactCount = contacts.Count();
            ViewBag.ContactCount = contactCount;
            return View((contactCount > 0) ? contacts.Single() : null);
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            Contact contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName");
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Contact contact)
        {
            _db.Contacts.AddObject(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id)
        {
            Contact contact = _db.Contacts.Single(c => c.Id == id);
            ViewBag.FileID = new SelectList(_db.Files, "FileID", "FileName", contact.FileID);
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Contact contact)
        {
            _db.Contacts.Attach(contact);
            _db.ObjectStateManager.ChangeObjectState(contact, EntityState.Modified);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id)
        {
            Contact contact = _db.Contacts.Single(c => c.Id == id);
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {

            Contact contact = _db.Contacts.Single(c => c.Id == id);
            _db.Contacts.DeleteObject(contact);
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