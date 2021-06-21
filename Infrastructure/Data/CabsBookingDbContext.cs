using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Data
{
    public class CabsBookingDbContext : DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {

        }

        //Table properties getting set.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(ConfigureBookings);
        }

        //Adding tables to the database.
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }
        public DbSet<CabTypes> CabTypes { get; set; }
        public DbSet<Places> Places { get; set; }

        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
        }
    }
}
