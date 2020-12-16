using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks;
using SolarSchedule.Access.Layer.Abstracts;
using SolarSchedule.AccessLayer.Entities;
using SolarSchedule.AccessLayer.EntityFramework.DbContext;


namespace SolarSchedule.AccessLayer.EntityFramework.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly SchedulerDbContext _dbContext;

        public UserRepository(SchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task.Task<User> GetUserById(int id)
        {
            return await _dbContext.Userses.FindAsync(id);
        }

        public async Task.Task Add(User user)
        {
           await _dbContext.Userses.AddAsync(user);
        }

        public async Task.Task<User> GetUserByLoginPassword(string email, string password)
        {
            return await _dbContext.Userses.SingleOrDefaultAsync(e=>e.Email==email && e.Password==password);
        }

        public async Task.Task AddTaskToUser(int idUser, Entities.Task taskToAdd)
        {
           GetUserById(idUser).Result.Task.Add(taskToAdd);
        }

        public async Task.Task<IList<Entities.Task>> GetTasks(int idUser)
        {
            return GetUserById(idUser).Result.Task;
        }
    }
}