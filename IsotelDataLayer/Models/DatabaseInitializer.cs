using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelDataLayer.Models
{
   public class DatabaseInitializer: CreateDatabaseIfNotExists<IsotelDbContext>
    {
        protected override void Seed(IsotelDbContext context)
        {

            List<City> cities = new List<City>()
            {
                new City {CityId = 1, Name = "Brasov", PhoneNumber = "0268 407500"},
                new City {CityId = 2, Name = "Bucharest", PhoneNumber = "021.315.35.34"},
                new City {CityId = 3, Name = "Cluj", PhoneNumber = "0264/432727"},
                new City {CityId = 4, Name = "Constanta", PhoneNumber = "0241.611 364"},
                new City {CityId = 5, Name = "Craiova", PhoneNumber = "0251-510.154"},
                new City {CityId = 6, Name = "Iasi", PhoneNumber = "0232.302.003"},
                new City {CityId = 7, Name = "Oradea", PhoneNumber = "0259-412.227"},
                new City {CityId = 8, Name = "Timisoara", PhoneNumber = "0256/40.21.10"},

            };

            List<Landlord> landlords = new List<Landlord>()
            {
                new Landlord {LandlordId = 1, FirstName = "Adrian", LastName = "Istratie", Email = "adrian.istratie@gmail.com", PhoneNumber = "0765786435"},
                new Landlord {LandlordId = 2, FirstName = "Iulia", LastName = "Hurloi", Email = "hurloi.iulia99@hotmail.com", PhoneNumber = "0789654786"},
                new Landlord {LandlordId = 3, FirstName = "Teodor", LastName = "Imparatu", Email = "teoImp@yahoo.ro", PhoneNumber = "0765478653"},
                new Landlord {LandlordId = 4, FirstName = "Codrut", LastName = "Constantinescu", Email = "cctescu@gmail.com", PhoneNumber = "0765347835"},
                new Landlord {LandlordId = 5, FirstName = "Miruna", LastName = "Strungariu", Email = "mstrungariu@gmail.com", PhoneNumber = "0729876453"},
                new Landlord {LandlordId = 6, FirstName = "Catalin", LastName = "Caldararu", Email = "kalin@gmail.com", PhoneNumber = "0786547382"},
                new Landlord {LandlordId = 7, FirstName = "Stefan", LastName = "Ivan", Email = "stefan.ivan@yahoo.ro", PhoneNumber = "0726354738"},
                new Landlord {LandlordId = 8, FirstName = "Nadia", LastName = "Mocanu", Email = "nadiam@yahoo.com", PhoneNumber = "0728463756"},
            };

            List<Rent> rents = new List<Rent>()
            {
                new Rent {RentId = 1, Address = "35 Bulevardul Alexandru Vlahuță, 5th Appartment", CityId = 1, LandlordId = 5, PricePerDay = 25, IsAvailable = true},
                new Rent {RentId = 2, Address = "29 Strada Doamnei, 7th appartment", CityId = 2, LandlordId = 7, PricePerDay = 14, IsAvailable = true},
                new Rent {RentId = 3, Address = "39 Strada Teodor Mihali, 28th appartment", CityId = 3, LandlordId = 4, PricePerDay = 30, IsAvailable = true},
                new Rent {RentId = 4, Address = "31 E60, 1st appartment", CityId = 4, LandlordId = 6, PricePerDay = 15, IsAvailable = true},
                new Rent {RentId = 5, Address = "1 Strada Contraamiral Horia Macellariu, 9th appartment", CityId = 5, LandlordId = 1, PricePerDay = 20, IsAvailable = true},
                new Rent {RentId = 6, Address = "5 Strada Zimbrului, 15th appartment", CityId = 6, LandlordId = 3, PricePerDay = 20, IsAvailable = true},
                new Rent {RentId = 7, Address = "34 Strada Jean Jaurès", CityId = 7, LandlordId = 8, PricePerDay = 50, IsAvailable = true},
                new Rent {RentId = 8, Address = "1 Piața Libertății, 7th appartment", CityId = 8, LandlordId = 2, PricePerDay = 30, IsAvailable = true},
            };
            foreach(var city in cities)
            {
                context.Cities.AddOrUpdate(city);
            }
            foreach (var landlord in landlords)
            {
                context.Landlords.AddOrUpdate(landlord);
            }
            foreach (var rent in rents)
            {
                context.Rents.AddOrUpdate(rent);
            }
            base.Seed(context);

        }
    }
}
