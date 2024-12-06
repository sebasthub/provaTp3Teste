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
    public class BlocosController : ControllerBase
    {
        private readonly AgendamentoDbContext _context;

        public BlocosController(AgendamentoDbContext context)
        {
            _context = context;
        }

        // GET: api/Blocos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bloco>>> GetBlocos()
        {
            return await _context.Blocos.ToListAsync();
        }

        // GET: api/Blocos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bloco>> GetBloco(int id)
        {
            var bloco = await _context.Blocos.FindAsync(id);

            if (bloco == null)
            {
                return NotFound();
            }

            return bloco;
        }

        // PUT: api/Blocos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloco(int id, Bloco bloco)
        {
            if (id != bloco.Id)
            {
                return BadRequest();
            }

            _context.Entry(bloco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlocoExists(id))
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

        // POST: api/Blocos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bloco>> PostBloco(Bloco bloco)
        {
            _context.Blocos.Add(bloco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloco", new { id = bloco.Id }, bloco);
        }

        // DELETE: api/Blocos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloco(int id)
        {
            var bloco = await _context.Blocos.FindAsync(id);
            if (bloco == null)
            {
                return NotFound();
            }

            _context.Blocos.Remove(bloco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlocoExists(int id)
        {
            return _context.Blocos.Any(e => e.Id == id);
        }
    }
}
