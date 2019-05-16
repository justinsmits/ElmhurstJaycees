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
    public class MinuteController : Controller
    {
        private ElmhurstJayceesEntities db = new ElmhurstJayceesEntities();

        //
        // GET: /Minute/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Minutes.OrderByDescending(m => m.MeetingDate).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Minute/Details/5

        public ViewResult Details(int id)
        {
            Minute minute = db.Minutes.Single(m => m.Id == id);
            return View(minute);
        }

        //
        // GET: /Minute/Create

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //
        // POST: /Minute/Create

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(Minute minute)
        {
            db.Minutes.AddObject(minute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Minute/Edit/5

        public ActionResult Edit(int id)
        {
            Minute minute = db.Minutes.Single(m => m.Id == id);
            return View(minute);
        }

        //
        // POST: /Minute/Edit/5

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Minute minute)
        {
            db.Minutes.Attach(minute);
            db.ObjectStateManager.ChangeObjectState(minute, EntityState.Modified);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Minute/Delete/5

        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Minute minute = db.Minutes.Single(m => m.Id == id);
                return View(minute);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // POST: /Minute/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {
            Minute minute = db.Minutes.Single(m => m.Id == id);
            db.Minutes.DeleteObject(minute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}