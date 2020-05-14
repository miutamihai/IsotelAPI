using IsotelDataLayer.Models;
using IsotelDataLayer.Helpers;
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
            var rents =  dbContext.Rents.ToList().FindAll(rent => rent.IsAvailable == true);
            return rents;
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
            var rent =  dbContext.Rents.Where(x => x.RentId == rentId).FirstOrDefault();
            return rent;
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

        public void FreeRent(int rentId)
        {
            Rent rentToBeFreed = dbContext.Rents.FirstOrDefault(rent => rent.RentId == rentId);
            rentToBeFreed.IsAvailable = true;
            dbContext.SaveChanges();
        }

        public void OccupyRent(int rentId, string username, string userPhoneNumber)
        {
            Rent rentToBeOccupied = dbContext.Rents.FirstOrDefault(rent => rent.RentId == rentId);
            if(rentToBeOccupied.IsAvailable == false)
            {
                throw new ArgumentException("Rent already occupied");
            }
            string landlordEmail = dbContext.Landlords.Where(landlord => landlord.LandlordId == rentToBeOccupied.LandlordId).FirstOrDefault().Email;
            string localPolicePhoneNumber = dbContext.Cities.Where(city => city.CityId == rentToBeOccupied.CityId).FirstOrDefault().PhoneNumber;
            EmailSender.SendEmail(landlordEmail, username, rentToBeOccupied.Address, userPhoneNumber);
            SMSSender.SendSMS(localPolicePhoneNumber, username, userPhoneNumber, rentToBeOccupied.Address);
            rentToBeOccupied.IsAvailable = false;
            dbContext.SaveChanges();
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
