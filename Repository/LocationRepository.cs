using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetLocationsByUserId(int userId)
        {
            return await FindByCondition(location => location.user.Id.Equals(userId)).ToListAsync();
        }


        public void CreateLocation(Location location) => Create(location);
    }
}
