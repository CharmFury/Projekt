using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjektZespolowy.Dtos;
using ProjektZespolowy.Models;

namespace ProjektZespolowy.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamForCreationDto, Team>();
            CreateMap<TeamForUpdateDto, Team>();
        }
    }
}
