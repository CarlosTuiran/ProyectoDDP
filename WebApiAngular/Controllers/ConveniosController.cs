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
    public class ConveniosController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearConvenioService _service;
        private UnitOfWork _unitOfWork;

        public ConveniosController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Convenio>> GetConvenios()
        {
            return Ok(_context.Convenio.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostConvenio([FromBody] CrearConvenioRequest convenio)
        {
            _service = new CrearConvenioService(_unitOfWork);
            var rta = _service.Ejecutar(convenio);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}