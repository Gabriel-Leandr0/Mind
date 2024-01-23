using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Application.Interfaces;
using Mind.Domain;

namespace Mind.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUserById(int userId)
        {

            return new User { Id = userId, Name = "Gabriel" };
        }
    }
}