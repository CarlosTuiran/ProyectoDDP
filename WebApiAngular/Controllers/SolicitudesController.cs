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
    public class SolicitudesController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearSolicitudService _service;
        private UnitOfWork _unitOfWork;

        public SolicitudesController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Solicitud>> GetSolicitudes()
        {
            return Ok(_context.Solicitud.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostEstudiante([FromBody] CrearSolicitudRequest solicitud)
        {
            _service = new CrearSolicitudService(_unitOfWork);
            var rta = _service.Ejecutar(solicitud);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}