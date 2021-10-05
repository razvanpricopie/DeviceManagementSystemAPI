using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
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
        public IActionResult GetDevices()
        {
            try
            {
                var devices = _repositoryWrapper.Device.GetAllDevices();
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
        public IActionResult GetDeviceById(int id)
        {
            try
            {
                var device = _repositoryWrapper.Device.GetDeviceById(id);

                if (device == null)
                {
                    _logger.LogError("The device with the specificied id wasn't found in DB");
                    return NotFound();
                }

                _logger.LogInfo("The device with the specified id was returned succesfully");

                var deviceResult = _mapper.Map<DeviceDTO>(device);

                return Ok(deviceResult);
            }
            catch(Exception e)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {e.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
