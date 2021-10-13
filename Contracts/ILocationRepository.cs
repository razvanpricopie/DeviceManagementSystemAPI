﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>>GetAllLocations();
        Task<IEnumerable<Location>> GetLocationsByUserId(int userId);
        void CreateLocation(Location location);
    }
}
