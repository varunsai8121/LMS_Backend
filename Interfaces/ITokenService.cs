using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS_Backend.Entities;

namespace LMS_Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}