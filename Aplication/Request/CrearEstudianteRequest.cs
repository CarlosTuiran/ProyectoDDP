using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearEstudianteRequest
    {
        public int DocIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Carrera { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }

    }
    public class CrearEstudianteResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Estudiante Creado Exitosamente");
        }
    }
}
