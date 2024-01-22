using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Application.Interfaces;
using Mind.Domain;

namespace Mind.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}