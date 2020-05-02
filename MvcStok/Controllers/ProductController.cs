using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
             
            var products = db.Tbl_Products.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> prodList = (from i in db.Tbl_Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.ID.ToString()

                                             }).ToList();
            ViewBag.dgr = prodList;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Tbl_Products par1)
        {
            var ctgry = db.Tbl_Categories.Where(m => m.ID == par1.Tbl_Categories.ID).FirstOrDefault();
            par1.Tbl_Categories = ctgry;
            db.Tbl_Products.Add(par1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> prodList = (from i in db.Tbl_Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.ID.ToString()

                                             }).ToList();
            ViewBag.dgr = prodList;
            var product = db.Tbl_Products.Find(id);
            return View("GetProduct", product);
        }
        public ActionResult Update(Tbl_Products prod)
        {
            var product = db.Tbl_Products.Find(prod.ID);
            product.Marka = prod.Marka;
            product.Name = prod.Name;
            product.Price = prod.Price;
            product.Stok = prod.Stok;
            var ctgry = db.Tbl_Categories.Where(m => m.ID == prod.Tbl_Categories.ID).FirstOrDefault();
            product.Category = ctgry.ID;
            //product.Category = prod.Category;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Tbl_Products.Find(id);
            db.Tbl_Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}