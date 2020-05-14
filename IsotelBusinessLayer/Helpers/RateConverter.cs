using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace IsotelBusinessLayer.Helpers
{
    public class RateConverter
    {
        public static int Convert(string requestedCurrency, int priceInDollars)
        {
            if (requestedCurrency == "USD")
                return priceInDollars;
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
                responseFromServer = regex.Match(responseFromServer).Value;
                int rate = System.Convert.ToInt32(System.Convert.ToDouble(responseFromServer));
                return rate * priceInDollars;
            }
        }
    }
}