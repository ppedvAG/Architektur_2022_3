using Microsoft.EntityFrameworkCore;
using ppedv.Hotelmanager.Model;
using System;

namespace ppedv.Hotelmanager.Data.EfCore
{
    public class EfContext : DbContext
    {
        private readonly string _conString;

        public DbSet<Buchung> Buchungen { get; set; }
        public DbSet<Gast> Gaeste { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Zimmer> Zimmer { get; set; }

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=Hotelmanager_Dev;Trusted_Connection=true")
        {
            this._conString = conString;


          
            
        }

        public void ResetHotelValues(Hotel toReset)
        {
            this.Entry<Hotel>(toReset).CurrentValues.SetValues(this.Entry(new Hotel()).OriginalValues);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
        }

    }
}
