using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Request;
using Aplication.Services;
using Aplication.Services.CrearService;
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
    public class PracticasController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearPracticaService _service;
        private UnitOfWork _unitOfWork;

        public PracticasController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Practica>> GetPracticas()
        {
            return Ok(_context.Practica.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostEstudiante([FromBody] CrearPracticaRequest practica)
        {
            _service = new CrearPracticaService(_unitOfWork);
            var rta = _service.Ejecutar(practica);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}