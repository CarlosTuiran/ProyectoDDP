using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearSolicitudRequest
    {
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_Solicitante { get; set; }
        public string Tipo_Solicitante { get; set; }
        public string Estado;
    }

    public class CrearSolicitudResponse
    {
        public string Message { get; set; }
    }
}
