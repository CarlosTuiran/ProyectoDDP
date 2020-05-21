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
    class CrearEmpresaTest
    {
        CempreContext _context;
        UnitOfWork _unitOfWork;
        CrearEmpresaService service;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempredb;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<CempreContext>().UseInMemoryDatabase("Cempre").Options;
            _context = new CempreContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void CrearEmpresa(CrearEmpresaRequest request, string expected)
        {
            service = new  CrearEmpresaService(_unitOfWork);
            var response = service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> Creations()
        {
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2001,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado="Pendiendte"                    
                },
                "Empresa Creada Exitosamente"
            ).SetName("Crear Empresa Correctamente");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2001,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Empresa ya existe"
            ).SetName("Crear Empresa duplicado");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo Nit vacio"
            ).SetName("Crear Empresa Nit Vacio");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2061,
                    
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo Email vacio"
            ).SetName("Crear Empresa Email Vacio");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2071,
                    Email = "c@gmail.com",
                    
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Pendiendte"
                },
                "Campo NombresRepresentante vacio"
            ).SetName("Crear Empresa NombresRepresentante vacio");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2081,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    
                    Estado = "Pendiendte"
                },
                "Campo ApellidosRepresentante vacio"
            ).SetName("Crear Empresa ApellidosRepresentante vacio");
            yield return new TestCaseData(
                new CrearEmpresaRequest
                {
                    Nit = 2091,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M"
                    
                },
                "Campo Estado vacio"
            ).SetName("Crear Empresa Estado vacio");
        }
        }
}
