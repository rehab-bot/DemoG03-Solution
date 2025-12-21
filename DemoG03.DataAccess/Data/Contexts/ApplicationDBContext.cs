using DemoG03.DataAccess.Data.Configrations;
using DemoG03.DataAccess.Models.Departments;
using DemoG03.DataAccess.Models.Employees;
using DemoG03.DataAccess.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Data.Contexts
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
      
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
     public DbSet<IdentityUser> Users { get; set; } = null!;
        public DbSet<IdentityRole> Roles { get; set; } = null!;


        //protected override void OnConfiguring(DbContextOptionsBu
        //ilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("ConnectionString");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new DepartmentConfigration());
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
