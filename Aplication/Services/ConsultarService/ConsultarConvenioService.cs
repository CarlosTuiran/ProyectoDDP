using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Services.ConsultarService
{
    class ConsultarConvenioService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarConvenioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Convenio> Consultar()
        {
            var convenios = _unitOfWork.ConvenioServiceRepository.GetAll();
            return convenios;

        }
        public Convenio Consultar(int id)
        {
            var convenios = _unitOfWork.ConvenioServiceRepository.FindFirstOrDefault(t => t.ID_Empresa == id);
            return convenios;

        }
    }
}
