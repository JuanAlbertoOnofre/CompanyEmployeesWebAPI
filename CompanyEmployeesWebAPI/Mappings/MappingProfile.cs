﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmployeesWebAPI.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Company, CompanyDto>()
                    .ForMember(c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join("", x.Address, x.Country)));
        }
    }
}