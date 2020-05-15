using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelRepository.Repositories
{
    interface CityRepository
    {
        City GetCity(int cityId);
        List<City> GetCities();
    }
}
