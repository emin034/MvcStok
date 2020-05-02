using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{

    public class CustomerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Customer
        public ActionResult Index(string par)
        {
           var customer = from c in db.Tbl_Customers select c;

            if (!string.IsNullOrEmpty(par))
            {
                customer= customer.Where(x => x.Name.Contains(par));
            }
            return View(customer.ToList());
            //var customer = db.Tbl_Customers.ToList();
            //return View(customer);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(Tbl_Customers par1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Tbl_Customers.Add(par1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var customer = db.Tbl_Customers.Find(id);
            db.Tbl_Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var custmr = db.Tbl_Customers.Find(id);

            return View("GetCustomer", custmr);
        }
        public ActionResult Update(Tbl_Customers custm)
        {
            var customer = db.Tbl_Customers.Find(custm.ID);
            customer.Name = custm.Name;
            customer.Surname = custm.Surname;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}