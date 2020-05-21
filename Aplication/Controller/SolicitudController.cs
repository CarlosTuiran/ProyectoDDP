using Domain.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Controller
{
    public class SolicitudController
    {
        readonly IUnitOfWork _unitOfWork;
        private const  string _PracticaCurricular="Practica Curricular";
        private const string _PracticaGrado = "Practica Grado";
        private const string _Convenio = "Convenio";
        private const string _Diplomado = "Diplomado";

        public SolicitudController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       /* public string CrearSolicitud(string tipo)
        {
            switch (tipo)
            {
                case _PracticaCurricular:

                    break;
                case _PracticaGrado:
                    break;
                case _Convenio:
                    break;
                case _Diplomado:
                    break;
                default:
                    return "Tipo de Solicitud Invalido";
            }
            
        }*/
    }
}
