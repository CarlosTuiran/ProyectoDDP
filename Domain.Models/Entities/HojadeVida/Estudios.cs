using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities.HojadeVida
{
    public class Estudios
    {
        public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public string Titulo { get; set; }
        public string Institucion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }


    }
}
