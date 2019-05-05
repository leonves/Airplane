using AutoMapper;
using Airplane.Application.Interfaces;
using Airplane.Application.ViewModels;
using Airplane.Domain.Entities;
using Airplane.Domain.Intefaces;
using Airplane.Infra.CrossCutting.ExceptionHandler.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Airplane.Application.Services
{
    public class AircraftAppService : IAircraftAppService
    {
        private readonly IMapper _mapper;
        private readonly IAircraftRepository _repository;

        public AircraftAppService(IAircraftRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AircraftViewModel Create(AircraftViewModel aircraft)
        {
            try
            {
                var _existingAircraft = _repository.Find(wh => wh.Codigo == aircraft.Codigo);

                if (_existingAircraft != null && !_existingAircraft.IsDeleted)
                    throw new ApiException("Já existe um registro com esse código", HttpStatusCode.Conflict);

                if (_existingAircraft != null && _existingAircraft.IsDeleted)
                {
                    Update(_existingAircraft.Id.ToString(), aircraft);
                    return _mapper.Map<AircraftViewModel>(_existingAircraft);
                }
                else
                {
                    var _airplane = _repository.Create(_mapper.Map<Aircraft>(aircraft));
                    return _mapper.Map<AircraftViewModel>(_airplane);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _parsedId))
                    throw new ApiException("O Id especificado é inválido", HttpStatusCode.BadRequest);

                var _aircraft = _repository.Find(wh => wh.Id == _parsedId);

                if (_aircraft == null)
                    throw new ApiException("Avião não encontrado", HttpStatusCode.NotFound);

                _repository.Delete(_aircraft);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AircraftViewModel> Get()
        {
            try
            {

                var _aircraft = _repository.Query(wh => !wh.IsDeleted).ToList();
                return _mapper.Map<List<AircraftViewModel>>(_aircraft).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AircraftViewModel Get(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _parsedId))
                    throw new ApiException("O Id especificado é inválido", HttpStatusCode.BadRequest);

                var _aircraft = _repository.Find(wh => !wh.IsDeleted && wh.Id == _parsedId);
                return _mapper.Map<AircraftViewModel>(_aircraft);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(string id, AircraftViewModel airplaneToUpdate)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _parsedId))
                    throw new ApiException("O Id especificado é inválido", HttpStatusCode.BadRequest);

                var _existingAircraft = _repository.Find(wh => !wh.IsDeleted && wh.Id == _parsedId);

                if (_existingAircraft == null)
                    throw new ApiException("Avião não encontrado", HttpStatusCode.NotFound);

                //necessário para mapear
                airplaneToUpdate.Id = id;
                _existingAircraft.IsDeleted = false;

                _repository.Update(_mapper.Map(airplaneToUpdate, _existingAircraft));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
