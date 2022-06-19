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
    public class PaquetesController : ControllerBase
    {
        private readonly DataContext _context;
        private DbSet<Paquete> _dbSet;       
        public PaquetesController(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<Paquete>();
        }

        // GET: api/Paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetes()
        {
            return await _context.Paquetes.ToListAsync();
        }

        // GET: api/Paquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paquete>> GetPaquete(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);

            if (paquete == null)
            {
                return NotFound();
            }

            return paquete;
        }

        // PUT: api/Paquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaqueteComprobacion(int id, Paquete paquete, int CiudadUsuario)
        {
            
            var clientes = _context.Clientes.Find(paquete.ClienteId);
            if (clientes.CuidadId == CiudadUsuario)
            {
                if (id != paquete.ID)
                {
                    return BadRequest();
                }

                _context.Entry(paquete).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteExists(id))
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
            else
            {
                return BadRequest("EL USUARIO NO TIENE PERMISO PARA ENTREGAR ESTE PEDIDO");
            }            
        }

        // POST: api/Paquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paquete>> PostPaquete(Paquete paquete)
        {
            _context.Paquetes.Add(paquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaquete", new { id = paquete.ID }, paquete);
        }

        // DELETE: api/Paquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaquete(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }

            _context.Paquetes.Remove(paquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaqueteExists(int id)
        {
            return _context.Paquetes.Any(e => e.ID == id);
        }
    }
}
