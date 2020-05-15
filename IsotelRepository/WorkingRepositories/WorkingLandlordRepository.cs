using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelDataLayer.Models;
using IsotelRepository.Repositories;

namespace IsotelRepository.WorkingRepositories
{
    public class WorkingLandlordRepository : LandlordRepository
    {
        IsotelDbContext dbContext;
        public WorkingLandlordRepository()
        {
            dbContext = new IsotelDbContext();
        }
        public Landlord AddLandlord(Landlord landlord)
        {
            dbContext.Landlords.Add(landlord);
            dbContext.SaveChanges();
            return landlord;
        }

        public void DeleteLandlord(int landlordId)
        {
            Landlord landlordToBeDeleted = dbContext.Landlords.Where(landlord => landlord.LandlordId == landlordId).FirstOrDefault();
            dbContext.Landlords.Remove(landlordToBeDeleted);
            dbContext.SaveChanges();
        }

        public Landlord GetLandlord(int landlordId)
        {
            return dbContext.Landlords.Where(landlord => landlord.LandlordId == landlordId).FirstOrDefault();
        }
    }
}
