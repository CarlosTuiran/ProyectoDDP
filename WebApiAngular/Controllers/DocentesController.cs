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
    public class DocentesController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearDocenteService _service;
        private UnitOfWork _unitOfWork;

        public DocentesController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Docente>> GetDocentes()
        {
            return Ok(_context.Docente.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostConvenio([FromBody] CrearDocenteRequest docente)
        {
            _service = new CrearDocenteService(_unitOfWork);
            var rta = _service.Ejecutar(docente);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}