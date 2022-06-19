using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPaquetesController : ControllerBase
    {
        private readonly DataContext _context;

        public EstadoPaquetesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPaquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPaquete>>> GetEstadoPaquetes()
        {
          if (_context.EstadoPaquetes == null)
          {
              return NotFound();
          }
            return await _context.EstadoPaquetes.ToListAsync();
        }

        // GET: api/EstadoPaquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPaquete>> GetEstadoPaquete(int id)
        {
          if (_context.EstadoPaquetes == null)
          {
              return NotFound();
          }
            var estadoPaquete = await _context.EstadoPaquetes.FindAsync(id);

            if (estadoPaquete == null)
            {
                return NotFound();
            }

            return estadoPaquete;
        }

        // PUT: api/EstadoPaquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPaquete(int id, EstadoPaquete estadoPaquete)
        {
            if (id != estadoPaquete.ID)
            {
                return BadRequest();
            }

            _context.Entry(estadoPaquete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPaqueteExists(id))
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

        // POST: api/EstadoPaquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPaquete>> PostEstadoPaquete(EstadoPaquete estadoPaquete)
        {
          if (_context.EstadoPaquetes == null)
          {
              return Problem("Entity set 'DataContext.EstadoPaquetes'  is null.");
          }
            _context.EstadoPaquetes.Add(estadoPaquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPaquete", new { id = estadoPaquete.ID }, estadoPaquete);
        }

        // DELETE: api/EstadoPaquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPaquete(int id)
        {
            if (_context.EstadoPaquetes == null)
            {
                return NotFound();
            }
            var estadoPaquete = await _context.EstadoPaquetes.FindAsync(id);
            if (estadoPaquete == null)
            {
                return NotFound();
            }

            _context.EstadoPaquetes.Remove(estadoPaquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPaqueteExists(int id)
        {
            return (_context.EstadoPaquetes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
