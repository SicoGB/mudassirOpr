using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    public class AuthorController : Controller
    {
        OprEntities db = new OprEntities();
        // GET: Author
        public ActionResult Index()
        {
            List<Author> au_tbl = new List<Author>();
            au_tbl = db.Authors.ToList();
            return View(au_tbl);
        }
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.Name;
            ViewBag.entrydate = DateTime.Now;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author sub)
        {

            var select = db.Authors.Select(s => new { s.Id }).ToList();
            SelectList list = new SelectList(select, "Id","Author_Name");
            ViewBag.dataForDropDown =list;

            db.Authors.Add(sub);
            db.SaveChanges();
            return View();
        }
        public ActionResult Update(int id)
        {

            var schl = db.Authors.Where(s => s.Id == id).FirstOrDefault();
            if (db == null)
            {
                return RedirectToAction("Index");
            }
            return View(schl);
        }
        [HttpPost]
        public ActionResult Update(Author sub_data)
        {

            db.Entry(sub_data).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { }
            ModelState.AddModelError("", "Unable to update in subject table. ");
            return View(sub_data);
        }
        public ActionResult Delete(int id)
        {
            Author cl = db.Authors.Find(id);
           
            db.Authors.Remove(cl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}