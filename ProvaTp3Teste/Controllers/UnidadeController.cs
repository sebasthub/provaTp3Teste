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
    public class UnidadeController : ControllerBase
    {
        private readonly AgendamentoDbContext _context;

        public UnidadeController(AgendamentoDbContext context)
        {
            _context = context;
        }

        // GET: api/Unidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unidade>>> GetUnidades()
        {
            return await _context.Unidades.ToListAsync();
        }

        // GET: api/Unidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unidade>> GetUnidade(int id)
        {
            var unidade = await _context.Unidades.FindAsync(id);

            if (unidade == null)
            {
                return NotFound();
            }

            return unidade;
        }

        // PUT: api/Unidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidade(int id, Unidade unidade)
        {
            if (id != unidade.ID)
            {
                return BadRequest();
            }

            _context.Entry(unidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeExists(id))
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

        // POST: api/Unidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Unidade>> PostUnidade(Unidade unidade)
        {
            _context.Unidades.Add(unidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidade", new { id = unidade.ID }, unidade);
        }

        // DELETE: api/Unidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidade(int id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }

            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeExists(int id)
        {
            return _context.Unidades.Any(e => e.ID == id);
        }
    }
}
