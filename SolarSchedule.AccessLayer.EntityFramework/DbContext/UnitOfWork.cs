using System.Threading.Tasks;
using SolarSchedule.Access.Layer.Abstracts;

namespace SolarSchedule.AccessLayer.EntityFramework.DbContext
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SchedulerDbContext _dbContext;

        public UnitOfWork(SchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveChanges()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}