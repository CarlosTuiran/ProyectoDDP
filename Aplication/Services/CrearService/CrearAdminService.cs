using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Aplication.Services
{
    public class CrearAdminService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public CrearAdminResponse Ejecutar(CrearAdminRequest request)
        {
            var admin = _unitOfWork.AdminServiceRepository.FindFirstOrDefault(t => t.Cedula == request.Cedula);
            if (admin ==null)
            {
                Admin newAdmin = new Admin(request.Cedula, request.Email, request.Nombres, request.Apellidos);
                var errors =newAdmin.CanCrear();
                if (errors.Any())
                    return new CrearAdminResponse() { Message = errors[0] };
                _unitOfWork.AdminServiceRepository.Add(newAdmin);
                _unitOfWork.Commit();
                return new CrearAdminResponse() { Message = $"Admin Creado Exitosamente" };

            }
            else
            {
                return new CrearAdminResponse() { Message = $"Admin ya existe" };
            }
        } 
    }
}
