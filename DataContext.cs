using LMS_Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace LMS_Backend.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }


}
