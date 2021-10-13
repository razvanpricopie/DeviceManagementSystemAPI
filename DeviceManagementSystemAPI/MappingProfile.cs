using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.Device;
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
            CreateMap<DeviceForAssignDTO, Device>();
            CreateMap<UserForRegistrationDTO, User>();
            CreateMap<UserForLoginDTO, User>();
            CreateMap<User, UserForLoginDTO>()
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(ur => ur.UserRoles.Select(role => role.Role).ToList()));
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(ur => ur.UserRoles.Select(role => role.Role).ToList()));
        }
    }
}
