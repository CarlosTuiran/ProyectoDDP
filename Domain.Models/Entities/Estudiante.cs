using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities
{
    public class Estudiante : Entity<int>
    {
        //public int id { get; set; }
        public int Telefono { get; set; }
        [Required]
        public int DocIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Carrera { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int PracticaCurricular { get; set; }
        public int PracticaGrado { get; set; }
        public int Diplomado { get; set; }

        public Estudiante(int docIdentidad, string email,  string  nombres, string apellidos, string carrera,
        string direccion, string departamento, string ciudad, int celular, int telefono )
        {
            DocIdentidad = docIdentidad;
            Email = email;
            Nombres = nombres;
            Apellidos = apellidos;
            Carrera = carrera;
            Direccion = direccion;
            Departamento = departamento;
            Celular = celular;
            Ciudad = ciudad;
            Telefono = telefono;
            Estado = "Activo";
            PracticaCurricular = 0;
            PracticaGrado = 0;
            Diplomado = 0;
        }

        public IReadOnlyList<string> CanCrear(Estudiante estudiante)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Carrera))
            {
                errors.Add("Carrera Invalida");
            }
            else
            {
                if (!estudiante.Carrera.Equals("Administracion de Empresas") && !estudiante.Carrera.Equals("Contaduria Publica") &&
                    !estudiante.Carrera.Equals("Economia") && !estudiante.Carrera.Equals("Comercio Internacional"))            
                    errors.Add("Carrera Invalida");
            }
            if (string.IsNullOrEmpty(this.Nombres))
                errors.Add("Campo Nombres vacio");
            if (string.IsNullOrEmpty(this.Apellidos))
                errors.Add("Campo Apellidos vacio");
            if (this.DocIdentidad == 0)
                errors.Add("Campo DocIdentidad vacio");
            if (string.IsNullOrEmpty(this.Email))
                errors.Add("Campo Email vacio");
            if (string.IsNullOrEmpty(this.Ciudad))
                errors.Add("Campo Ciudad vacio");
            if (string.IsNullOrEmpty(this.Departamento))
                errors.Add("Campo Departamento vacio");
            if (string.IsNullOrEmpty(this.Direccion))
                errors.Add("Campo Direccion vacio");
            if (this.Celular==0)
                errors.Add("Campo Celular vacio");
            return errors;
        }

    }
}
