﻿using System;
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
    public class RefreshTokensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RefreshTokensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RefreshTokens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefreshToken>>> GetRefreshToken()
        {
            return await _context.RefreshTokens.ToListAsync();
        }

        // GET: api/RefreshTokens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefreshToken>> GetRefreshToken(int id)
        {
            var refreshToken = await _context.RefreshTokens.FindAsync(id);

            if (refreshToken == null)
            {
                return NotFound();
            }

            return refreshToken;
        }

        // PUT: api/RefreshTokens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefreshToken(int id, RefreshToken refreshToken)
        {
            if (id != refreshToken.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(refreshToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefreshTokenExists(id))
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

        // POST: api/RefreshTokens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RefreshToken>> PostRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefreshToken", new { id = refreshToken.Codigo }, refreshToken);
        }

        // DELETE: api/RefreshTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefreshToken(int id)
        {
            var refreshToken = await _context.RefreshTokens.FindAsync(id);
            if (refreshToken == null)
            {
                return NotFound();
            }

            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefreshTokenExists(int id)
        {
            return _context.RefreshTokens.Any(e => e.Codigo == id);
        }
    }
}
