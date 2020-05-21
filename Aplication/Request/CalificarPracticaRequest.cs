using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
   public  class CalificarPracticaRequest
    {
        public double Nota { get; set; }
        public string Corte { get; set; }
        public int IdEstudiante { get; set; }
        public int Cedula { get; internal set; }
    }
    public class CalificarPracticaResponse
    {
        public string Message { get; set; }
    }
}
