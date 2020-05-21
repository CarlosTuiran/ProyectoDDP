using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearAdminRequest
    {
        public int Cedula { get; set; }
        public string Email { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
    public class CrearAdminResponse
    {
        public string Message { get; set; }
    }
}
