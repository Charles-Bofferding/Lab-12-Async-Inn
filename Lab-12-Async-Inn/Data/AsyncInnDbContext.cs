using Lab_12_Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Amenity>().HasData(
              new Amenity { Id = 1, Name = "Fridge" },
              new Amenity { Id = 2, Name = "Cable Channels" },
              new Amenity { Id = 3, Name = "Mini Bar" }
            );

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "South Hampton Hotel" },
              new Hotel { Id = 2, Name = "The Grand on Vegas Blvd" },
              new Hotel { Id = 3, Name = "Queens Rest" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Budget Studio", Layout = 0 },
                new Room { Id = 2, Name = "Standard Suite", Layout = 1 },
                new Room { Id = 3, Name = "VIP Suite", Layout = 2 }
            );

        }

    }
}
