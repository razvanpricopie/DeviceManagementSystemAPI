﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDeviceById(int id);
        void CreateDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
