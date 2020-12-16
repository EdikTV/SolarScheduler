using System.Collections.Generic;
using System.Threading.Tasks;
using SolarlabSchedule.BusinessLogic.Contract;
using SolarlabSchedule.BusinessLogic.Contract.Models;

namespace SolarlabSchedule.BusinessLogic.Abstracts
{
    public interface IUserService
    {
        Task<OperationResult<bool>> CreateUser(UserDto user);
        Task<OperationResult<UserDto>> GetUserById(int id);
        Task<OperationResult<UserDto>> GetUserByLoginPassword(string email, string password);
        /// <summary>
        /// Находим юзера по Id и обновляем ему инфу, то есть добавляем/удаляем задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> AddTask(int id, TaskDto task);

        Task<OperationResult<IList<TaskDto>>> GetTasks(int idUser);
    }
}