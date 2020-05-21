using Domain.Models.Base;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Solicitud : Entity<int>, ISolicitud
    {
        //public int id { get; set; }
        [Required]
        public string Tipo { get; set; } 
        public DateTime Fecha { get; set; }
        public int ID_Solicitante { get; set; }
        public string Tipo_Solicitante { get; set; }
        public string Estado;
        public Solicitud()
        {

        }
        public Solicitud( string tipo, DateTime fecha, int iD_Solicitante, string tipo_Solicitante, string estado)
        {
            
            Tipo = tipo;
            Fecha = fecha;
            ID_Solicitante = iD_Solicitante;
            Tipo_Solicitante = tipo_Solicitante;
            Estado = estado;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (this.Fecha == DateTime.MinValue)
                errors.Add("Campo Fecha vacio");
            if (this.ID_Solicitante == 0)
                errors.Add("Campo ID_Solicitante vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            if (string.IsNullOrEmpty(this.Tipo_Solicitante))
                errors.Add("Campo Tipo_Solicitante vacio");
            if (!this.Tipo_Solicitante.Equals("Estudiante") && !this.Tipo_Solicitante.Equals("Empresa"))
                errors.Add("Tipo Solicitante Incorrecto");
            if (string.IsNullOrEmpty(this.Tipo))
                errors.Add("Campo Tipo vacio");
            return errors;
        }
    }
}
