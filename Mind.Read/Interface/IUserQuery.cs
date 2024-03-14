using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Domain.Models;

namespace Mind.Read.Interface;

public interface IUserQuery
{
    Task<User> GetUsuarioById(int id);

}