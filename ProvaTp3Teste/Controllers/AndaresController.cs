using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaTp3Teste.Model;

namespace ProvaTp3Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AndaresController : ControllerBase
    {
        private readonly AgendamentoDbContext _context;

        public AndaresController(AgendamentoDbContext context)
        {
            _context = context;
        }

        // GET: api/Andares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Andar>>> GetAndares()
        {
            return await _context.Andares.ToListAsync();
        }

        // GET: api/Andares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Andar>> GetAndar(int id)
        {
            var andar = await _context.Andares.FindAsync(id);

            if (andar == null)
            {
                return NotFound();
            }

            return andar;
        }

        // PUT: api/Andares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAndar(int id, Andar andar)
        {
            if (id != andar.Id)
            {
                return BadRequest();
            }

            _context.Entry(andar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AndarExists(id))
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

        // POST: api/Andares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Andar>> PostAndar(Andar andar)
        {
            _context.Andares.Add(andar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAndar", new { id = andar.Id }, andar);
        }

        // DELETE: api/Andares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAndar(int id)
        {
            var andar = await _context.Andares.FindAsync(id);
            if (andar == null)
            {
                return NotFound();
            }

            _context.Andares.Remove(andar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AndarExists(int id)
        {
            return _context.Andares.Any(e => e.Id == id);
        }
    }
}
