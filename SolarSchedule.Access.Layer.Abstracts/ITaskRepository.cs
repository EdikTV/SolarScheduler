using System.Threading.Tasks;
using SolarSchedule.AccessLayer.Entities;
using Task = System.Threading.Tasks.Task; // и до такого доходит, когда не хочешь идти на компромисы со средой и менять название

namespace SolarSchedule.Access.Layer.Abstracts
{
    public interface ITaskRepository
    {
        Task CreateTask(AccessLayer.Entities.Task task);
        Task DeleteTask(int id);
        Task UpdateTask(int id, AccessLayer.Entities.Task newTask);
        Task<SolarSchedule.AccessLayer.Entities.Task> GetTaskById(int id);
    }
}