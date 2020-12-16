using System.Threading.Tasks;
using AutoMapper;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Contract;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using SolarSchedule.Access.Layer.Abstracts;
using Task = SolarSchedule.AccessLayer.Entities.Task;

namespace SolarlabSchedule.BusinessLogic.Implementation.Services
{
    public class TaskService:ITaskService
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        #endregion

        public TaskService(IUnitOfWork unitOfWork, ITaskRepository taskRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<bool>> CreateTask(TaskDto task)
        {
            await _taskRepository.CreateTask(_mapper.Map<Task>(task));
            await _unitOfWork.SaveChanges();
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<bool>> UpdateTask(int id, TaskDto newTask)
        {
            await _taskRepository.UpdateTask(id, _mapper.Map<Task>(newTask));
            await _unitOfWork.SaveChanges();
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<bool>> DeleteTask(int IdTask)
        {
            await _taskRepository.DeleteTask(IdTask);
            await _unitOfWork.SaveChanges();
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<TaskDto>> GetById(int id)
        {
            TaskDto task = _mapper.Map<TaskDto>(_taskRepository.GetTaskById(id));
            return OperationResult<TaskDto>.Ok(task);
        }
    }
}