using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProuductoxesController : ControllerBase
    {
        private readonly ProductdbContext _context;

        public ProuductoxesController(ProductdbContext context)
        {
            _context = context;
        }

        // GET: api/Prouductoxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prouductox>>> GetProuductox()
        {
            return await _context.Prouductox.ToListAsync();
        }

        // GET: api/Prouductoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prouductox>> GetProuductox(int id)
        {
            var prouductox = await _context.Prouductox.FindAsync(id);

            if (prouductox == null)
            {
                return NotFound();
            }

            return prouductox;
        }

        // PUT: api/Prouductoxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProuductox(int id, Prouductox prouductox)
        {
            if (id != prouductox.Id)
            {
                return BadRequest();
            }

            _context.Entry(prouductox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProuductoxExists(id))
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

        // POST: api/Prouductoxes
        [HttpPost]
        public async Task<ActionResult<Prouductox>> PostProuductox(Prouductox prouductox)
        {
            _context.Prouductox.Add(prouductox);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProuductoxExists(prouductox.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProuductox", new { id = prouductox.Id }, prouductox);
        }

        // DELETE: api/Prouductoxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prouductox>> DeleteProuductox(int id)
        {
            var prouductox = await _context.Prouductox.FindAsync(id);
            if (prouductox == null)
            {
                return NotFound();
            }

            _context.Prouductox.Remove(prouductox);
            await _context.SaveChangesAsync();

            return prouductox;
        }

        private bool ProuductoxExists(int id)
        {
            return _context.Prouductox.Any(e => e.Id == id);
        }
    }
}
