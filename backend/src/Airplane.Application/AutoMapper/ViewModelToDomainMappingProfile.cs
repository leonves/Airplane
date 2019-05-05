using AutoMapper;
using Airplane.Application.ViewModels;
using Airplane.Domain.Entities;
using System;
using Airplane.Domain.Core.Models;

namespace Airplane.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EntityViewModel, Entity>()
                .IncludeAllDerived()
                .ForMember(entity => entity.Id,
                    opt => opt.MapFrom(viewModel =>
                        string.IsNullOrEmpty(viewModel.Id)
                            ? Guid.NewGuid()
                            : Guid.Parse(viewModel.Id)));

            CreateMap<AircraftViewModel, Aircraft>();
        }
    }
}
