using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SolarlabSchedule.Auth.Api.Model;
using SolarlabSchedule.Auth.Common;
using System.Security.Claims;
using AutoMapper;
using SolarlabSchedule.BusinessLogic.Abstracts;
using SolarlabSchedule.BusinessLogic.Contract;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SolarlabSchedule.Auth.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper, IOptions<AuthOptions> authOptions, IUserService userService) : base(mapper)
        {
            _authOptions = authOptions;
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            UserDto user = _userService.GetUserByLoginPassword(request.Email, request.Password).Result.Result;
            if (user!=null)
            {
                var token = GenerateJWT(user);

                return Ok(new
                {
                    access_token = token
                });
            }

            return Unauthorized();
        }



        private string GenerateJWT(UserDto user)
        {
            var authParam = _authOptions.Value;
            var securityKey = authParam.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claim = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
 
            var token = new JwtSecurityToken(authParam.Issuer,
                authParam.Audience,
                claim,
                expires:DateTime.Now.AddSeconds(authParam.TokenLifetime),
                signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
