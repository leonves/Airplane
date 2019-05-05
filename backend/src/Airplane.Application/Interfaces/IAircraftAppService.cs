using Airplane.Application.ViewModels;
using System.Collections.Generic;

namespace Airplane.Application.Interfaces
{
    public interface IAircraftAppService
    {
        AircraftViewModel Create(AircraftViewModel aircraft);

        void Update(string id, AircraftViewModel aircraftToUpdate);

        List<AircraftViewModel> Get();

        AircraftViewModel Get(string id);

        void Delete(string id);
        
    }
}
