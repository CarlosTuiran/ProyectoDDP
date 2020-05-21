using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services
{
    public class CrearConvenioService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearConvenioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearConvenioResponse Ejecutar(CrearConvenioRequest request)
        {
            var empresa = _unitOfWork.EmpresaServiceRepository.FindFirstOrDefault(t => t.Nit == request.ID_Empresa);
            if (empresa == null)
            {
                Convenio newConvenio = new Convenio(request.Fecha, request.ID_Empresa, request.Estado);
                var errors = newConvenio.CanCrear();
                if (errors.Any())
                    return new CrearConvenioResponse() { Message = errors[0] };
                _unitOfWork.ConvenioServiceRepository.Add(newConvenio);
                _unitOfWork.Commit();
                return new CrearConvenioResponse() { Message = $"Convenio Creado Exitosamente" };

            }
            else
            {
                return new CrearConvenioResponse() { Message = $"Convenio ya existe" };
            }
        }
    }
}
