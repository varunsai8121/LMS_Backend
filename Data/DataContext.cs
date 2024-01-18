using LMS_Backend.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace LMS_Backend.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }



    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    public DbSet<LMS_Backend.Models.LeaveRequestVM> LeaveRequestVM { get; set; }

   

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configure relationships and constraints if needed

    //    modelBuilder.Entity<LeaveRequest>()
    //        .HasKey(lr => lr.Id);

    //    modelBuilder.Entity<LeaveRequest>()
    //        .Property(lr => lr.Id)
    //        .ValueGeneratedOnAdd();

    //    modelBuilder.Entity<LeaveRequest>()
    //        .Property(lr => lr.Status)
    //        .IsRequired();

    //    modelBuilder.Entity<LeaveRequest>()
    //        .HasOne(lr => lr.User)
    //        .WithMany(u => u.LeaveRequests)
    //        .HasForeignKey(lr => lr.UserId)
    //        .OnDelete(DeleteBehavior.Cascade);

    //    modelBuilder.Entity<LeaveRequest>()
    //        .HasOne(lr => lr.LeaveType)
    //        .WithMany()
    //        .HasForeignKey(lr => lr.LeaveTypeId)
    //        .OnDelete(DeleteBehavior.Cascade);

    //    modelBuilder.Entity<LeaveType>()
    //        .HasKey(lt => lt.Id);

    //        modelBuilder.Entity<User>()
    //                .HasKey(u => u.Id);


    //        modelBuilder.Entity<Team>()
    //            .HasKey(t => t.Id);

    //        modelBuilder.Entity<Holiday>()
    //            .HasKey(h => h.Id);

    //        // Add similar relationships and constraints for other entities

    //        base.OnModelCreating(modelBuilder);
    //    }
}





