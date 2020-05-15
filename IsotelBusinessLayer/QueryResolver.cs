using IsotelDataLayer.Models;
using IsotelBusinessLayer.Helpers;
using IsotelRepository.WorkingRepositories;
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
        static WorkingCityRepository cityRepository = new WorkingCityRepository();
        static WorkingLandlordRepository landlordRepository = new WorkingLandlordRepository();
        static WorkingRentRepository rentRepository = new WorkingRentRepository();
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
            var rents =  rentRepository.GetRentsForCity(cityId);
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        public static List<Rent> GetRentsForLandlord(int landlordId, string currency)
        {
            var rents =  rentRepository.GetRentsForLandlord(landlordId);
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        public static List<Rent> GetAvailableRents(string currency)
        {
            var rents =  rentRepository.GetAvailableRents();
            ConvertPriceRates(ref rents, currency);
            return rents;
        }

        internal static Rent AddRent(Rent rent)
        {
            return rentRepository.AddRent(rent);
        }

        public static Rent GetRent(int rentId, string currency)
        {
            var rent = rentRepository.GetRent(rentId);
            rent.PricePerDay = CalculateNewPrice(rent.PricePerDay, currency);
            return rent;
        }

        public static Landlord GetLandlord(int landlordId)
        {
            return landlordRepository.GetLandlord(landlordId);
        }

        internal static Landlord AddLandlord(Landlord landlord)
        {
            return landlordRepository.AddLandlord(landlord);
        }

        public static City GetCity(int cityId)
        {
            return cityRepository.GetCity(cityId);
        }
        public static List<City> GetCities()
        {
            return cityRepository.GetCities();
        }
        internal static void DeleteRent(int rentId)
        {
            rentRepository.DeleteRent(rentId);
        }
        internal static void DeleteLandlord(int landlordId)
        {
            landlordRepository.DeleteLandlord(landlordId);
        }
        internal static void FreeRent(int rentId)
        {
            rentRepository.FreeRent(rentId);
        }
        internal static void OccupyRent(int rentId, string username, string userPhoneNumber)
        {
            rentRepository.OccupyRent(rentId, username, userPhoneNumber);
        }
    }
}
