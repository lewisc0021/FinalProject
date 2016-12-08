using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStumblerFinal.Models
{
    public class YahooFinance
    {
        public static List<Stock> Parse(string csvData)
        {
            List<Stock> stockInfo = new List<Stock>();
            string[] rows = csvData.Replace("\r", "").Split('\n');
            int i = 0;
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');
                // detect the problem 
                if (cols.Length == 8)
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
                    Company.Open = Convert.ToDecimal(cols[4 + i]);
                   
                }
                catch
                {

                    Company.Open = decimal.Zero;
                }

                

                try
                {
                    Company.PreviousClose = Convert.ToDecimal(cols[5 + i]);
                }
                catch
                {

                    Company.PreviousClose = decimal.Zero;
                }

                

                try
                {
                    Company.Last = Convert.ToDecimal(cols[6 + i]);

                }
                catch
                {

                    Company.Last = decimal.Zero;
                }

                

                stockInfo.Add(Company);

            }

            return stockInfo;
        }


    }
}