using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Contract;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using SolarSchedule.Access.Layer.Abstracts;
using SolarSchedule.AccessLayer.Entities;
using Task = SolarSchedule.AccessLayer.Entities.Task;

namespace SolarlabSchedule.BusinessLogic.Implementation.Services
{
    public class UserService:IUserService
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public async Task<OperationResult<bool>> CreateUser(UserDto user)
        {
            await _userRepository.Add(_mapper.Map<User>(user));
            await _unitOfWork.SaveChanges();
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<UserDto>> GetUserById(int id)
        {
           var user= _userRepository.GetUserById(id);
           var userDto = _mapper.Map<UserDto>(user);
           return OperationResult<UserDto>.Ok(userDto);
        }

        public async Task<OperationResult<UserDto>> GetUserByLoginPassword(string email, string password)
        {
            return OperationResult<UserDto>.Ok(_mapper.Map<UserDto>(_userRepository.GetUserByLoginPassword(email,password).Result));
        }

        public async Task<OperationResult<bool>> AddTask(int id, TaskDto task)
        {
            if (task != null) await _userRepository.AddTaskToUser(id, _mapper.Map<Task>(task));
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<IList<TaskDto>>> GetTasks(int idUser)
        {
            List<TaskDto> tasks = new List<TaskDto>();
            foreach (var task in _userRepository.GetTasks(idUser).Result)
            {
                tasks.Add(_mapper.Map<TaskDto>(task));
            }
            return OperationResult<IList<TaskDto>>.Ok(tasks);
        }
    }
}