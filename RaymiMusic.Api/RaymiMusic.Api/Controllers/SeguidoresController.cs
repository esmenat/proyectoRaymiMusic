using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaymiMusic.Modelos;

namespace RaymiMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguidoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeguidoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Seguidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguidor>>> GetSeguidores()
        {
            return await _context.Seguidores.ToListAsync();
        }

        // GET: api/Seguidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seguidor>> GetSeguidor(int id)
        {
            var seguidor = await _context.Seguidores.FindAsync(id);

            if (seguidor == null)
            {
                return NotFound();
            }

            return seguidor;
        }

        // PUT: api/Seguidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguidor(int id, Seguidor seguidor)
        {
            if (id != seguidor.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(seguidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguidorExists(id))
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

        // POST: api/Seguidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seguidor>> PostSeguidor(Seguidor seguidor)
        {
            _context.Seguidores.Add(seguidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguidor", new { id = seguidor.Codigo }, seguidor);
        }

        // DELETE: api/Seguidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguidor(int id)
        {
            var seguidor = await _context.Seguidores.FindAsync(id);
            if (seguidor == null)
            {
                return NotFound();
            }

            _context.Seguidores.Remove(seguidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguidorExists(int id)
        {
            return _context.Seguidores.Any(e => e.Codigo == id);
        }
    }
}
