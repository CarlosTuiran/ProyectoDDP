using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services.CrearService
{
    public class CrearPracticaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearPracticaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearPracticaResponse Ejecutar(CrearPracticaRequest request)
        {
            var admin = _unitOfWork.PracticaServiceRepository.FindFirstOrDefault(t => t.IdEstudiante == request.IdEstudiante);
            if (admin == null)
            {
                Practica newPractica = new Practica(request.IdEstudiante, request.IdDocente, request.IdEmpresa, request.Descripcion, request.Estado);
                var errors = newPractica.CanCrear();
                if (errors.Any())
                    return new CrearPracticaResponse() { Message = errors[0] };
                _unitOfWork.PracticaServiceRepository.Add(newPractica);
                _unitOfWork.Commit();
                return new CrearPracticaResponse() { Message = $"Practica Creada Exitosamente" };

            }
            else
            {
                return new CrearPracticaResponse() { Message = $"Practica ya existe" };
            }
        }
    }
}
