using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(Tbl_Sales sl)
        {
            db.Tbl_Sales.Add(sl);
            db.SaveChanges();
            return View("Index");
        }

    }
}