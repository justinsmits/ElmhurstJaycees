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
    public class FileController : Controller
    {
        private ElmhurstJayceesEntities db = new ElmhurstJayceesEntities();

        //
        // GET: /File/

        public ViewResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View(db.Files.ToList());
            }
            else
            {
                return View(db.Files.Where(f => (f.Form == true && f.Public == true)));
            }
        }

        //
        // GET: /File/Details/5

        public ViewResult Details(int id)
        {
            File file = db.Files.Single(f => f.FileID == id);
            return View(file);
        }

        //
        // GET: /File/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /File/Create

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Create(HttpPostedFileBase _file, String Title, Boolean Public, Boolean Form, Boolean Photo)
        {
            HttpPostedFileBase f1 = _file;
            File file = new File();
            try
            {
                if ((!(f1 == null)))
                {
                    var fileName = System.IO.Path.GetFileName(f1.FileName);
                    file.FileName = fileName;
                    file.Extension = System.IO.Path.GetExtension(f1.FileName).TrimEnd();
                    byte[] buffer = new byte[f1.ContentLength];
                    f1.InputStream.Read(buffer, 0, f1.ContentLength);
                    file.Length = f1.ContentLength;
                    file.FileData = buffer;
                    file.Title = Title;
                    file.Public = Public;
                    file.Form = Form;
                    file.Photo = Photo;
                    db.Files.AddObject(file);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Session["LastException"] = ex.ToString();
                return RedirectToAction("Error", "Default");
            }

            ViewBag.FileID = file.FileID;
            return View(file);
        }

        //
        // GET: /File/Edit/5

        public ActionResult Edit(int id)
        {
            File file = db.Files.Single(f => f.FileID == id);
            ViewBag.FileID = new SelectList(db.Boards, "MemberID", "Title", file.FileID);
            return View(file);
        }

        //
        // POST: /File/Edit/5

        [HttpPost]
        [CustomAttributes.AuthorizeUser]
        public ActionResult Edit(Int32 id, HttpPostedFileBase _file, String Title, Boolean Public, Boolean Form, Boolean Photo)
        {

            HttpPostedFileBase f1 = _file;
            ElmhurstJaycees.Models.File file = null;
            try
            {
                if ((!(id == -1)))
                {
                    file = db.Files.Where(f => f.FileID == id).Single();
                    if (!(f1 == null))
                    {
                        var fileName = System.IO.Path.GetFileName(f1.FileName);
                        file.FileName = fileName;
                        file.Extension = System.IO.Path.GetExtension(f1.FileName).TrimEnd();
                        byte[] buffer = new byte[f1.ContentLength];
                        f1.InputStream.Read(buffer, 0, f1.ContentLength);
                        file.Length = f1.ContentLength;
                        file.FileData = buffer;
                    }
                    
                    file.Title = Title;
                    file.Public = Public;
                    file.Form = Form;
                    file.Photo = Photo;
                    //db.Files.Attach(file);
                    db.Files.ApplyCurrentValues(file);
                    //db.ObjectStateManager.ChangeObjectState(file, EntityState.Modified);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Session["LastException"] = ex.ToString();
                return RedirectToAction("Error", "Default");
            }
            ViewBag.FileID = file.FileID;
            return View(file);

        }

        //
        // GET: /File/Delete/5

        public ActionResult Delete(int id)
        {
            File file = db.Files.Single(f => f.FileID == id);
            return View(file);
        }

        //
        // POST: /File/Delete/5

        [HttpPost, ActionName("Delete")]
        [CustomAttributes.AuthorizeUser]
        [HandleError()]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                File file = db.Files.Single(f => f.FileID == id);
                db.Files.DeleteObject(file);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Session["LastException"] = ex.ToString();
                return RedirectToAction("Error", "Default");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}