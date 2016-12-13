using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStumblerFinal.Models
{
    public class YahooFinance //contains the method that parses and formats the csv data into a list of stock objects
    {
        public static List<Stock> Parse(string csvData)
        {
            List<Stock> stockInfo = new List<Stock>();// creating an empty list of stock objects
            string[] rows = csvData.Replace("\r", "").Split('\n');
            int i = 0;
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');
                // detect the problem when name is split by comma(,Inc.)
                if (cols.Length == 9)
                {
                    i += 1;
                    cols[1] += ", Inc.";
                }
                Stock Company = new Stock();
                Company.Symbol = cols[0];
                Company.Name = cols[1];
                try
                {
                    Company.Bid = Convert.ToDecimal(cols[2 + i]);
                }
                catch 
                {

                    Company.Bid = decimal.Zero;
                }
                
                

                try
                {
                    Company.Ask = Convert.ToDecimal(cols[3 + i]);
                }
                catch
                {

                    Company.Ask = decimal.Zero;
                }
               

                try
                {
                    Company.perChange = Convert.ToDecimal(cols[4 + i]);
                   
                }
                catch
                {

                    Company.perChange = decimal.Zero;
                }

                

                try
                {
                    Company.FiftyTwoRange = Convert.ToDecimal(cols[5 + i]);
                }
                catch
                {

                    Company.FiftyTwoRange = decimal.Zero;
                }

                

                try
                {
                    Company.OneYrTarg = Convert.ToDecimal(cols[6 + i]);

                }
                catch
                {

                    Company.OneYrTarg = decimal.Zero;
                }

                try
                {
                    Company.peRatio = Convert.ToDecimal(cols[6 + i]);

                }
                catch
                {

                    Company.peRatio = decimal.Zero;
                }


                stockInfo.Add(Company);

            }

            return stockInfo;
        }


    }
}