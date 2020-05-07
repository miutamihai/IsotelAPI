using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelDataLayer
{
    public class DBManager
    {
        IsotelDbContext dbContext;
        public DBManager()
        {
            dbContext = new IsotelDbContext();
        }
        public List<Rent> GetRentsForCity(int cityId)
        {
            var rents = dbContext.Rents.ToList().FindAll(rent => rent.CityId == cityId);
            return rents;
        }

        public List<Rent> GetRentsForLandlord(int landlordId)
        {
            var rents = dbContext.Rents.ToList().FindAll(rent => rent.LandlordId == landlordId);
            return rents;
        }

        public List<Rent> GetAvailableRents()
        {
            return dbContext.Rents.ToList().FindAll(rent => rent.IsAvailable == true);
        }
        public Rent AddRent(Rent rent)
        {
            rent.IsAvailable = true;
            rent.RentId = dbContext.Rents.Count() + 1;
            dbContext.Rents.Add(rent);
            dbContext.SaveChanges();
            return rent;
        }

        public Rent GetRent(int rentId)
        {
            return dbContext.Rents.Where(rent => rent.RentId == rentId).FirstOrDefault();
        }

        public Landlord GetLandlord(int landlordId)
        {
            return dbContext.Landlords.Where(landlord => landlord.LandlordId == landlordId).FirstOrDefault();
        }

        public Landlord AddLandlord(Landlord landlord)
        {
            dbContext.Landlords.Add(landlord);
            dbContext.SaveChanges();
            return landlord;
        }

        public City GetCity(int cityId)
        {
            return dbContext.Cities.Where(city => city.CityId == cityId).FirstOrDefault();
        }

        public List<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }
        public void DeleteRent(int rentId)
        {
            Rent rentToBeDeleted = dbContext.Rents.Where(rent => rent.RentId == rentId).FirstOrDefault();
            dbContext.Rents.Remove(rentToBeDeleted);
            dbContext.SaveChanges();
        }
        public void DeleteLandlord(int landlordId)
        {
            Landlord landlordToBeDeleted = dbContext.Landlords.Where(landlord => landlord.LandlordId == landlordId).FirstOrDefault();
            dbContext.Landlords.Remove(landlordToBeDeleted);
            dbContext.SaveChanges();
        }
    }
}
