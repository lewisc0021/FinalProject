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
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');

                Stock Company = new Stock();
                Company.Symbol = cols[0];
                Company.Name = cols[1];
                Company.Bid = Convert.ToDecimal(cols[2]);
                Company.Ask = Convert.ToDecimal(cols[3]);
                Company.Open = Convert.ToDecimal(cols[4]);
                Company.PreviousClose = Convert.ToDecimal(cols[5]);
                Company.Last = Convert.ToDecimal(cols[6]);

                stockInfo.Add(Company);

            }

            return stockInfo;
        }


    }
}