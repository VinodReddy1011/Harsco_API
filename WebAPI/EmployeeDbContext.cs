using Microsoft.EntityFrameworkCore;
using System.Xml;
using WebAPI.Models;

namespace WebAPI
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContext):base(dbContext)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasCheckConstraint(
        //                "constraint_gender",
        //                "gender = 'male' or gender = 'female'");
        //        entity.HasCheckConstraint("constaint_chk_qualification",
        //            "qualification='btech' or qualification='mca' or qualification='mba' or qualification='ba' or qualification='mtech'");
        //    });
        //}
    }
}
