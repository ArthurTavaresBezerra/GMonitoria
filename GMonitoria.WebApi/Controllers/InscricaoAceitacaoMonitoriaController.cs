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
    [Route("api/InscricaoAceitacaoMonitoria")]
    public class InscricaoAceitacaoMonitoriaController : Controller
    {
        private readonly GMonitoriaContext _context;

        public InscricaoAceitacaoMonitoriaController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/InscricaoAceitacaoMonitoria
        [HttpGet]
        public IEnumerable<InscricaoAceitacaoMonitoria> GetInscricaoAceitacaoMonitoria()
        {
            return _context.InscricaoAceitacaoMonitoria;
        }

        // GET: api/InscricaoAceitacaoMonitoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscricaoAceitacaoMonitoria([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoAceitacaoMonitoria = await _context.InscricaoAceitacaoMonitoria.SingleOrDefaultAsync(m => m.InscricaoAceitacaoMonitoriaId == id);

            if (inscricaoAceitacaoMonitoria == null)
            {
                return NotFound();
            }

            return Ok(inscricaoAceitacaoMonitoria);
        }

        // PUT: api/InscricaoAceitacaoMonitoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoAceitacaoMonitoria([FromRoute] string id, [FromBody] InscricaoAceitacaoMonitoria inscricaoAceitacaoMonitoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inscricaoAceitacaoMonitoria.InscricaoAceitacaoMonitoriaId)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoAceitacaoMonitoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoAceitacaoMonitoriaExists(id))
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

        // POST: api/InscricaoAceitacaoMonitoria
        [HttpPost]
        public async Task<IActionResult> PostInscricaoAceitacaoMonitoria([FromBody] InscricaoAceitacaoMonitoria inscricaoAceitacaoMonitoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InscricaoAceitacaoMonitoria.Add(inscricaoAceitacaoMonitoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoAceitacaoMonitoria", new { id = inscricaoAceitacaoMonitoria.InscricaoAceitacaoMonitoriaId }, inscricaoAceitacaoMonitoria);
        }

        // DELETE: api/InscricaoAceitacaoMonitoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoAceitacaoMonitoria([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoAceitacaoMonitoria = await _context.InscricaoAceitacaoMonitoria.SingleOrDefaultAsync(m => m.InscricaoAceitacaoMonitoriaId == id);
            if (inscricaoAceitacaoMonitoria == null)
            {
                return NotFound();
            }

            _context.InscricaoAceitacaoMonitoria.Remove(inscricaoAceitacaoMonitoria);
            await _context.SaveChangesAsync();

            return Ok(inscricaoAceitacaoMonitoria);
        }

        private bool InscricaoAceitacaoMonitoriaExists(string id)
        {
            return _context.InscricaoAceitacaoMonitoria.Any(e => e.InscricaoAceitacaoMonitoriaId == id);
        }
    }
}