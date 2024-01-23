using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mind.Application.Interfaces;
using Mind.Domain;

namespace Mind.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}