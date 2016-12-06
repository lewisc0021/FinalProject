using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketStumblerFinal.Controllers
{
    public class PersonalizeController : Controller
    {
        // GET: Personalize
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string choice)
        {
            //save choice to data base
            return RedirectToAction("Index","Home");

        }


    }
}