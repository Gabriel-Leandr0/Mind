using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Domain;

namespace Mind.Application.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        
    }
}