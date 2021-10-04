using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IDeviceRepository _device;

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


        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
