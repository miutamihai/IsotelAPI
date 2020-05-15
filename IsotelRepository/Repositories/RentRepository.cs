using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelRepository.Repositories
{
    public interface RentRepository
    {
        List<Rent> GetRentsForCity(int cityId);
        List<Rent> GetRentsForLandlord(int landlordId);
        List<Rent> GetAvailableRents();
        Rent AddRent(Rent rent);
        Rent GetRent(int rentId);
        void FreeRent(int rentId);
        void OccupyRent(int rentId, string username, string userPhoneNumber);
        void DeleteRent(int rentId);
    }
}
