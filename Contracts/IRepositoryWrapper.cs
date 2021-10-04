using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        void Save();
    }
}
