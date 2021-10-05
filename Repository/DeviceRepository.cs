using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        { }

        public IEnumerable<Device> GetAllDevices()
        {
            return FindAll()
                .OrderBy(device => device.Type)
                .ThenBy(device => device.Manufacturer)
                .ToList();
        }

        public Device GetDeviceById(int id)
        {
            return FindByCondition(device => device.Id.Equals(id))
                .FirstOrDefault();
        }

        public void CreateDevice(Device device) => Create(device);

        public void UpdateDevice(Device device) => Update(device);

        public void DeleteDevice(Device device) => Delete(device);

    }
}
