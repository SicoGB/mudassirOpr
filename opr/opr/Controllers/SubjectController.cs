using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using opr.Models;


namespace opr.Controllers
{
    
   
    public class SubjectController : Controller
    {
        OprEntities db = new OprEntities();
      
        // GET: Subject
        
        public ActionResult Index()
        {
            //Get currently logged on user name and system date
            ViewBag.UserId = User.Identity.Name;
            ViewBag.entrydate = DateTime.Now;

            //var userid = User.Identity.GetUserId();
            //  ViewBag.user = _userManager.Identity.GetUserId(HttpContext.User);
            List<Subject> sub_list = new List<Subject>();
            sub_list = db.Subjects.ToList();
            return View(sub_list);
       
        }
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.Name;
            ViewBag.entrydate = DateTime.Now;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Subject sub)
        {
           
            var select = db.Subjects.Select(s => new { s.Id}).ToList();
            SelectList list = new SelectList(select, "Id");
            ViewBag.dataForDropDown = select;

            db.Subjects.Add(sub);
            db.SaveChanges();
            return View();
        }
        public ActionResult Update(int id)
        {
            
            var schl = db.Subjects.Where(s => s.Id == id).FirstOrDefault();
            if (db == null)
            {
                return RedirectToAction("Index");
            }
            return View(schl);
        }
        [HttpPost]
        public ActionResult Update(Subject sub_data)
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
            Subject cl = db.Subjects.Find(id);
           db.Subjects.Remove(cl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsDelete(int id)
        {
            var data = db.Subjects.Select(s => s.Id == id).FirstOrDefault();
            if (db == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult IsDelete(Subject sub_da)
        {
            db.Entry(sub_da).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            { }
            ModelState.AddModelError("", "Unable to update subject");
            return View(db);

        }
    }
}