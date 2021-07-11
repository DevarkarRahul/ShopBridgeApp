using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    [HandleError(View = "Error")]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var products = APIHelper.APIHelper.Get();
            return View(products);
        }

        public ActionResult Products()
        {
            var products = APIHelper.APIHelper.Get();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (APIHelper.APIHelper.Post(product))
                return RedirectToAction("Index");
            else
                return View();
        }

        public ActionResult Edit(int id)
        {
            var product = APIHelper.APIHelper.Get(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (APIHelper.APIHelper.Put(product))
                return RedirectToAction("Index");
            else
                return View();
        }

        public ActionResult Details(int id)
        {
            var product = APIHelper.APIHelper.Get(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            if (APIHelper.APIHelper.Delete(id))
                return RedirectToAction("Index");
            else
                return Content("Error while deleting record");

        }
    }
}