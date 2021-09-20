
using Customer.Models;
using Customer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class CustomerController : Controller
    {

        CustomerRepository custom = new CustomerRepository();
        DepartmentRepository depart = new DepartmentRepository();

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            //for join
            var data = depart.GetDepartmentList();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult Index(customer cus)
        {
            custom.Insert(cus);
            ViewBag.message = "Data Added successfully";
            return RedirectToAction("GetCustomerList");
            ;
        }

        [HttpGet]
        public ActionResult GetCustomerList()
        {
            //to convert date into string format
            //var data = custom.GetCustomerList().Select(p => new
            //{
            //    entrydate = p.entrydate.ToString(),
            //    departName = p.departName,
            //    cusName = p.cusName,
            //    cusAddress = p.cusAddress,
            //    cusEmail = p.cusEmail,
            //}).ToList();

            var data = custom.GetCustomerList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCustomerById(int id)
        {
            var data = custom.GetById(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int delId)
        {
             custom.Delete(delId);
            //return RedirectToAction("GetCustomerList");
            return Json(JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //for department
            var editData = depart.GetDepartmentList();
            ViewBag.data = editData;

            var data = custom.GetById(id);
            return View(data);

        }

        [HttpPost]
        public ActionResult Edit(customer cus)
        {
            custom.Update(cus);
            ViewBag.message = "Data Updated successfully";
            return RedirectToAction("GetCustomerList");
        }
        [HttpPost]
        public JsonResult InsertCustomer(customer cum)
        {
            custom.Insert(cum);
            return Json("Sucess");
        }

        
       

    }
}