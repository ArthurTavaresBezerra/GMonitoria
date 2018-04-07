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
    [Route("api/Vaga")]
    public class VagaController : Controller
    {
        private readonly GMonitoriaContext _context;

        public VagaController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Vaga
        [HttpGet]
        public IEnumerable<Vaga> GetVaga()
        {
            return _context.Vaga;
        }

        // GET: api/Vaga/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaga([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vaga = await _context.Vaga.SingleOrDefaultAsync(m => m.VagaId == id);

            if (vaga == null)
            {
                return NotFound();
            }

            return Ok(vaga);
        }

        // PUT: api/Vaga/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaga([FromRoute] string id, [FromBody] Vaga vaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaga.VagaId)
            {
                return BadRequest();
            }

            _context.Entry(vaga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(id))
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

        // POST: api/Vaga
        [HttpPost]
        public async Task<IActionResult> PostVaga([FromBody] Vaga vaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vaga.Add(vaga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaga", new { id = vaga.VagaId }, vaga);
        }

        // DELETE: api/Vaga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaga([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vaga = await _context.Vaga.SingleOrDefaultAsync(m => m.VagaId == id);
            if (vaga == null)
            {
                return NotFound();
            }

            _context.Vaga.Remove(vaga);
            await _context.SaveChangesAsync();

            return Ok(vaga);
        }

        private bool VagaExists(string id)
        {
            return _context.Vaga.Any(e => e.VagaId == id);
        }
    }
}