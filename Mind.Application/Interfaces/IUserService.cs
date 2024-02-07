using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Domain.DTos;
using Mind.Domain.ViewModels;

namespace Mind.Application.Interfaces;

public interface IUserService
{
 public Task<ResponseGeneric> CreateUser(CreateUserViewModel createUserViewModel);
 
}