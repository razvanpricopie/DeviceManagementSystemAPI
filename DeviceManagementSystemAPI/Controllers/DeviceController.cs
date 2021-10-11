using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystemAPI.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public DeviceController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDevices()
        {
            try
            {
                var devices = await _repositoryWrapper.Device.GetAllDevicesAsync();
                _logger.LogInfo("Returned all devices from DB succesfully");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDTO>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {e.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "DeviceById")]
        [Authorize]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            try
            {
                var device = await _repositoryWrapper.Device.GetDeviceByIdAsync(id);

                if (device == null)
                {
                    _logger.LogError($"Device with id: {id} hasn't been found in db.");
                    return NotFound($"Device with id: {id} hasn't been found in db.");
                }

                _logger.LogInfo($"The device with id: {id} was returned succesfully");

                var deviceResult = _mapper.Map<DeviceDTO>(device);

                return Ok(deviceResult);
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {e.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDevice([FromBody]DeviceForCreationDTO device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from the client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device  object sent from the client.");
                    return BadRequest("Invalid device model object");
                }

                var deviceEntity = _mapper.Map<DeviceForCreationDTO,Device>(device);

                _repositoryWrapper.Device.CreateDevice(deviceEntity);
                await _repositoryWrapper.SaveAsync();

                var createdDevice = _mapper.Map<DeviceDTO>(deviceEntity);

                return CreatedAtRoute("DeviceById", new { id = createdDevice.Id }, createdDevice);
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside CreateDevice action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody]DeviceForUpdateDTO device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from the client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from the client.");
                    return BadRequest("Invalid device model object");
                }

                var deviceEntity = await _repositoryWrapper.Device.GetDeviceByIdAsync(id);

                if (deviceEntity == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(device, deviceEntity);

                _repositoryWrapper.Device.UpdateDevice(deviceEntity);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside UpdateDevice action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            try
            {
                var device = await _repositoryWrapper.Device.GetDeviceByIdAsync(id);

                if (device == null)
                {
                    _logger.LogError($"Device with id: {id} hasn't been found in db.");
                    return NotFound($"Device with id: {id} hasn't been found in db.");
                }

                _logger.LogInfo($"The device with id: {id} was returned succesfully");

                _repositoryWrapper.Device.DeleteDevice(device);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside DeleteDevice action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
