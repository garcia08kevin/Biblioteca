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
    public class BarriosController : ControllerBase
    {
        private readonly DataContext _context;

        public BarriosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Barrios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barrio>>> GetBarrio()
        {
            return await _context.Barrios.ToListAsync();
        }

        // GET: api/Barrios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barrio>> GetBarrio(int id)
        {
            var barrio = await _context.Barrios.FindAsync(id);

            if (barrio == null)
            {
                return NotFound();
            }

            return barrio;
        }

        // PUT: api/Barrios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarrio(int id, Barrio barrio)
        {
            if (id != barrio.ID)
            {
                return BadRequest();
            }

            _context.Entry(barrio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarrioExists(id))
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

        // POST: api/Barrios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barrio>> PostBarrio(Barrio barrio)
        {
            _context.Barrios.Add(barrio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarrio", new { id = barrio.ID }, barrio);
        }

        // DELETE: api/Barrios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarrio(int id)
        {
            var barrio = await _context.Barrios.FindAsync(id);
            if (barrio == null)
            {
                return NotFound();
            }

            _context.Barrios.Remove(barrio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarrioExists(int id)
        {
            return _context.Barrios.Any(e => e.ID == id);
        }
    }
}
