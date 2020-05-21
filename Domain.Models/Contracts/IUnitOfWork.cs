using Domain.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ISolicitudServiceRepository SolicitudServiceRepository { get; }
        IAdminServiceRepository AdminServiceRepository { get; }
        IEstudianteServiceRepository EstudianteServiceRepository { get; }
        IDocenteServiceRepository DocenteServiceRepository { get; }
        IEmpresaServiceRepository EmpresaServiceRepository { get; }
        IConvenioServiceRepository ConvenioServiceRepository { get; }
        IPracticaServiceRepository PracticaServiceRepository { get; }
        int Commit();
    }
}
