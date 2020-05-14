using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace IsotelAPI.Helpers
{
    public class RateConverter
    {
        public static double Convert(string requestedCurrency, int priceInDollars)
        {
            string regexPattern = @"(?<=(?:";
            regexPattern += '"';
            regexPattern += requestedCurrency;
            regexPattern += '"';
            regexPattern += @":)(.*?)(?:)).+?(?=})";
            Regex regex = new Regex(regexPattern);
            WebRequest request = WebRequest.Create("https://api.exchangeratesapi.io/latest?base=USD&symbols=" + requestedCurrency);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                double rate = Convert.ToDouble(regex.Match(responseFromServer).Value);
                return rate * priceInDollars;
            }
        }
    }
}