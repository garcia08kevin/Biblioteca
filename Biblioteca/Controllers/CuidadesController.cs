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
    public class CuidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public CuidadesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Cuidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuidad>>> GetCuidad()
        {
            return await _context.Cuidad.ToListAsync();
        }

        // GET: api/Cuidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuidad>> GetCuidad(int id)
        {
            var cuidad = await _context.Cuidad.FindAsync(id);

            if (cuidad == null)
            {
                return NotFound();
            }

            return cuidad;
        }

        // PUT: api/Cuidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuidad(int id, Cuidad cuidad)
        {
            if (id != cuidad.ID)
            {
                return BadRequest();
            }

            _context.Entry(cuidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuidadExists(id))
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

        // POST: api/Cuidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuidad>> PostCuidad(Cuidad cuidad)
        {
            _context.Cuidad.Add(cuidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuidad", new { id = cuidad.ID }, cuidad);
        }

        // DELETE: api/Cuidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuidad(int id)
        {
            var cuidad = await _context.Cuidad.FindAsync(id);
            if (cuidad == null)
            {
                return NotFound();
            }

            _context.Cuidad.Remove(cuidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuidadExists(int id)
        {
            return _context.Cuidad.Any(e => e.ID == id);
        }
    }
}
