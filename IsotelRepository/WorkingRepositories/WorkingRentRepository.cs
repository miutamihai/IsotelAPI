using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelRepository.Repositories;
using IsotelDataLayer;
using IsotelDataLayer.Models;
using IsotelRepository.Helpers;

namespace IsotelRepository.WorkingRepositories
{
    public class WorkingRentRepository : RentRepository
    {
        IsotelDbContext dbContext;
        public WorkingRentRepository()
        {
            dbContext = new IsotelDbContext();
        }
        public Rent AddRent(Rent rent)
        {
            rent.IsAvailable = true;
            rent.RentId = dbContext.Rents.Count() + 1;
            dbContext.Rents.Add(rent);
            dbContext.SaveChanges();
            return rent;
        }

        public void DeleteRent(int rentId)
        {
            Rent rentToBeDeleted = dbContext.Rents.Where(rent => rent.RentId == rentId).FirstOrDefault();
            dbContext.Rents.Remove(rentToBeDeleted);
            dbContext.SaveChanges();
        }

        public void FreeRent(int rentId)
        {
            Rent rentToBeFreed = dbContext.Rents.FirstOrDefault(rent => rent.RentId == rentId);
            rentToBeFreed.IsAvailable = true;
            dbContext.SaveChanges();
        }

        public List<Rent> GetAvailableRents()
        {
            var rents = dbContext.Rents.ToList().FindAll(rent => rent.IsAvailable == true);
            return rents;
        }

        public Rent GetRent(int rentId)
        {
            var rent = dbContext.Rents.Where(x => x.RentId == rentId).FirstOrDefault();
            return rent;
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

        public void OccupyRent(int rentId, string username, string userPhoneNumber)
        {
            Rent rentToBeOccupied = dbContext.Rents.FirstOrDefault(rent => rent.RentId == rentId);
            if (rentToBeOccupied.IsAvailable == false)
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
    }
}
