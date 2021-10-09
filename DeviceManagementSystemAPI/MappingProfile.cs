using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystemAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceDTO>();
            CreateMap<DeviceForCreationDTO, Device>();
            CreateMap<DeviceForUpdateDTO,Device>();
            CreateMap<UserForRegistrationDTO, User>();
            CreateMap<UserForLoginDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
