#nullable disable
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
    public class TamanioPaquetesController : ControllerBase
    {
        private readonly DataContext _context;

        public TamanioPaquetesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TamanioPaquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TamanioPaquete>>> GetTamanioPaquetes()
        {
            return await _context.TamanioPaquetes.ToListAsync();
        }

        // GET: api/TamanioPaquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TamanioPaquete>> GetTamanioPaquete(int id)
        {
            var tamanioPaquete = await _context.TamanioPaquetes.FindAsync(id);

            if (tamanioPaquete == null)
            {
                return NotFound();
            }

            return tamanioPaquete;
        }

        // PUT: api/TamanioPaquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTamanioPaquete(int id, TamanioPaquete tamanioPaquete)
        {
            if (id != tamanioPaquete.ID)
            {
                return BadRequest();
            }

            _context.Entry(tamanioPaquete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamanioPaqueteExists(id))
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

        // POST: api/TamanioPaquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TamanioPaquete>> PostTamanioPaquete(TamanioPaquete tamanioPaquete)
        {
            _context.TamanioPaquetes.Add(tamanioPaquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTamanioPaquete", new { id = tamanioPaquete.ID }, tamanioPaquete);
        }

        // DELETE: api/TamanioPaquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTamanioPaquete(int id)
        {
            var tamanioPaquete = await _context.TamanioPaquetes.FindAsync(id);
            if (tamanioPaquete == null)
            {
                return NotFound();
            }

            _context.TamanioPaquetes.Remove(tamanioPaquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TamanioPaqueteExists(int id)
        {
            return _context.TamanioPaquetes.Any(e => e.ID == id);
        }
    }
}
