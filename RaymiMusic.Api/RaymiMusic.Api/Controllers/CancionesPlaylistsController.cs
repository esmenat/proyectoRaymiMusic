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
    public class CancionesPlaylistsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CancionesPlaylistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CancionesPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancionPlaylist>>> GetCancionPlaylist()
        {
            return await _context.CancionesPlaylists.ToListAsync();
        }

        // GET: api/CancionesPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CancionPlaylist>> GetCancionPlaylist(int id)
        {
            var cancionPlaylist = await _context.CancionesPlaylists.FindAsync(id);

            if (cancionPlaylist == null)
            {
                return NotFound();
            }

            return cancionPlaylist;
        }

        // PUT: api/CancionesPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancionPlaylist(int id, CancionPlaylist cancionPlaylist)
        {
            if (id != cancionPlaylist.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(cancionPlaylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionPlaylistExists(id))
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

        // POST: api/CancionesPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CancionPlaylist>> PostCancionPlaylist(CancionPlaylist cancionPlaylist)
        {
            _context.CancionesPlaylists.Add(cancionPlaylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancionPlaylist", new { id = cancionPlaylist.Codigo }, cancionPlaylist);
        }

        // DELETE: api/CancionesPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancionPlaylist(int id)
        {
            var cancionPlaylist = await _context.CancionesPlaylists.FindAsync(id);
            if (cancionPlaylist == null)
            {
                return NotFound();
            }

            _context.CancionesPlaylists.Remove(cancionPlaylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancionPlaylistExists(int id)
        {
            return _context.CancionesPlaylists.Any(e => e.Codigo == id);
        }
    }
}
