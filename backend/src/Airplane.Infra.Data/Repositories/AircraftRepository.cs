using Airplane.Domain.Entities;
using Airplane.Domain.Intefaces;
using Airplane.Infra.Data.Context;

namespace Airplane.Infra.Data.Repositories
{
    public class AircraftRepository : Repository<Aircraft>, IAircraftRepository
    {
        public AircraftRepository(AirplaneContext context)
            : base(context)
        {

        }

        public Aircraft Get(string codigo)
        {
            return Find(wh => wh.Codigo == codigo);
        }
    }
}
