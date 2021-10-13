using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await FindAll()
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Manufacturer)
                .ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await FindByCondition(device => device.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GetDeviceByUserId(int userId)
        {
            var device = await FindByCondition(device => device.UserId.Equals(userId))
                .FirstOrDefaultAsync();

            if (device != null) return true;
            return false;
        }


        public async Task<bool> CheckIfUserHasDevice(int deviceId,int userId)
        {

            //var s =  

            var device = await FindByCondition(device => (device.Id.Equals(deviceId)) && (device.UserId.Equals(userId))).FirstOrDefaultAsync();

            if (device != null) return false;
            return true;
        }

        public void CreateDevice(Device device) => Create(device);

        public void UpdateDevice(Device device) => Update(device);

        public void DeleteDevice(Device device) => Delete(device);

    }
}
