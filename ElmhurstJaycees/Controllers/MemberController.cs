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
    public class MemberController : Controller
    {
        private ElmhurstJayceesEntities db = new ElmhurstJayceesEntities();

        //
        // GET: /Member/

        public ViewResult Index()
        {
            var member = db.Members.Include("Boards");
            return View(member.ToList());
        }

        //
        // GET: /Member/Details/5

        public ViewResult Details(int id)
        {
            Member member = db.Members.Single(m => m.MemberID == id);
            return View(member);
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Boards, "MemberID", "Title");
            return View();
        } 

        //
        // POST: /Member/Create

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(FormCollection collection, Member member)
        {
           
            String pass1 = collection["_password"];
            String pass2 = collection["_confirmPassword"];

            if (!(pass1.Equals(pass2)))
            {
                ModelState.AddModelError(String.Empty, "Passwords do not match");
                return View(member);
            }
            if (String.IsNullOrWhiteSpace(pass1))
            {
                ModelState.AddModelError(String.Empty, "Passwords cannot be empty");
                return View(member);
            }
            if (ModelState.IsValid && pass1.Equals(pass2))
            {
                Byte[] salt = BrickHouse.Utility.Cryptography.CreateSaltBytes();
                String hash = BrickHouse.Utility.Cryptography.ComputeHash(pass1, BrickHouse.Utility.Cryptography.HashAlgorithm.SHA1, salt);
                member.Salt = Convert.ToBase64String(salt);
                member.Hash = hash;
                db.Members.AddObject(member);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.MemberID = new SelectList(db.Boards, "MemberID", "Title", member.MemberID);
            return View(member);
        }
        
        //
        // GET: /Member/Edit/5
 
        public ActionResult Edit(int id)
        {
            Member member = db.Members.Single(m => m.MemberID == id);
            ViewBag.MemberID = new SelectList(db.Boards, "MemberID", "Title", member.MemberID);
            return View(member);
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(FormCollection collection, Member member)
        {
            String pass1 = collection["_password"];
            String pass2 = collection["_confirmPassword"];
            if (!(pass1.Equals(pass2)))
            {
                ModelState.AddModelError(String.Empty, "Passwords do not match");
                return View(member);
            }
            if (ModelState.IsValid)
            {
                if (!(String.IsNullOrWhiteSpace(pass1)))
                {
                    Byte[] salt = BrickHouse.Utility.Cryptography.CreateSaltBytes();
                    String hash = BrickHouse.Utility.Cryptography.ComputeHash(pass1, BrickHouse.Utility.Cryptography.HashAlgorithm.SHA1, salt);
                    member.Salt = Convert.ToBase64String(salt);
                    member.Hash = hash;
                }
                db.Members.Attach(member);
                db.ObjectStateManager.ChangeObjectState(member, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Boards, "MemberID", "Title", member.MemberID);
            return View(member);
        }

        //
        // GET: /Member/Delete/5
 
        public ActionResult Delete(int id)
        {
            Member member = db.Members.Single(m => m.MemberID == id);
            return View(member);
        }

        //
        // POST: /Member/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        public ActionResult DeleteConfirmed(int id)
        {            
            Member member = db.Members.Single(m => m.MemberID == id);
            db.Members.DeleteObject(member);
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