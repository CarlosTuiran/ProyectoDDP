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
    class CrearEstudianteTest
    {
        CempreContext _context;
        UnitOfWork _unitOfWork;
        CrearEstudianteService service;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempredb;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<CempreContext>().UseInMemoryDatabase("CempreE").Options;
            _context = new CempreContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void CrearEstudiante(CrearEstudianteRequest request, string expected)
        {
            service = new CrearEstudianteService(_unitOfWork);
            var response = service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> Creations()
        {
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2001,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera="Administracion de Empresas",
                    Celular=318416999,
                    Ciudad="Valledupar",
                    Departamento="Cesar",
                    Direccion="Calle xx N 1",
                    Telefono=7246666
                },
                "Estudiante Creado Exitosamente"
            ).SetName("Crear Estudiante Administracion de Empresas Correctamente");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2002,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Contaduria Publica",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Estudiante Creado Exitosamente"
            ).SetName("Crear Estudiante Contaduria Publica Correctamente");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2003,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Comercio Internacional",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Estudiante Creado Exitosamente"
            ).SetName("Crear Estudiante Comercio Internacional Correctamente");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2004,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Economia",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Estudiante Creado Exitosamente"
            ).SetName("Crear Estudiante Economia Correctamente");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2005,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Sistemas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Carrera Invalida"
            ).SetName("Crear Estudiante Carrera Incorrecta");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2001,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Estudiante ya existe"
            ).SetName("Crear Estudiante Duplicado");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo DocIdentidad vacio"
            ).SetName("Crear Estudiante DocIdentidad vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 923001,
                    
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Email vacio"
            ).SetName("Crear Estudiante Email vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 234501,
                    Email = "c@gmail.com",
                    
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Nombres vacio"
            ).SetName("Crear Estudiante Nombres vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 234341,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Apellidos vacio"
            ).SetName("Crear Estudiante Apellidos vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 24441,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Carrera Invalida"
            ).SetName("Crear Estudiante Carrera vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 43301,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Celular vacio"
            ).SetName("Crear Estudiante Celular vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 7801,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    
                    Departamento = "Cesar",
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Ciudad vacio"
            ).SetName("Crear Estudiante Ciudad vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 34001,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    
                    Direccion = "Calle xx N 1",
                    Telefono = 7246666
                },
                "Errores:Campo Departamento vacio"
            ).SetName("Crear Estudiante Departamento vacio");
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    DocIdentidad = 2091,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M",
                    Carrera = "Administracion de Empresas",
                    Celular = 318416999,
                    Ciudad = "Valledupar",
                    Departamento = "Cesar",
                    
                    Telefono = 7246666
                },
                "Errores:Campo Direccion vacio"
            ).SetName("Crear Estudiante Direccion vacio");

        }

    }
}
