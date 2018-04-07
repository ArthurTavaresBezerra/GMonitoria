using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMonitoria.Domain.Entities;
using GMonitoria.Infrastructure.Data.Contexts;

namespace GMonitoria.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Prova")]
    public class ProvaController : Controller
    {
        private readonly GMonitoriaContext _context;

        public ProvaController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Prova
        [HttpGet]
        public IEnumerable<Prova> GetProva()
        {
            return _context.Prova;
        }

        // GET: api/Prova/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProva([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prova = await _context.Prova.SingleOrDefaultAsync(m => m.ProvaId == id);

            if (prova == null)
            {
                return NotFound();
            }

            return Ok(prova);
        }

        // PUT: api/Prova/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProva([FromRoute] string id, [FromBody] Prova prova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prova.ProvaId)
            {
                return BadRequest();
            }

            _context.Entry(prova).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvaExists(id))
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

        // POST: api/Prova
        [HttpPost]
        public async Task<IActionResult> PostProva([FromBody] Prova prova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prova.Add(prova);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProva", new { id = prova.ProvaId }, prova);
        }

        // DELETE: api/Prova/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProva([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prova = await _context.Prova.SingleOrDefaultAsync(m => m.ProvaId == id);
            if (prova == null)
            {
                return NotFound();
            }

            _context.Prova.Remove(prova);
            await _context.SaveChangesAsync();

            return Ok(prova);
        }

        private bool ProvaExists(string id)
        {
            return _context.Prova.Any(e => e.ProvaId == id);
        }
    }
}