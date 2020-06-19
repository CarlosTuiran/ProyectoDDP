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
    public class AdminsController : ControllerBase
    {
        private readonly CempreContext _context;
        private CrearAdminService _service;
        private UnitOfWork _unitOfWork;

        public AdminsController(CempreContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAdmis()
        {
            return Ok(_context.Admin.ToListAsync());
        }
        [HttpPost]
        public ActionResult PostAdmin([FromBody] CrearAdminRequest admin)
        {
            _service = new CrearAdminService(_unitOfWork);
            var rta = _service.Ejecutar(admin);
            if (rta.isOk())
                return Ok(rta.Message);
            return BadRequest(rta.Message);
        }
    }
}