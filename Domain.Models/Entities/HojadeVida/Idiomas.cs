using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities.HojadeVida
{
    public class Idiomas
    {
        public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public string Idioma { get; set; }
        public string Escritura {get; set;}
        public string Habla {get; set;}
        public string Lectura {get; set;}
        public string Escucha {get; set;}

        //niveles
        private const string Alto = "Alto";
        private const string Medio = "Medio";
        private const string Bajo = "Bajo";

        public IReadOnlyList<string> CanRegistrar(string nivel)
        {
            var errors = new List<string>();
            if (nivel.Equals(Alto) || nivel.Equals(Medio) || nivel.Equals(Bajo))
                errors.Add("Nivel Incorrecto o Inexistente");
            return errors;
        }

    }
}
