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
    public class HistorialReproduccionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialReproduccionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialReproducciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialReproduccion>>> GetHistorialReproduccion()
        {
            return await _context.HistorialReproducciones.ToListAsync();
        }

        // GET: api/HistorialReproducciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialReproduccion>> GetHistorialReproduccion(int id)
        {
            var historialReproduccion = await _context.HistorialReproducciones.FindAsync(id);

            if (historialReproduccion == null)
            {
                return NotFound();
            }

            return historialReproduccion;
        }

        // PUT: api/HistorialReproducciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialReproduccion(int id, HistorialReproduccion historialReproduccion)
        {
            if (id != historialReproduccion.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(historialReproduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialReproduccionExists(id))
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

        // POST: api/HistorialReproducciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialReproduccion>> PostHistorialReproduccion(HistorialReproduccion historialReproduccion)
        {
            _context.HistorialReproducciones.Add(historialReproduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialReproduccion", new { id = historialReproduccion.Codigo }, historialReproduccion);
        }

        // DELETE: api/HistorialReproducciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialReproduccion(int id)
        {
            var historialReproduccion = await _context.HistorialReproducciones.FindAsync(id);
            if (historialReproduccion == null)
            {
                return NotFound();
            }

            _context.HistorialReproducciones.Remove(historialReproduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialReproduccionExists(int id)
        {
            return _context.HistorialReproducciones.Any(e => e.Codigo == id);
        }
    }
}
