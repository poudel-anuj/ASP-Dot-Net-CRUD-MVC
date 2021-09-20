

using Customer.Repository;
using Department.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Department.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentRepository depart = new DepartmentRepository();

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblDepartment dep)
        {
            depart.Insert(dep);
            ViewBag.message = "Data Added successfully";
            return RedirectToAction("GetDepartmentList");
            ;
        }

        public ActionResult GetDepartmentList()
        {

            var data = depart.GetDepartmentList();
            return View(data);
        }

        public ActionResult GetById(int id)
        {
            var data = depart.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            depart.Delete(id);
            return RedirectToAction("GetDepartmentList");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var data = depart.GetById(id);
            return View(data);

        }

        [HttpPost]
        public ActionResult Edit(tblDepartment cus)
        {
            depart.Update(cus);
            ViewBag.message = "Data Updated successfully";
            return RedirectToAction("GetDepartmentList");
        }

    }
}