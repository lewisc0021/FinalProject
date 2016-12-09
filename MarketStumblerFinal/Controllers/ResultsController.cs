﻿using MarketStumblerFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MarketStumblerFinal.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {
            return View();
        }


        private static List<string> GetSymbols()
        {
            StockUniverseEntities dbContext = new StockUniverseEntities();
            List<SymbolData> allStocks = dbContext.SymbolDatas.ToList();
            List<string> userSymbols = new List<string>();

            UserPreference preference = dbContext.UserPreferences.Find("002");

            if (preference.Automotive == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Automotive") // have to match the exact industry name here
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Transportation == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Transportation")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Manufacturing == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Manufacturing")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Consumer == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Consumer")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Food == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Food")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Finance == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Finance")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Technology == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Technology")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Services == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Services")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.PreciousMetals == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "PreciousMetals")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//

            if (preference.Medical == true)
            {//
                foreach (var item in allStocks)
                {
                    if (item.Industry.Trim() == "Medical")
                    {
                        userSymbols.Add(item.Symbol);
                    }
                }
            }//


            //return RedirectToAction("StumblePage", "Results", userSymbols);


            //foreach (var item in allStocks)
            //{
            //    userSymbols.Add(item.Symbol);
            //}
            return userSymbols;
        }


        public ActionResult StumblePage()
        {
            List<string> refinedPop = GetSymbols();
            string csvData;
            Random r1 = new Random(DateTime.Now.Millisecond);
            int chosenIndex = r1.Next(0, refinedPop.Count - 1);
            string Symbol = refinedPop[chosenIndex];
            string URL = "http://finance.yahoo.com/d/quotes.csv?s=" + Symbol + "&f=snbaopl1";

            using (WebClient web = new WebClient())
            {
                csvData = web.DownloadString(URL);

            }

            List<Stock> Companies = YahooFinance.Parse(csvData);
            Stock Company = Companies.ElementAt(0);
            //Stock Company = new Stock();
            //ViewBag.myStocks = Companies;
            return View("StumblePage", Company);
        }

        //private static decimal calcBeta(Stock Company)
        //{

        //}



    }//END
}