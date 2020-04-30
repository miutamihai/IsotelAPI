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
            var rents = dbContext.Rents.ToList().FindAll(rent => rent.OwnerId == landlordId);
            return rents;
        }

        public List<Rent> GetAvailableRents()
        {
            return dbContext.Rents.ToList().FindAll(rent => rent.IsAvailable == true);
        }
        public Rent AddRent(Rent rent)
        {
            dbContext.Rents.Add(rent);
            dbContext.SaveChanges();
            return rent;
        }

        public Rent GetRent(int rentId)
        {
            return dbContext.Rents.Where(rent => rent.Id == rentId).FirstOrDefault();
        }

        public Landlord GetLandlord(int landlordId)
        {
            return dbContext.Landlords.Where(landlord => landlord.Id == landlordId).FirstOrDefault();
        }

        public Landlord AddLandlord(Landlord landlord)
        {
            dbContext.Landlords.Add(landlord);
            dbContext.SaveChanges();
            return landlord;
        }

        public City GetCity(int cityId)
        {
            return dbContext.Cities.Where(city => city.Id == cityId).FirstOrDefault();
        }

        public List<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }
    }
}
