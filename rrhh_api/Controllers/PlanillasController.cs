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
    public class PlanillasController : ControllerBase
    {
        private readonly RrhhAdminContext _context;

        public PlanillasController(RrhhAdminContext context)
        {
            _context = context;
        }

        // GET: api/Planillas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planilla>>> GetPlanillas()
        {
            return await _context.Planillas.ToListAsync();
        }

        // GET: api/Planillas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planilla>> GetPlanilla(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);

            if (planilla == null)
            {
                return NotFound();
            }

            return planilla;
        }

        // PUT: api/Planillas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanilla(int id, Planilla planilla)
        {
            if (id != planilla.NumeroPlanilla)
            {
                return BadRequest();
            }

            _context.Entry(planilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanillaExists(id))
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

        // POST: api/Planillas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planilla>> PostPlanilla(Planilla planilla)
        {
            _context.Planillas.Add(planilla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlanillaExists(planilla.NumeroPlanilla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlanilla", new { id = planilla.NumeroPlanilla }, planilla);
        }

        // DELETE: api/Planillas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanilla(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla == null)
            {
                return NotFound();
            }

            _context.Planillas.Remove(planilla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanillaExists(int id)
        {
            return _context.Planillas.Any(e => e.NumeroPlanilla == id);
        }
    }
}
