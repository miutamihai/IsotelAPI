using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelDataLayer.Models;
using IsotelRepository.Repositories;

namespace IsotelRepository.WorkingRepositories
{
    public class WorkingCityRepository : CityRepository
    {
        IsotelDbContext dbContext;
        public WorkingCityRepository()
        {
            dbContext = new IsotelDbContext();
        }
        public List<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }

        public City GetCity(int cityId)
        {
            return dbContext.Cities.Where(city => city.CityId == cityId).FirstOrDefault();
        }
    }
}
