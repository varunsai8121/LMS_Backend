using LMS_Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}