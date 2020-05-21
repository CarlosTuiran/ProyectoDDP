using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities.HojadeVida
{
   public  class Honores
    {
        public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public string Distincio { get; set; }
        public string Institucion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
