using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services
{
    public class CrearEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearEstudianteResponse Ejecutar(CrearEstudianteRequest request)
        {
            var estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.DocIdentidad == request.DocIdentidad);
            if (estudiante == null)
            {
                Estudiante newEstudiante = new Estudiante(request.DocIdentidad, request.Email, request.Nombres, request.Apellidos, request.Carrera,
                    request.Direccion, request.Departamento, request.Ciudad, request.Celular, request.Telefono);
                IReadOnlyList<string> errors = newEstudiante.CanCrear(newEstudiante);
                if (errors.Any())
                {
                    string listaErrors="Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearEstudianteResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.EstudianteServiceRepository.Add(newEstudiante);
                    _unitOfWork.Commit();
                    return new CrearEstudianteResponse() { Message = $"Estudiante Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearEstudianteResponse() { Message = $"Estudiante ya existe" };
            }
        }
    }
}
