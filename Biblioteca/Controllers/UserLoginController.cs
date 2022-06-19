using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<UserLogin> _userManager;

        public UserLoginController(DataContext context, UserManager<UserLogin> userManager)
        {
            _context = context;            
            userManager = _userManager;
        }


        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogin()
        {
            return await _context.Userlogin.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(int id)
        {
            var user = await _context.Userlogin.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (    id != userLogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogin(UserLogin user)
        {
            _context.Userlogin.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLogin", new { id = user.Id }, user);
        }

        // DELETE: api/Barrios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarrio(int id)
        {
            var usuario = await _context.Userlogin.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Userlogin.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginExists(int id)
        {
            return _context.Userlogin.Any(e => e.Id == id);
        }        
    }
}
