using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Services
{
    public class CambiarEstadoSolicitudService
    {
        readonly IUnitOfWork _unitOfWork;

        public CambiarEstadoSolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CambiarEstadoResponse Ejecutar( CambiarEstadoRequest request)
        {
            Solicitud solicitud = _unitOfWork.SolicitudServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (solicitud == null)
            {
                return new CambiarEstadoResponse() { Message = $"Solicitud no existe" };
            }
            else
            {
                if (solicitud.Estado.Equals(request.Estado))
                {
                    return new CambiarEstadoResponse() { Message = $"Solicitud ya posee el estado {request.Estado}" };
                }
                else
                {
                    solicitud.Estado = request.Estado;
                    _unitOfWork.SolicitudServiceRepository.Edit(solicitud);
                    _unitOfWork.Commit();
                    return new CambiarEstadoResponse() { Message = $"Solicitud actualizada Exitosamente" };
                }
                

            }
        }

    }
}
