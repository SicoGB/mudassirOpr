using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    public class DesignationController : Controller
    {
        OprEntities db = new OprEntities();
        // GET: Designation
        public ActionResult Index()
        {
            List<Designation> des_tbl= new List<Designation>();
            des_tbl = db.Designations.ToList();
            return View(des_tbl);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Designation des)
        {
            db.Designations.Add(des);
            db.SaveChanges();
            return View();
        }
    }
}