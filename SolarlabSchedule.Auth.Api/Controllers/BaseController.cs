using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarlabSchedule.BusinessLogic.Contract;

namespace SolarlabSchedule.Auth.Api.Controller
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IActionResult ProcessOperationResult<T>(OperationResult<T> operationResult)
        {
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        protected async Task<IActionResult> ProcessOperationResult<T>(Func<Task<OperationResult<T>>> action)
        {
            try
            {
                var operationResult = await action.Invoke();
                if (!operationResult.Success)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
                }
                return Ok(operationResult.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла непредвиденная ошибка обратитесь в службу поддержки");
            }
        }


        protected IActionResult ProcessOperationResult<T>(Func<OperationResult<T>> action)
        {
            try
            {
                var operationResult = action.Invoke();
                if (!operationResult.Success)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
                }
                return Ok(operationResult.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла непредвиденная ошибка обратитесь в службу поддержки");
            }
        }
    }
}