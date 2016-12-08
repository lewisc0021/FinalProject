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
            SampleStockPopEntities dbContext = new SampleStockPopEntities();
            UserPreference preference = dbContext.UserPreferences.Find("001");//will find userID..should be dynamic

            preference.Tech = (bool)chosenPreferences["Tech"];
            preference.Consumer = (bool)chosenPreferences["Consumer"];
            preference.Finance = (bool)chosenPreferences["Finance"];
            preference.Manufact = (bool)chosenPreferences["Manufact"];
            preference.Educ = (bool)chosenPreferences["Educ"];
            preference.Transport = (bool)chosenPreferences["Transport"];
            preference.Auto = (bool)chosenPreferences["Auto"];
            dbContext.SaveChanges();
            return View();
        }





        //This is refined database - it creates a list of stock symbols that coorrespond to user preference, industry selections
        public List<string> refineDataBase()
        {
            SampleStockPopEntities dbContext = new SampleStockPopEntities();
            List<SymbolData> allStocks = dbContext.SymbolDatas.ToList();
            List<string> userSymbols = new List<string>();

            UserPreference preference = dbContext.UserPreferences.Find("001");

            if (preference.Auto == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Auto") // have to match the exact industry name here
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Transport == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Transport")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Manufact == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Manufact")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Consumer == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Consumer")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Educ == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Educ")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Finance == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Finance")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Tech == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry == "Tech")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//
            //return RedirectToAction("StumblePage", "Results", userSymbols);
            return userSymbols;
        }




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
