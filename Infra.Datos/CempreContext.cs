using Domain.Models.Entities;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace Infra.Datos
{
    public class CempreContext : DbContextBase
    {
        public CempreContext(DbContextOptions options) : base(options)
        {
        }
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost; database=cempredb;uid=acceso;pwd=acceso;");
        }*/
        public DbSet<Admin> Admin{get; set;}
        public DbSet<Docente> Docente{get; set;}
        public DbSet<Estudiante> Estudiante{get; set;}
        public DbSet<Empresa> Empresa{get; set;}
        public DbSet<Solicitud> Solicitud{get; set;}
        public DbSet<Practica> Practica{get; set;}
        public DbSet<Convenio> Convenio { get; set; }

    }
}
