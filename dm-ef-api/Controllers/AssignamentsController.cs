using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dm_ef_api.Models;

namespace dm_ef_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignamentsController : ControllerBase
    {
        private readonly AssignamentContext _context;

        public AssignamentsController(AssignamentContext context)
        {
            _context = context;
        }

        // GET: api/Assignaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignament>>> GetAssignament()
        {
          if (_context.Assignment == null)
          {
              return NotFound();
          }
            return await _context.Assignment.ToListAsync();
        }

        // GET: api/Assignaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignament>> GetAssignament(int id)
        {
          if (_context.Assignment == null)
          {
              return NotFound();
          }
            var assignament = await _context.Assignment.FindAsync(id);

            if (assignament == null)
            {
                return NotFound();
            }

            return assignament;
        }

        // PUT: api/Assignaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignament(int id, Assignament assignament)
        {
            if (id != assignament.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignamentExists(id))
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

        // POST: api/Assignaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assignament>> PostAssignament(Assignament assignament)
        {
          if (_context.Assignment == null)
          {
              return Problem("Entity set 'AssignamentContext.Assignament'  is null.");
          }
            _context.Assignment.Add(assignament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignament", new { id = assignament.Id }, assignament);
        }

        // DELETE: api/Assignaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignament(int id)
        {
            if (_context.Assignment == null)
            {
                return NotFound();
            }
            var assignament = await _context.Assignment.FindAsync(id);
            if (assignament == null)
            {
                return NotFound();
            }

            _context.Assignment.Remove(assignament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignamentExists(int id)
        {
            return (_context.Assignment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
