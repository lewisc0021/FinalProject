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
                Company.Bid = Convert.ToDecimal(cols[2+i]);
                Company.Ask = Convert.ToDecimal(cols[3+i]);
                Company.Open = Convert.ToDecimal(cols[4+i]);
                Company.PreviousClose = Convert.ToDecimal(cols[5+i]);
                Company.Last = Convert.ToDecimal(cols[6+i]);

                stockInfo.Add(Company);

            }

            return stockInfo;
        }


    }
}