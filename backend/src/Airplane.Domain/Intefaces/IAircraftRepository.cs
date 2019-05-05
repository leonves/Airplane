using Airplane.Domain.Entities;

namespace Airplane.Domain.Intefaces
{
    public interface IAircraftRepository : IRepository<Aircraft>
    {
        Aircraft Get(string codigo);
    }
}
