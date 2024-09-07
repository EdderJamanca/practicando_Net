using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostulacionAPI;
using PostulacionAPI.Data;

namespace PostulacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoesController : ControllerBase
    {
        private readonly DataContext _context;

        public TrabajoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Trabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajo()
        {
          if (_context.Trabajo == null)
          {
              return NotFound();
          }
            return await _context.Trabajo.ToListAsync();
        }

        // GET: api/Trabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajo(int id)
        {
          if (_context.Trabajo == null)
          {
              return NotFound();
          }
            var trabajo = await _context.Trabajo.FindAsync(id);

            if (trabajo == null)
            {
                return NotFound();
            }

            return trabajo;
        }

        // PUT: api/Trabajoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajo(int id, Trabajo trabajo)
        {
            if (id != trabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajoExists(id))
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

        // POST: api/Trabajoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajo>> PostTrabajo(Trabajo trabajo)
        {
          if (_context.Trabajo == null)
          {
              return Problem("Entity set 'DataContext.Trabajo'  is null.");
          }
            _context.Trabajo.Add(trabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajo", new { id = trabajo.Id }, trabajo);
        }

        // DELETE: api/Trabajoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajo(int id)
        {
            if (_context.Trabajo == null)
            {
                return NotFound();
            }
            var trabajo = await _context.Trabajo.FindAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            _context.Trabajo.Remove(trabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajoExists(int id)
        {
            return (_context.Trabajo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
