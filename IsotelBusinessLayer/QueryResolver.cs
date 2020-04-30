using IsotelDataLayer;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer
{
    public class QueryResolver
    {
        static DBManager manager = new DBManager();
        public static List<Rent> GetRentsForCity(int cityId)
        {
            return manager.GetRentsForCity(cityId);
        }

        public static List<Rent> GetRentsForLandlord(int landlordId)
        {
            return manager.GetRentsForLandlord(landlordId);
        }

        public static List<Rent> GetAvailableRents()
        {
            return manager.GetAvailableRents();
        }

        internal static Rent AddRent(Rent rent)
        {
            return manager.AddRent(rent);
        }

        public static Rent GetRent(int rentId)
        {
            return manager.GetRent(rentId);
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
    }
}
