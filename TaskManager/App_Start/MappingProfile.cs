using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Dto;
using TaskManager.Models;

namespace TaskManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<PersonalTask, PersonalTaskDto>();
            Mapper.CreateMap<PersonalTaskDto, PersonalTask>();
        }
    }
}