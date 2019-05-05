using Airplane.Application.Interfaces;
using Airplane.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Airplane.Services.Host.Controllers
{
    [AllowAnonymous, Route("[controller]"), ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftAppService _service;

        public AircraftController(IAircraftAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(AircraftViewModel airplane)
        {
            try
            {
                var _result = _service.Create(airplane);
                return Created(string.Empty, _result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]AircraftViewModel airplane)
        {
            try
            {
                _service.Update(id, airplane);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _result = _service.Get();
                return Ok(_result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var _result = _service.Get(id);
                return Ok(_result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}

