using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MarketStumblerFinal.Controllers
{
    public class Popup1Controller : Controller
    {
        // GET: Popup1
        public ActionResult Popup1(string Symbol)
        {
            Symbol  = Symbol.Substring(1, Symbol.Length - 2);
            WebRequest request = WebRequest.Create("https://query2.finance.yahoo.com/v10/finance/quoteSummary/" + Symbol + "?modules=assetProfile");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            string start = "longBusinessSummary";
            string end = "fullTimeEmployees";
            string paragraph = getBetween(html, start, end);
            string paragraphTrimmed = paragraph.Substring(2, paragraph.Length - 4);
            ViewBag.Paragraph = paragraphTrimmed;
            ViewBag.Symbol = Symbol;
            ViewBag.Paragraph = paragraphTrimmed;
            return View();
        }

        public ActionResult Paragraph(string Symbol)
        {
            
            WebRequest request = WebRequest.Create("https://query2.finance.yahoo.com/v10/finance/quoteSummary/" + Symbol + "?modules=assetProfile");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            string start = "longBusinessSummary";
            string end = "fullTimeEmployees";
            string paragraph = getBetween(html, start, end);
            string paragraphTrimmed = paragraph.Substring(2, paragraph.Length - 4);
            ViewBag.Paragraph = paragraphTrimmed;
            return View("Popup1");
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "Description Not Found";
            }
        }


     }//

  }//