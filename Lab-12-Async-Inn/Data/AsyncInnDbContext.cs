using Lab_12_Async_Inn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
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

            // This calls the base method, and Identity needs it or it does nothing, comments are inconsistent
            base.OnModelCreating(modelBuilder);

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

            //Create different roles in the DB
            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
            SeedRole(modelBuilder, "Writer", "create");

        }

        private int NextId { get; set; } = 1;

        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);


            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                //Because of following John's path kind of this is a hanging error
                Id = NextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }


    }
}
