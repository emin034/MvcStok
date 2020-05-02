using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            //var category = db.Tbl_Categories.ToList();
            var category = db.Tbl_Categories.ToList().ToPagedList(page,3);
            return View(category);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(Tbl_Categories par1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Tbl_Categories.Add(par1);
            db.SaveChanges();
            return View();
        }
       
        public ActionResult Delete(int id)
        {
          var category= db.Tbl_Categories.Find(id);
            db.Tbl_Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUpdate(int id)
        {
            var category = db.Tbl_Categories.Find(id);
            return View("GetUpdate",category);
        }
        public ActionResult Update(Tbl_Categories cat)
        {
            var category = db.Tbl_Categories.Find(cat.ID);
            category.Name = cat.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}