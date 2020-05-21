using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Request
{
    public class CrearPracticaRequest
    {
        public int IdEstudiante { get; set; }
        public int IdDocente { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public double PrimerCorte { get=>0; }
        public double SegundoCorte {get => 0;}
        public double TercerCorte { get => 0; }
        public double Definitiva { get => ((PrimerCorte * 0.3) + (SegundoCorte * 0.3) + (TercerCorte * 0.4)); }
        public string Observacion { get; set; }
    }
    public class CrearPracticaResponse
    {
        public string Message { get; set; }
    }
}
