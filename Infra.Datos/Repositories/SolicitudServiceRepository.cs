using Domain.Models.Contracts;
using Domain.Models.Entities;
using Domain.Models.Repositories;
using Infra.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Repositories
{
    public class SolicitudServiceRepository : GenericRepository<Solicitud>, ISolicitudServiceRepository
    {
        public SolicitudServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
