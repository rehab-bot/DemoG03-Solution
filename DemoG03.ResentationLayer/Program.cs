using DemoG03.BusinessLogic.Profiles;
using DemoG03.BusinessLogic.Services.classes;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Data.Contexts;
using DemoG03.DataAccess.Repositories.Departments;
using DemoG03.DataAccess.Repositories.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoG03.ReesentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDBContext>();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
             {
                 //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                 // options.UserSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                 options.UseLazyLoadingProxies();

             });





            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices,DepartmentServices>();
            #endregion

            builder.Services.AddControllersWithViews(options =>
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
           
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));

            var app = builder.Build();
            #region Configure the HTTP request pipeline.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
