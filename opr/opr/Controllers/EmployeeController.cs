using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opr.Models;

namespace opr.Controllers
{
    public class EmployeeController : Controller
    {
        opr.Models.OprEntities db = new Models.OprEntities();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
         emp = db.Employees.ToList();
            return View(emp);
        }
        public List<string> Listgender()
        {
            return new List<string> {"Male","Female" };
        }
        //Add new employee method
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
           
            db.Employees.Add(emp);
            db.SaveChanges();
            return View();
        }
    }
}