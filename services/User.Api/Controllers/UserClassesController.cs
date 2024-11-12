using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Api.Models;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClassesController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserClassesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/UserClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClass>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserClass>> GetUserClass(int id)
        {
            var userClass = await _context.Users.FindAsync(id);

            if (userClass == null)
            {
                return NotFound();
            }

            return userClass;
        }

        // PUT: api/UserClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserClass(int id, UserClass userClass)
        {
            //var er = _context.Users.FindAsync(id);
            //if (er == null) { return NotFound(); }

            if (id != userClass.Id)
            {
                return BadRequest();
            }

            //_context.Entry(userClass).State = EntityState.Modified;
            //return Ok();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClassExists(id))
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

        // POST: api/UserClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserClass>> PostUserClass(UserClass userClass)
        {
            _context.Users.Add(userClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserClass", new { id = userClass.Id }, userClass);
        }

        // DELETE: api/UserClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserClass(int id)
        {
            var userClass = await _context.Users.FindAsync(id);
            if (userClass == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserClassExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
