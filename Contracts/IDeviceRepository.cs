using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceByIdAsync(int id);
        Task<bool> GetDeviceByUserId(int id);
        Task<bool> CheckIfUserHasDevice(int deviceId, int userId);
        void CreateDevice(Device device);
        Task<bool> DeviceExists(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
