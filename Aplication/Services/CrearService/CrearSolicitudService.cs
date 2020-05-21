using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services
{
    public class CrearSolicitudService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearSolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearSolicitudResponse Ejecutar(CrearSolicitudRequest request)
        {
            //Comprovar el estado del estudiante o empresa para ver si pueden solicitar
            if (string.IsNullOrEmpty(request.Tipo_Solicitante))
            {
                return new CrearSolicitudResponse() { Message = "Campo Tipo_Solicitante vacio" };                
            }
            bool comprovarEstado;
            if (request.Tipo_Solicitante.Equals("Estudiante"))
            {
                var solicitante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.DocIdentidad == request.ID_Solicitante);
                if (solicitante == null)
                {
                    return new CrearSolicitudResponse() { Message = "Solicitante no Encontrado" };
                }
                comprovarEstado = this.ComprovarEstadoSolicitante(solicitante.Estado);
            }
            else
            {
                 var solicitante = _unitOfWork.EmpresaServiceRepository.FindFirstOrDefault(t => t.Nit == request.ID_Solicitante);
                if (solicitante == null)
                {
                    return new CrearSolicitudResponse() { Message = "Solicitante no Encontrado" };
                }
                comprovarEstado = this.ComprovarEstadoSolicitante(solicitante.Estado);

            }
            
            if (comprovarEstado)
            {
                Solicitud newSolicitud = new Solicitud(request.Tipo, request.Fecha, request.ID_Solicitante, request.Tipo_Solicitante, request.Estado);
                var errors = newSolicitud.CanCrear();
                if (errors.Any())
                    return new CrearSolicitudResponse() { Message = errors[0] };
                _unitOfWork.SolicitudServiceRepository.Add(newSolicitud);
                _unitOfWork.Commit();
                return new CrearSolicitudResponse() { Message = $"Solicitud Creada Exitosamente" };

            }
            else
            {
                return new CrearSolicitudResponse() { Message = $"Tu Estado no permite enviar solicitudes" };
            }
        }
        public bool ComprovarEstadoSolicitante(string estado)
        {
            if (estado.Equals("Activo"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
