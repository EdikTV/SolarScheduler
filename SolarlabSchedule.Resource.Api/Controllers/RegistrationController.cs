using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using SolarlabSchedule.Resource.Api.Models;
using SolarSchedule.Access.Layer.Abstracts;

namespace SolarlabSchedule.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController:BaseController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskService _taskService;

        public RegistrationController(IMapper mapper, IUserService userService, IUnitOfWork unitOfWork, ITaskService taskService) : base(mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _taskService = taskService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            await _userService.CreateUser(new UserDto() {Email = model.Email, Password = model.Password});
            return Ok(true);
        }
    }
}