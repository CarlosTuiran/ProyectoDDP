using Aplication.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Services.CambiarEstadosService
{
    public class CalificarPracticaService
    {
        readonly IUnitOfWork _unitOfWork;
        private const string PrimerCorte = "PrimerCorte";
        private const string SegundoCorte = "Segundo Corte";
        private const string TercerCorte = "Tercer Corte";

        public CalificarPracticaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CalificarPracticaResponse Ejecutar(CalificarPracticaRequest request)
        {
            Practica practica = _unitOfWork.PracticaServiceRepository.FindFirstOrDefault(t => t.IdEstudiante == request.IdEstudiante);
            if (practica == null)
            {
                return new CalificarPracticaResponse() { Message = $"Practica no existe" };
            }
            else
            {
                var errors = practica.CanCalificar(request.Nota);
                if (errors.Any())
                    return new CalificarPracticaResponse() { Message = errors.ToString() };

                if (request.Corte.Equals(PrimerCorte))
                {
                    practica.PrimerCorte = request.Nota;
                }
                else
                {
                    if (request.Corte.Equals(SegundoCorte))
                    {
                        practica.SegundoCorte = request.Nota;
                    }
                    else
                    {
                        if (request.Corte.Equals(TercerCorte))
                        {
                            practica.TercerCorte = request.Nota;
                        }
                        else
                        {
                            return new CalificarPracticaResponse() { Message = $"Corte no existe" };
                        }

                    }
                }
                _unitOfWork.PracticaServiceRepository.Edit(practica);
                _unitOfWork.Commit();
                return new CalificarPracticaResponse() { Message = $"Practica Calificada Exitosamente" };
            }
        }
    }
}
