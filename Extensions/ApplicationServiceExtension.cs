using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS_Backend.Data;
using LMS_Backend.Interfaces;
using LMS_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DataContext>(option => option.UseNpgsql(configuration.GetConnectionString("connection")));
            service.AddCors();
            service.AddScoped<ITokenService, TokenService>();
            return service;
        }
    }
}