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
    public class EstudiantesController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearEstudianteService _service;
        private UnitOfWork _unitOfWork;

        public EstudiantesController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes()
        {
            return Ok(_context.Estudiante.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostEstudiante([FromBody] CrearEstudianteRequest estudiante)
        {
            _service = new CrearEstudianteService(_unitOfWork);
            var rta = _service.Ejecutar(estudiante);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}