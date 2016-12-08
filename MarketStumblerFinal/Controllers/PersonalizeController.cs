///Personalize Controller

using MarketStumblerFinal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketStumblerFinal.Controllers
{
    public class PersonalizeController : Controller
    {
        // GET: Personalize
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(List<string> Industries)
        {
            Hashtable chosenPreferences = new Hashtable();
            //this is not the best way to do this-if I could get back a false by default(true if checked) that would be ideal
            chosenPreferences["Auto"] = false;
            chosenPreferences["Finance"] = false;
            chosenPreferences["Transport"] = false;
            chosenPreferences["Tech"] = false;
            chosenPreferences["Consumer"] = false;
            chosenPreferences["Manufact"] = false;
            chosenPreferences["Educ"] = false;

            if (Industries != null)
            {
                //this is where the update to the hashtable happens
                for (int i = 0; i < Industries.Count; i++)
                {
                    string[] industryIndex = Industries[i].Split('-');
                    chosenPreferences[industryIndex[0]] = Convert.ToBoolean(industryIndex[1]);
                }
            }
            //now I need to create a db object to update the userpreference table
            StockUniverseEntities dbContext = new StockUniverseEntities();
            UserPreference preference = dbContext.UserPreferences.Find("002");//will find userID..should be dynamic

            preference.Tech = (bool)chosenPreferences["Tech"];
            preference.Consumer = (bool)chosenPreferences["Consumer"];
            preference.Finance = (bool)chosenPreferences["Finance"];
            preference.Manufact = (bool)chosenPreferences["Manufact"];
            preference.Educ = (bool)chosenPreferences["Educ"];
            preference.Transport = (bool)chosenPreferences["Transport"];
            preference.Auto = (bool)chosenPreferences["Auto"];
            dbContext.SaveChanges();
            return RedirectToAction("StumblePage", "Results");
        }





        //This is refined database - it creates a list of stock symbols that coorrespond to user preference, industry selections
        




        //[HttpGet]
        //public ActionResult Index(string industryChoice)
        //{
        //    SampleStockPopEntities dbContext = new SampleStockPopEntities();
        //    List<SymbolData> refinedPop1 = dbContext.SymbolDatas.ToList();

        //    //save choice to data base
        //    return RedirectToAction("Index","Home");

        //}


    }
}
