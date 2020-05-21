using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities.HojadeVida
{
    public class PlanLaboral
    {
        public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cargo { get; set; }
        public string Funciones { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


    }
}
