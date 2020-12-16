using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using SolarlabSchedule.Resource.Api.Models;
using SolarSchedule.Access.Layer.Abstracts;

namespace SolarlabSchedule.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseController
    {
        /// <summary>
        /// Получаем Id пользователя
        /// </summary>
        private int UserId => Int32.Parse(User.Claims.Single(c=>c.Type==ClaimTypes.NameIdentifier).Value);

        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskService _taskService;

        public TasksController(IMapper mapper, IUserService userService, IUnitOfWork unitOfWork, ITaskService taskService) : base(mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _taskService = taskService;
        }

        /// <summary>
        /// Получение всех задач пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(_userService.GetTasks(UserId));
        }

        /// <summary>
        /// Добавить новую задачу
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("addtask")]
        public async Task<IActionResult> CreateTask([FromBody]CreateTaskModel taskModel)
        {
            TaskDto task = new TaskDto();
            task.Name = taskModel.NameTask;
            task.Description = taskModel?.Description;
            await _userService.AddTask(UserId, task);
            await _taskService.CreateTask(task);
            return Ok(true);
        }

        /// <summary>
        /// Удалить существующую задачу
        /// </summary>
        /// <param name="IdTask"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("deltask")]
        public async Task<IActionResult> DeleteTask([FromBody] int IdTask)
        {
            await _taskService.DeleteTask(IdTask);
            return Ok(true);
        }

        /// <summary>
        /// Обновить существующую задачу
        /// </summary>
        /// <param name="idTask"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("updatetask")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskModel taskModel)
        {
            await _taskService.UpdateTask(taskModel.IdPreviousTask, new TaskDto(){Name = taskModel.NameTask, Description = taskModel.Description});
            return Ok(true);
        }

    }
}
