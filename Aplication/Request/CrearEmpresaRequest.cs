using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearEmpresaRequest
    {
        public int Nit { get; set; }
        public string NombresRepresentante { get; set; }
        public string ApellidosRepresentante { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }

    public class CrearEmpresaResponse
    {
        public string Message { get; set; }
    }
}
