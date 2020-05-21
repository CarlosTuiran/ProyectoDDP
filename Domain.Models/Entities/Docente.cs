using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Docente : Entity<int>
    {

        //public int id { get; set; }
        [Required]
        public int Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }

        public Docente(int cedula, string nombres, string apellidos, string email, string estado )
        {
            
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
            Email = email;
            Estado = estado;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Nombres))
                errors.Add("Campo Nombres vacio");
            if (string.IsNullOrEmpty(this.Apellidos))
                errors.Add("Campo Apellidos vacio");
            if (this.Cedula == 0)
                errors.Add("Campo Cedula vacio");
            if (string.IsNullOrEmpty(this.Email))
                errors.Add("Campo Email vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            return errors;
        }
    }
}
