using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services
{
   public  class CrearDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearDocenteResponse Ejecutar(CrearDocenteRequest request)
        {
            var admin = _unitOfWork.DocenteServiceRepository.FindFirstOrDefault(t => t.Cedula == request.Cedula);
            if (admin == null)
            {
                Docente newDocente = new Docente(request.Cedula, request.Nombres, request.Apellidos, request.Email, request.Estado);
                var errors = newDocente.CanCrear();
                if (errors.Any())
                    return new CrearDocenteResponse() { Message = errors[0] };
                _unitOfWork.DocenteServiceRepository.Add(newDocente);
                _unitOfWork.Commit();
                return new CrearDocenteResponse() { Message = $"Docente Creado Exitosamente" };

            }
            else
            {
                return new CrearDocenteResponse() { Message = $"Docente ya existe" };
            }
        }
    }
}
