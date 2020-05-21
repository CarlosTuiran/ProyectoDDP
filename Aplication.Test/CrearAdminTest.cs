using Aplication.Request;
using Aplication.Services;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Aplication.Test
{
    [TestFixture]
    public class CrearAdminTest
    {
        CempreContext _context;
        UnitOfWork _unitOfWork;
        CrearAdminService service;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<CempreContext>().UseInMemoryDatabase("Cempre").Options;
            _context = new CempreContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        
        //[TestCase(1065, "c@gmail.com", "Carlos A", "Tuiran M", "Admin Creado Exitosamente", TestName ="Crear Admin Correctamente")]
        [TestCaseSource("Creations")]
        public void CrearAdmin(CrearAdminRequest request, string expected)
        {
            service = new CrearAdminService(_unitOfWork);
            var response = service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> Creations()
        {
            yield return new TestCaseData(
                new CrearAdminRequest
                {
                    Cedula = 2165,
                    Email = "c@gmail.com",
                    Nombres = "Carlos A",
                    Apellidos = "Tuiran M"
                },
                "Admin Creado Exitosamente"
            ).SetName("Crear Admin Correctamente");
            yield return new TestCaseData(
                 new CrearAdminRequest
                 {
                     Cedula = 1065,
                     Email = "c@gmail.com",
                     
                     Apellidos = "Tuiran M"
                 },
                 "Campo Nombres vacio"
             ).SetName("Crear Admin Falta Nombre");
             yield return new TestCaseData(
                 new CrearAdminRequest
                 {
                     Cedula = 1065,
                     Email = "c@gmail.com",
                     Nombres = "Carlos A",
                     
                 },
                 "Campo Apellidos vacio"
             ).SetName("Crear Admin Falta Apellidos");
             yield return new TestCaseData(
                 new CrearAdminRequest
                 {
                     
                     Email = "c@gmail.com",
                     Nombres = "Carlos A",
                     Apellidos = "Tuiran M"
                 },
                 "Campo Cedula vacio"
             ).SetName("Crear Admin Falta Cedula");
             yield return new TestCaseData(
                 new CrearAdminRequest
                 {
                     Cedula = 1065,
                     
                     Nombres = "Carlos A",
                     Apellidos = "Tuiran M"
                 },
                 "Campo Email vacio"
             ).SetName("Crear Admin Falta Email");

        }
        [TestCaseSource("CreationsDuplicado")]
        
        public void  CrearAdminDuplicado(CrearAdminRequest request, string expected)
        {
            service = new CrearAdminService(_unitOfWork);
            service.Ejecutar(request);
            var response = service.Ejecutar(request);
            Assert.AreEqual(response.Message, expected);
        }
        private static IEnumerable<TestCaseData> CreationsDuplicado()
        {
            yield return new TestCaseData(
                 new CrearAdminRequest
                 {
                     Cedula = 1065,
                     Email = "c@gmail.com",
                     Nombres = "Carlos A",
                     Apellidos = "Tuiran M"
                 },
                 "Admin ya existe"
             ).SetName("Crear Admin Duplicado");
        }

        
    }
    }