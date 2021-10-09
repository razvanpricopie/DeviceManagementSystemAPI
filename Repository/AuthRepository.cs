using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await FindByCondition(user => user.Email == username).FirstOrDefaultAsync();

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }

            return true;
        }

        public void Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            Create(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            var user = await FindByCondition(user => user.Email == email).FirstOrDefaultAsync();

            if (user != null) 
                return true;

            return false;
        }
    }
}
