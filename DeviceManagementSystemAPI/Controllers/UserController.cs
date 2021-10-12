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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public UserController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _repositoryWrapper.User.GetAllUsersAsync();
                _logger.LogInfo("Returned all users from DB succesfully");
                
                var usersResult = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(usersResult);
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {e.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _repositoryWrapper.User.GetUserByIdAsync(id);

                if (user == null)
                {
                    _logger.LogError($"The user with id: {id} hasn't been found in db.");
                    return NotFound($"The user with id: {id} hasn't been found in db.");
                }

                _logger.LogInfo($"The user with id: {id} was returned succesfully");

                var userResult = _mapper.Map<User, UserDTO>(user);

                return Ok(userResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {e.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                var user = await _repositoryWrapper.User.GetUserByIdAsync(id);

                if (user == null)
                {
                    _logger.LogError($"The user with id: {id} hasn't been found in db.");
                    return NotFound($"The user with id: {id} hasn't been found in db.");
                }

                _logger.LogInfo($"The user with id: {id} was returned succesfully");

                _repositoryWrapper.User.DeleteUser(user);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
