using KodiaMagino.Web.Models.Ventas.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodiaMagino.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly DbContextSistema _context;

        public PersonasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Personas/ListarClientes
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaViewModel>> ListarClientes()
        {
            var persona = await _context.Personas.Where(p=>p.tipo_persona=="Cliente").ToListAsync();

            return persona.Select(p => new PersonaViewModel
            {
                idpersona = p.idpersona,
                tipo_persona = p.tipo_persona,
                nombre = p.nombre,
                tipo_documento = p.tipo_documento,
                num_documento = p.num_documento,
                direccion = p.direccion,
                telefono = p.telefono,
                email = p.email,
            });

        }

        // GET: api/Personas/ListarProveedores
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaViewModel>> ListarProveedores()
        {
            var persona = await _context.Personas.Where(p => p.tipo_persona == "Proveedor").ToListAsync();

            return persona.Select(p => new PersonaViewModel
            {
                idpersona = p.idpersona,
                tipo_persona = p.tipo_persona,
                nombre = p.nombre,
                tipo_documento = p.tipo_documento,
                num_documento = p.num_documento,
                direccion = p.direccion,
                telefono = p.telefono,
                email = p.email,
            });

        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(p => p.idpersona == id);
        }
    }
}
