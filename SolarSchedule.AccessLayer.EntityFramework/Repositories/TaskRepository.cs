using System.Threading.Tasks;
using SolarSchedule.Access.Layer.Abstracts;
using SolarSchedule.AccessLayer.EntityFramework.DbContext;
using SolarSchedule.AccessLayer.Entities;
using Task = System.Threading.Tasks.Task;

namespace SolarSchedule.AccessLayer.EntityFramework.Repositories
{
    public class TaskRepository:ITaskRepository
    {
        private readonly SchedulerDbContext _dbContext;

        public TaskRepository(SchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateTask(Entities.Task task)
        {
            await _dbContext.Taskses.AddAsync(task);
        }

        public async Task DeleteTask(int id)
        {
            var item = await GetTaskById(id);
            if (item != null)
            {
                _dbContext.Taskses.Remove(item);
            }
        }

        public async Task UpdateTask(int id, Entities.Task newTask)
        { 
            GetTaskById(id).Result.Name = newTask.Name;
            GetTaskById(id).Result.Description = newTask.Description;
        }

        public async Task<Entities.Task> GetTaskById(int id)
        {
           return await _dbContext.Taskses.FindAsync(id);
        }
    }
}