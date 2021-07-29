using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        // CREATE
        Task<Amenity> Create(Amenity amenity);

        // GET ALL
        Task<List<Amenity>> GetAmenities();

        // GET ONE BY ID
        Task<Amenity> GetAmenity(int id);

        // UPDATE
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        // DELETE
        Task Delete(int id);

    }
}
