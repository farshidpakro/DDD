using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Simple_DDD.Domain.DTOs;
using Simple_DDD.Infrastructure.Context;

namespace Simple_DDD.API
{
    public class MappingProfile : Profile
    { public MappingProfile() {
         // Add as many of these lines as you need to map your objects
         CreateMap<User, UserDto>();
         CreateMap<UserDto, User>()
         //.ForMember(c=>c.Name , x=>x.MapFrom(z=>"test"))
         ;
     }
    }
}