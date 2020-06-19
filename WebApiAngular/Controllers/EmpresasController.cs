using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Request;
using Aplication.Services;
using Domain.Models.Entities;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearEmpresaService _service;
        private UnitOfWork _unitOfWork;

        public EmpresasController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empresa>> GetEmpresas()
        {
            return Ok(_context.Empresa.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostConvenio([FromBody] CrearEmpresaRequest empresa)
        {
            _service = new CrearEmpresaService(_unitOfWork);
            var rta = _service.Ejecutar(empresa);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}