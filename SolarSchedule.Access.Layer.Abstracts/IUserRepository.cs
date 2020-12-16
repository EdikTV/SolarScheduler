using System.Collections.Generic;
using System.Threading.Tasks;
using SolarSchedule.AccessLayer.Entities;
using Task = System.Threading.Tasks.Task;

namespace SolarSchedule.Access.Layer.Abstracts
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        System.Threading.Tasks.Task Add(User user);
        Task<User> GetUserByLoginPassword(string email, string password);
        System.Threading.Tasks.Task AddTaskToUser(int idUser, AccessLayer.Entities.Task taskToAdd);
        Task<IList<AccessLayer.Entities.Task>> GetTasks(int idUser);

    }
}