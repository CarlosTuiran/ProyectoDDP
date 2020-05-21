using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Practica : Entity<int>
    {
        //public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public int IdDocente { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public double PrimerCorte { get; set; }
        public double SegundoCorte { get; set; }
        public double TercerCorte { get; set; }
        public double Definitiva { get => ((PrimerCorte * 0.3) + (SegundoCorte * 0.3) + (TercerCorte * 0.4)); }
        public string Observacion { get; set; }

        private const double NotaMin = 0;
        private const double NotaMax = 5;

        public Practica(int idEstudiante, int idDocente, int idEmpresa, string descripcion, string estado)
        {
            IdEstudiante = idEstudiante;
            IdDocente = idDocente;
            IdEmpresa = idEmpresa;
            Descripcion = descripcion;
            Estado = estado;
        }

        public IReadOnlyList<string> CanCalificar(double nota)
        {
            var errors = new List<string>();
            if (nota < NotaMin || nota > NotaMax)
                errors.Add("Valor Incorrecto se sale del limite de calificacion");               
            return errors;
        }
        public IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();
            if (this.IdDocente == 0)
                errors.Add("Campo IdDocente vacio");
            if (this.IdEmpresa == 0)
                errors.Add("Campo IdEmpresa vacio");
            if (this.IdEstudiante == 0)
                errors.Add("Campo IdEstudiante vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            return errors;
        }

    }
}
