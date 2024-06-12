using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rrhh_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rrhh_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {

        private readonly RrhhAdminContext _context;

        public CatalogosController(RrhhAdminContext context)
        {
            _context = context;
        }

        [HttpGet("TipoSN")]
        public async Task<ActionResult<IEnumerable<TipoSn>>> GetTipoSN()
        {
            return await _context.TipoSns.ToListAsync();
        }
        [HttpGet("Familia")]
        public async Task<ActionResult<IEnumerable<Famila>>> GetFamilia()
        {
            return await _context.Familia.ToListAsync();
        }

        [HttpGet("Puesto")]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuesto()
        {
            return await _context.Puestos.ToListAsync();
        }
        [HttpGet("Departamento")]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamento()
        {
            return await _context.Departamentos.ToListAsync();
        }
        [HttpGet("TipoDocumento")]
        public async Task<ActionResult<IEnumerable<TipoDocumentoVenta>>> GetTipoDocumento()
        {
            return await _context.TipoDocumentoVenta.ToListAsync();
        }

        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
        [HttpGet("Horarios")]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }
    }
}
