using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateUserRole(int userId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = 2
            };

            Create(userRole);
        }
    }
}
