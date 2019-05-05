using AutoMapper;
using Airplane.Application.ViewModels;
using Airplane.Domain.Core.Models;
using Airplane.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airplane.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Entity, EntityViewModel>()
                .IncludeAllDerived()
                .ForMember(viewModel => viewModel.Id, opt =>
                    opt.MapFrom(entity => entity.Id.ToString()));

            CreateMap<Aircraft, AircraftViewModel>();
        }
    }
}
