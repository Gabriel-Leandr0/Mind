using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mind.Domain.ViewModels
{
    public class UserViewModel
    {
        public List<Claim> Claims { get; set; }
    }
}