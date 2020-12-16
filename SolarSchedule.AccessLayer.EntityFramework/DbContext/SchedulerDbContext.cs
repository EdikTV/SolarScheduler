using Microsoft.EntityFrameworkCore;
using SolarSchedule.AccessLayer.Entities;

namespace SolarSchedule.AccessLayer.EntityFramework.DbContext
{
    public sealed class SchedulerDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Task> Taskses { get; set; }
        public DbSet<User> Userses { get; set; }

        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Schedulezdb;Trusted_Connection=True;").UseLazyLoadingProxies();
        }

    }
}