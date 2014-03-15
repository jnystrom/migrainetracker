using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gazallion.MigraineManager.Data.Models;
using Gazallion.MigraineManager.Common.Data.DTOs;

namespace Gazallion.MigraineManager.Web.App_Start
{
    public static class AutoMapperBootstrapper
    {
        //Mapper.CreateMap<User, UserDto>();
        public static void Configure()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Address, AddressDto>();
            Mapper.CreateMap<UserMed, UserMedDto>();
            Mapper.CreateMap<UserCondition, UserConditionDto>();
            Mapper.CreateMap<Medicine, MedicineDto>();
            Mapper.CreateMap<Condition, ConditionDto>();
            Mapper.CreateMap<MedType, MedTypeDto>();
        }
        
    }
}