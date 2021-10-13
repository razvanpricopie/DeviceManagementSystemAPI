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
        public RepositoryContext _repositoryContext;
        private IDeviceRepository _device;
        private IAuthRepository _authUser;
        private IUserRepository _user;
        private IUserRoleRepository _userRole;
        private ILocationRepository _location;


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

        public IAuthRepository AuthUser
        {
            get
            {
                if (_authUser == null)
                {
                    _authUser = new AuthRepository(_repositoryContext);
                }

                return _authUser;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repositoryContext);
                }

                return _user;
            }
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)
                {
                    _userRole = new UserRoleRepository(_repositoryContext);
                }

                return _userRole;
            }
        }
        public ILocationRepository Location
        {
            get
            {
                if (_location == null)
                {
                    _location = new LocationRepository(_repositoryContext);
                }

                return _location;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
