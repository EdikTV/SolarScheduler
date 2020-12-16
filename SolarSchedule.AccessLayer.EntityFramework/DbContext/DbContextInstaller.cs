using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarSchedule.AccessLayer.Entities;


namespace SolarSchedule.AccessLayer.EntityFramework.DbContext
{
    public class DbContextInstaller
    {
        public static void ConfigureDbContext(IServiceCollection services)
        {

            services
                .AddDbContext<SchedulerDbContext>(o => o.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Schedulezdb;Trusted_Connection=True;"));
            //services.AddIdentityCore<User>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<SchedulerDbContext>()
            //    .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));
        }
    }
}
