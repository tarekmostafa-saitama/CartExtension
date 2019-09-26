using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartExtension.Persistence.Repositories;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Item model)
        {
            Cart i = new Cart();
            i.Add(model);
            return View();
        }
        public ActionResult Cart()
        {
            Cart i = new Cart();
            List<Item> result = i.GetCart().Cast<Item>().ToList();
            ViewBag.TotalCost = i.TotalPrice();
            return View(result);
        }
        public ActionResult DeleteFromCart(string itemId)
        {
            Cart i = new Cart();
            i.Delete(itemId);
            return RedirectToAction("Cart");
        }
        public ActionResult UpdateFromCart(Item model)
        {
            Cart i = new Cart();
            i.Update(model);
            return RedirectToAction("Cart");
        }
    }
}