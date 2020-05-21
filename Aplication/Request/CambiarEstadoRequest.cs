using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CambiarEstadoRequest
    {
        public int Id { get; set; }
        public string Estado { get; set; }
    }
    public class CambiarEstadoResponse
    {
        public string Message { get; set; }
    }
}
