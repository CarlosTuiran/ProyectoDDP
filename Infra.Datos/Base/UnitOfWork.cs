using Domain.Models.Contracts;
using Domain.Models.Repositories;
using Infra.Datos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Datos.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        
        private ISolicitudServiceRepository _solicitudServiceRepository;
        public ISolicitudServiceRepository SolicitudServiceRepository { get { return _solicitudServiceRepository ?? (_solicitudServiceRepository = new SolicitudServiceRepository(_dbContext)); } }

        private IAdminServiceRepository _adminServiceRepository;
        public IAdminServiceRepository AdminServiceRepository { get { return _adminServiceRepository ?? (_adminServiceRepository = new AdminServiceRepository(_dbContext)); } }

        private IEstudianteServiceRepository _estudianteServiceRepository;
        public IEstudianteServiceRepository EstudianteServiceRepository { get { return _estudianteServiceRepository ?? (_estudianteServiceRepository = new EstudianteServiceRepository(_dbContext)); } }

        private IDocenteServiceRepository _docenteServiceRepository;
        public IDocenteServiceRepository DocenteServiceRepository { get { return _docenteServiceRepository ?? (_docenteServiceRepository = new DocenteServiceRepository(_dbContext)); } }

        private IEmpresaServiceRepository _empresaServiceRepository;
        public IEmpresaServiceRepository EmpresaServiceRepository { get { return _empresaServiceRepository ?? (_empresaServiceRepository = new EmpresaServiceRepository(_dbContext)); } }

        private IConvenioServiceRepository _convenioServiceRepository;
        public IConvenioServiceRepository ConvenioServiceRepository { get { return _convenioServiceRepository ?? (_convenioServiceRepository = new ConvenioServiceRepository(_dbContext)); } }
        private IPracticaServiceRepository _practicaServiceRepository;
        public IPracticaServiceRepository PracticaServiceRepository { get { return _practicaServiceRepository ?? (_practicaServiceRepository = new PracticaServiceRepository(_dbContext)); } }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
