using IsotelDataLayer;
using IsotelDataLayer.Models;
using IsotelBusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer
{
    public class QueryResolver
    {
        static DBManager manager = new DBManager();
        private static void ConvertPriceRates(ref List<Rent> rents, string currency)
        {
            foreach (Rent rent in rents)
            {
                rent.PricePerDay = CalculateNewPrice(rent.PricePerDay, currency);
            }
        }

        private static int CalculateNewPrice(int oldPrice, string currency)
        {
            return RateConverter.Convert(currency, oldPrice);
        }
        public static List<Rent> GetRentsForCity(int cityId, string currency)
        {
            var rents =  manager.GetRentsForCity(cityId);
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        public static List<Rent> GetRentsForLandlord(int landlordId, string currency)
        {
            var rents =  manager.GetRentsForLandlord(landlordId);
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        public static List<Rent> GetAvailableRents(string currency)
        {
            var rents =  manager.GetAvailableRents();
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        internal static Rent AddRent(Rent rent)
        {
            return manager.AddRent(rent);
        }

        public static Rent GetRent(int rentId, string currency)
        {
            var rent = manager.GetRent(rentId);
            rent.PricePerDay = CalculateNewPrice(rent.PricePerDay, currency);
            return rent;
        }

        public static Landlord GetLandlord(int landlordId)
        {
            return manager.GetLandlord(landlordId);
        }

        internal static Landlord AddLandlord(Landlord landlord)
        {
            return manager.AddLandlord(landlord);
        }

        public static City GetCity(int cityId)
        {
            return manager.GetCity(cityId);
        }
        public static List<City> GetCities()
        {
            return manager.GetCities();
        }
        internal static void DeleteRent(int rentId)
        {
            manager.DeleteRent(rentId);
        }
        internal static void DeleteLandlord(int landlordId)
        {
            manager.DeleteLandlord(landlordId);
        }
    }
}
