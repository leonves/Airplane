using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Airplane.Domain.Entities;

namespace Airplane.Application.ViewModels
{
    public class AircraftViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Campo Código é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        public int Passageiros { get; set; }
    }
}
