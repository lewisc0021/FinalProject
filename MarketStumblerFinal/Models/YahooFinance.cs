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
                //if (cols.Length == 9)
                //{
                //    i += 1;
                //    cols[1] += ", Inc.";
                //}
                Stock Company = new Stock();
                Company.Symbol = cols[0];
                Company.Name = cols[1];
                try
                {
                    Company.Bid = Math.Round(Convert.ToDecimal(cols[cols.Length - 6]), 2);
                }
                catch
                {

                    Company.Bid = decimal.Zero;
                }



                try
                {
                    Company.Ask = Convert.ToDecimal(cols[cols.Length - 5]);
                }
                catch
                {

                    Company.Ask = decimal.Zero;
                }


                //try
                //{
                string[] perChangeList = cols[cols.Length - 4].Split();
                double exactChange = Math.Round(Convert.ToDouble(perChangeList[2].Substring(1, perChangeList[2].Length - 3)), 2);
                //Math.Round(Convert.ToDouble(perChangeList[2].Substring(1, perChangeList[2].Length - 2))).ToString();
                Company.perChange = perChangeList[2].ElementAt(0) + exactChange.ToString();
                //Company.perChange = perChangeList[2].Substring(0, perChangeList[2].Length - 2);

                //}
                //catch
                //{

                //    Company.perChange = "N/A";
                //}



                try
                {
                    Company.FiftyTwoRange = Convert.ToDecimal(cols[cols.Length - 3]);
                }
                catch
                {

                    Company.FiftyTwoRange = decimal.Zero;
                }



                try
                {
                    Company.OneYrTarg = Convert.ToDecimal(cols[cols.Length - 2]);

                }
                catch
                {

                    Company.OneYrTarg = decimal.Zero;
                }

                try
                {
                    Company.peRatio = Convert.ToDecimal(cols[cols.Length - 1]);

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

