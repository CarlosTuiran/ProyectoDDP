using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Empresa : Entity<int>
    {
        //public int id { get; set; }
        [Required]
        public int Nit { get; set; }
        public string NombresRepresentante { get; set; }
        public string ApellidosRepresentante { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }

        public Empresa(int nit, string nombresRepresentante , string apellidosRepresentante, string email, string estado)
        {
            Nit = nit;
            NombresRepresentante = nombresRepresentante;
            ApellidosRepresentante = apellidosRepresentante;
            Email = email;
            Estado = estado;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.NombresRepresentante))
                errors.Add("Campo NombresRepresentante vacio");
            if (string.IsNullOrEmpty(this.ApellidosRepresentante))
                errors.Add("Campo ApellidosRepresentante vacio");
            if (this.Nit == 0)
                errors.Add("Campo Nit vacio");
            if (string.IsNullOrEmpty(this.Email))
                errors.Add("Campo Email vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            return errors;
        }
    }
}
