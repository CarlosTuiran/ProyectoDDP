using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Request;
using Aplication.Services;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
namespace Aplication.Test
{
    class CrearDocenteTest
    {
        CempreContext _context;
        UnitOfWork _unitOfWork;
        CrearDocenteService service;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempredb;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<CempreContext>().UseInMemoryDatabase("Cempre").Options;
            _context = new CempreContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void CrearDocente(CrearDocenteRequest request, string expected)
        {
            service = new CrearDocenteService(_unitOfWork);
            var response = service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> Creations()
        {
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2001,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Estado="Pendiendte"                    
                },
                "Docente Creado Exitosamente"
            ).SetName("Crear Docente Correctamente");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2001,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Docente ya existe"
            ).SetName("Crear Docente Duplicado");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2031,
                    Email = "c@gmail.com",
                    
                    Apellidos = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo Nombres vacio"
            ).SetName("Crear Docente Nombre Vacio");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2021,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    
                    Estado = "Pendiendte"
                },
                "Campo Apellidos vacio"
            ).SetName("Crear Apellidos Nombre Vacio");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo Cedula vacio"
            ).SetName("Crear Docente Cedula Vacio");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2061,
                    
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo Email vacio"
            ).SetName("Crear Docente Email Vacio");
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    Cedula = 2071,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    
                },
                "Campo Estado vacio"
            ).SetName("Crear Docente Estado Vacio");
        }
        }
}
