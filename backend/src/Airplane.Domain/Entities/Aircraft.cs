using Airplane.Domain.Core.Models;
using System.Collections.Generic;

namespace Airplane.Domain.Entities
{
    public class Aircraft : Entity
    {
        public string Codigo { get; set; }

        public string Modelo { get; set; }

        public int Passageiros { get; set; }
    }
}
