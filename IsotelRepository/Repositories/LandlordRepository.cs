using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelRepository.Repositories
{
    interface LandlordRepository
    {
        Landlord GetLandlord(int landlordId);
        Landlord AddLandlord(Landlord landlord);
        void DeleteLandlord(int landlordId);
    }
}
