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
    public class PostularsController : ControllerBase
    {
        private readonly DataContext _context;

        public PostularsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Postulars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postular>>> GetPostular()
        {
          if (_context.Postular == null)
          {
              return NotFound();
          }
            return await _context.Postular.ToListAsync();
        }

        // GET: api/Postulars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postular>> GetPostular(int id)
        {
          if (_context.Postular == null)
          {
              return NotFound();
          }
            var postular = await _context.Postular.FindAsync(id);

            if (postular == null)
            {
                return NotFound();
            }

            return postular;
        }

        // PUT: api/Postulars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostular(int id, Postular postular)
        {
            if (id != postular.Id)
            {
                return BadRequest();
            }

            _context.Entry(postular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostularExists(id))
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

        // POST: api/Postulars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Postular>> PostPostular(Postular postular)
        {
          if (_context.Postular == null)
          {
              return Problem("Entity set 'DataContext.Postular'  is null.");
          }
            _context.Postular.Add(postular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostular", new { id = postular.Id }, postular);
        }

        // DELETE: api/Postulars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostular(int id)
        {
            if (_context.Postular == null)
            {
                return NotFound();
            }
            var postular = await _context.Postular.FindAsync(id);
            if (postular == null)
            {
                return NotFound();
            }

            _context.Postular.Remove(postular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostularExists(int id)
        {
            return (_context.Postular?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
