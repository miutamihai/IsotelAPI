using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelDataLayer.Models
{
    public class IsotelDbContext : DbContext
    {
        public IsotelDbContext() : base("IsotelDatabase")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
