using Microsoft.Extensions.DependencyInjection;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Implementation.Services;
using SolarSchedule.Access.Layer.Abstracts;
using SolarSchedule.AccessLayer.EntityFramework.DbContext;
using SolarSchedule.AccessLayer.EntityFramework.Repositories;

namespace SolarlabSchedule.Auth.Api
{
    public class ServicesInstaller
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<ITaskService, TaskService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ITaskRepository, TaskRepository>();
        }
    }
}