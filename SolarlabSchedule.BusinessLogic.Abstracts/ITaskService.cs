using SolarlabSchedule.BusinessLogic.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using SolarlabSchedule.BusinessLogic.Contract.Models;

namespace SolarlabSchedule.BusinessLogic.Abstracts
{
    public interface ITaskService
    {
        /// <summary>
        /// Создать задачу
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> CreateTask(TaskDto task);
        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> UpdateTask(int id, TaskDto newTask);
        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> DeleteTask(int IdTask);

        /// <summary>
        /// Получить задачу по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResult<TaskDto>> GetById(int id);
    }
}