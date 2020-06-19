using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Admin: Entity<int>
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int Cedula { get; set; }
        public string Email { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public Admin(int cedula, string email, string nombres, string apellidos)
        {
            Cedula = cedula;
            Email = email;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Nombres))
                errors.Add("Campo Nombres vacio");
            if (string.IsNullOrEmpty(this.Apellidos))
                errors.Add("Campo Apellidos vacio");
            if (this.Cedula==0)
                errors.Add("Campo Cedula vacio");
            if (string.IsNullOrEmpty(this.Email))
                errors.Add("Campo Email vacio");
            return errors;
        }
    }
}
