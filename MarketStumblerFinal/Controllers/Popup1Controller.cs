using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketStumblerFinal.Controllers
{
    public class Popup1Controller : Controller
    {
        // GET: Popup1
        public ActionResult Popup1(string Symbol)
        {
            ViewBag.Symbol = Symbol;
            return View();
        }
    }
}