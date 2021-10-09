using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        IAuthRepository AuthUser { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
