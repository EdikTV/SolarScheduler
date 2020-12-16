using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SolarSchedule.AccessLayer.EntityFramework.DbContext
{
    public class DatabaseContextFactory: IDesignTimeDbContextFactory<SchedulerDbContext>
    {
        public SchedulerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchedulerDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Schedulezdb;Trusted_Connection=True;");
            return new SchedulerDbContext(optionsBuilder.Options);
        }
    }
}