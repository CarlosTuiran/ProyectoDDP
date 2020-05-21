using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services
{
    public class CrearEmpresaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEmpresaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearEmpresaResponse Ejecutar(CrearEmpresaRequest request)
        {
            var empresa = _unitOfWork.EmpresaServiceRepository.FindFirstOrDefault(t => t.Nit == request.Nit);
            if (empresa == null)
            {
                Empresa newEmpresa = new Empresa(request.Nit, request.NombresRepresentante, request.ApellidosRepresentante, request.Email, request.Estado);
                var errors = newEmpresa.CanCrear();
                if (errors.Any())
                    return new CrearEmpresaResponse() { Message = errors[0] };
                _unitOfWork.EmpresaServiceRepository.Add(newEmpresa);
                _unitOfWork.Commit();
                return new CrearEmpresaResponse() { Message = $"Empresa Creada Exitosamente" };

            }
            else
            {
                return new CrearEmpresaResponse() { Message = $"Empresa ya existe" };
            }
        }
    }
}
