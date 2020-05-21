using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class EmpresaServiceRepository : GenericRepository<Empresa>, IEmpresaServiceRepository
    {
        public EmpresaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
