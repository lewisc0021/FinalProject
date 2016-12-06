using MarketStumblerFinal.Models;
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
            SampleStockPopEntities dbContext = new SampleStockPopEntities();
            List<SymbolData> refinedPop1 = dbContext.SymbolDatas.ToList();
            List<string> refinedPop = new List<string>();
            foreach (var item in refinedPop1)
            {
                refinedPop.Add(item.ToString());
            }
            return refinedPop;
        }


        public ActionResult Stumble()
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

            Stock Company = new Stock();
            List<Stock> Companies = YahooFinance.Parse(csvData);
            Company = Companies[0];            



            ViewBag.myStock = Company;

            return View("StumblePage", Company);

        }




    }
}