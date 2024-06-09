using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rrhh_api.Models;

namespace rrhh_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenVentasController : ControllerBase
    {
        private readonly RrhhAdminContext _context;

        public OrdenVentasController(RrhhAdminContext context)
        {
            _context = context;
        }

        // GET: api/OrdenVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenVenta>>> GetOrdenVenta()
        {
            return await _context.OrdenVenta.ToListAsync();
        }

        // GET: api/OrdenVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenVenta>> GetOrdenVenta(int id)
        {
            var ordenVenta = await _context.OrdenVenta.FindAsync(id);

            if (ordenVenta == null)
            {
                return NotFound();
            }

            return ordenVenta;
        }

        // PUT: api/OrdenVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenVenta(int id, OrdenVenta ordenVenta)
        {
            if (id != ordenVenta.CodOrdenVenta)
            {
                return BadRequest();
            }

            _context.Entry(ordenVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenVentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdenVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenVenta>> PostOrdenVenta(OrdenVenta ordenVenta)
        {
            _context.OrdenVenta.Add(ordenVenta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdenVentaExists(ordenVenta.CodOrdenVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdenVenta", new { id = ordenVenta.CodOrdenVenta }, ordenVenta);
        }

        // DELETE: api/OrdenVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenVenta(int id)
        {
            var ordenVenta = await _context.OrdenVenta.FindAsync(id);
            if (ordenVenta == null)
            {
                return NotFound();
            }

            _context.OrdenVenta.Remove(ordenVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenVentaExists(int id)
        {
            return _context.OrdenVenta.Any(e => e.CodOrdenVenta == id);
        }
    }
}
