using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketStumblerFinal.Models
{
    public class Stock
    {   //Property for Company any stock object will have these properties
        public string Symbol { get; set; } //0
        public string Name { get; set; } //1
        public decimal Bid { get; set; } //2
        public decimal Ask { get; set; } //3
        public string perChange { get; set; } //4
        public decimal FiftyTwoRange { get; set; } //5
        public decimal OneYrTarg { get; set; } //6
        public decimal peRatio { get; set; } //7

    }
}