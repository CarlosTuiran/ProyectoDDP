using Aplication.Request;
using Aplication.Services;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aplication.Test
{
    [TestFixture]
    public class CrearSolicitudTest
    {
        CempreContext _context;
        UnitOfWork _unitOfWork;
        CrearSolicitudService serviceS;
        CrearEstudianteService serviceE;
        CrearEmpresaService serviceEmp;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempredb;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<CempreContext>().UseInMemoryDatabase("Cempre").Options;
            _context = new CempreContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        
        //[TestCase(1065, "c@gmail.com", "Carlos A", "Tuiran M", "Admin Creado Exitosamente", TestName ="Crear Admin Correctamente")]
        //chequear estados de estudiante pendiente
        [TestCaseSource("Creations")]
        public void CrearSolicitudEstudiante(CrearSolicitudRequest requestS, CrearEstudianteRequest requestE, string expected)
        {
            serviceE = new CrearEstudianteService(_unitOfWork);
            serviceE.Ejecutar(requestE);
            serviceS = new CrearSolicitudService(_unitOfWork);
            var response = serviceS.Ejecutar(requestS);
            
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> Creations()
        {
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                   ID_Solicitante=2001,
                   Fecha=DateTime.Now,
                   Tipo="Practica Curricular",
                   Tipo_Solicitante="Estudiante",
                   Estado="Pendiente"
                },
                 
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
                    Telefono = 7246666,
                },
                "Solicitud Creada Exitosamente"
            ).SetName("Crear Solicitud Estudiante Correctamente");
            
        }
        [TestCaseSource("CreationsEmp")]
        public void CrearSolicitudEmpresa(CrearSolicitudRequest requestS, CrearEmpresaRequest requestE, string expected)
        {
            serviceEmp = new CrearEmpresaService(_unitOfWork);
            serviceEmp.Ejecutar(requestE);
            serviceS = new CrearSolicitudService(_unitOfWork);
            var response = serviceS.Ejecutar(requestS);

            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsEmp()
        {
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 2201,
                    Fecha = DateTime.Now,
                    Tipo = "Convenio",
                    Tipo_Solicitante = "Empresa",
                    Estado="Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 2201,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Solicitud Creada Exitosamente"
            ).SetName("Crear Solicitud Empresa Correctamente");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    
                    Fecha = DateTime.Now,
                    Tipo = "Convenio",
                    Tipo_Solicitante = "Empresa",
                    Estado = "Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 2231,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Solicitante no Encontrado"
            ).SetName("Crear Solicitud Empresa ID_Solicitante vacio");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 2241,
                    
                    Tipo = "Convenio",
                    Tipo_Solicitante = "Empresa",
                    Estado = "Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 2241,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Campo Fecha vacio"
            ).SetName("Crear Solicitud Empresa Fecha vacio");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 2251,
                    Fecha = DateTime.Now,
                    
                    Tipo_Solicitante = "Empresa",
                    Estado = "Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 2251,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Campo Tipo vacio"
            ).SetName("Crear Solicitud Empresa Tipo vacio");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 2261,
                    Fecha = DateTime.Now,
                    Tipo = "Convenio",

                    Estado = "Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 2261,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Campo Tipo_Solicitante vacio"
            ).SetName("Crear Solicitud Empresa Tipo_Solicitante vacio");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 2661,
                    Fecha = DateTime.Now,
                    Tipo = "Convenio",
                    Tipo_Solicitante="Empresa"
                    
                },

                new CrearEmpresaRequest
                {
                    Nit = 2661,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Campo Estado vacio"
            ).SetName("Crear Solicitud Empresa Estado vacio");
            yield return new TestCaseData(
                new CrearSolicitudRequest
                {
                    ID_Solicitante = 24501,
                    Fecha = DateTime.Now,
                    Tipo = "Convenio",
                    Tipo_Solicitante = "Docente",
                    Estado = "Pendiente"
                },

                new CrearEmpresaRequest
                {
                    Nit = 24501,
                    Email = "c@gmail.com",
                    NombresRepresentante = "Carlos A",
                    ApellidosRepresentante = "Tuiran M",
                    Estado = "Activo"
                }, "Tipo Solicitante Incorrecto"
            ).SetName("Crear Solicitud Tipo Solicitante Incorrecto");
            yield return new TestCaseData(
               new CrearSolicitudRequest
               {
                   ID_Solicitante = 3002,
                   Fecha = DateTime.Now,
                   Tipo = "Convenio",
                   Tipo_Solicitante = "Empresa",
                   Estado = "Pendiente"
               },

               new CrearEmpresaRequest
               {
                   Nit = 3002,
                   Email = "c@gmail.com",
                   NombresRepresentante = "Carlos A",
                   ApellidosRepresentante = "Tuiran M",
                   Estado = "Pendiente"
               }, "Tu Estado no permite enviar solicitudes"
           ).SetName("Crear Solicitud Empresa Pendiente ");

        }

    }
    }