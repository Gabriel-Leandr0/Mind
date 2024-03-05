using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Domain.Models;
using Mind.Read.Interface;

namespace Mind.Read.Queries;

public class UserQuery : IUserQuery
{
    Task<User> IUserQuery.GetUsuarioById(int id)
    {
        throw new NotImplementedException();
    }
}