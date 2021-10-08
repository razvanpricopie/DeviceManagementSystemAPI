using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IDeviceRepository _device;
        private IAuthRepository _user;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDeviceRepository Device
        {
            get
            {
                if(_device == null)
                {
                    _device = new DeviceRepository(_repositoryContext);
                }

                return _device;
            }
        }

        public IAuthRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new AuthRepository(_repositoryContext);
                }

                return _user;
            }
        }


        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
