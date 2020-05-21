using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Convenio: Entity<int>
    {
        public int id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public int ID_Empresa { get; set; }
        public string Estado { get; set; } 
        public Convenio( DateTime fecha, int iD_Empresa, string estado)
        {
            Fecha = fecha;
            ID_Empresa = iD_Empresa;
            Estado = estado;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (this.Fecha==DateTime.MinValue)
                errors.Add("Campo Fecha vacio");
            if (this.ID_Empresa==0)
                errors.Add("Campo ID_Empresa vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            return errors;
        }
    }
}
