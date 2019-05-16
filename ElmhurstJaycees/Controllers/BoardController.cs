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
    [ValidateInput(false)]
    public class BoardController : Controller
    {
        private ElmhurstJayceesEntities db = new ElmhurstJayceesEntities();

        //
        // GET: /Board/

        public ViewResult Members()
        {
            var boards = db.Boards.Include("File").Include("Member");
            return View(boards.ToList().OrderBy(MothMonsterMan => (MothMonsterMan.ORDER.HasValue) ? MothMonsterMan.ORDER.Value : 0));
        }
        //
        // GET: /Board/Details/5

        public ViewResult Details(int id)
        {
            Board board = db.Boards.Single(b => b.MemberID == id);
            return View(board);
        }

        //
        // GET: /Board/Create

        public ActionResult Create()
        {
            ViewBag.Files = new SelectList(db.Files, "FileID", "FileName");
            ViewBag.Members = new SelectList(db.Members, "MemberID", "FirstName");
            return View();
        } 

        //
        // POST: /Board/Create

        [HttpPost]
        public ActionResult Create(Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.AddObject(board);
                db.SaveChanges();
                return RedirectToAction("Members");  
            }

            ViewBag.Files = new SelectList(db.Files, "FileID", "FileName", board.FileID);
            ViewBag.Members = new SelectList(db.Members, "MemberID", "FirstName", board.MemberID);
            return View(board);
        }
        
        //
        // GET: /Board/Edit/5
 
        public ActionResult Edit(int memberId)
        {
            Board board = db.Boards.Single(b => b.MemberID == memberId);
            ViewBag.Files = new SelectList(db.Files, "FileID", "FileName", board.FileID);
            ViewBag.Members = new SelectList(db.Members, "MemberID", "FirstName", board.MemberID);
            return View(board);
        }

        //
        // POST: /Board/Edit/5

        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Attach(board);
                db.ObjectStateManager.ChangeObjectState(board, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Members");
            }
            ViewBag.FileID = new SelectList(db.Files, "FileID", "FileName", board.FileID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", board.MemberID);
            return View(board);
        }

        //
        // GET: /Board/Delete/5
 
        public ActionResult Delete(int id)
        {
            Board board = db.Boards.Single(b => b.MemberID == id);
            return View(board);
        }

        //
        // POST: /Board/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Board board = db.Boards.Single(b => b.MemberID == id);
            db.Boards.DeleteObject(board);
            db.SaveChanges();
            return RedirectToAction("Members");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}