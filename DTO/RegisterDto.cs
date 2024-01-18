using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace LMS_Backend.DTO;
public class RegisterDto
{

    public string UserName { get; set; }

    public string Password { get; set; }
}
