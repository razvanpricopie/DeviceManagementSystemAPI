using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll()
                .Include(userRole => userRole.UserRoles)
                .ThenInclude(role => role.Role)
                .OrderBy(user => user.Email)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await FindByCondition(user => user.Id.Equals(id))
                .Include(userRole => userRole.UserRoles)
                .ThenInclude(role => role.Role)
                .FirstOrDefaultAsync();
        }

        public void UpdateUser(User user) => Update(user);

        public void DeleteUser(User user) => Delete(user);
    }
}
