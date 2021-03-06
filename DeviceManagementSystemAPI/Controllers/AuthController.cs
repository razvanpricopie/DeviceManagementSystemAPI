using AutoMapper;
using Contracts;
using Entities.DTOs.User;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystemAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;

        public AuthController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService token)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDTO user)
        {
            try
            {
                if(user == null)
                {
                    _logger.LogError("User object sent from the client is null.");
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from the client.");
                    return BadRequest("Invalid user model object");
                }

                if (await _repositoryWrapper.AuthUser.UserExists(user.Email = user.Email.ToLower()))
                    return BadRequest("Username already exists");

                var userEntity = _mapper.Map<UserForRegistrationDTO, User>(user);

                _repositoryWrapper.AuthUser.Register(userEntity, user.Password);
                await _repositoryWrapper.SaveAsync();

                var createdUser = _mapper.Map<UserDTO>(userEntity);

                _repositoryWrapper.UserRole.CreateUserRole(createdUser.Id);
                await _repositoryWrapper.SaveAsync();

                return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside Register action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        } 

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO user)
        {
            try
            {
                var userFromRepo = await _repositoryWrapper.AuthUser.Login(user.Email, user.Password);

                if (userFromRepo == null)
                {
                    return Unauthorized();
                }

                var userEntity = _mapper.Map<UserForLoginDTO, User>(user);

                var token = _token.CreateToken(userEntity);

                var userResult = _mapper.Map<User, UserForLoginDTO>(userFromRepo);

                return Ok(new
                {
                    Email = userResult.Email,
                    Token = token,
                    Name = userResult.Name,
                    Role = userResult.Roles,
                    Id = userResult.Id
                });
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside Login action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
            

        }
    }
}
