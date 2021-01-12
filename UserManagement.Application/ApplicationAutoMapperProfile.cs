using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Users;

namespace UserManagement
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUpdateUserDto, User>();
        }
    }
}
