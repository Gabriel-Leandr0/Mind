using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Presentation.Models;

namespace Mind.Read.Interface;

public interface IUserQuery
{
    Task<Users> GetUsuarioById(int id);
    
}