using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearConvenioRequest
    {
        public DateTime Fecha { get; set; }
        public int ID_Empresa { get; set; }
        public string Estado { get; set; }
    }

    public class CrearConvenioResponse
    {
        public string Message { get; set; }
    }
}
