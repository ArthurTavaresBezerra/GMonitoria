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
    [Route("api/InscricaoResultado")]
    public class InscricaoResultadoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public InscricaoResultadoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/InscricaoResultado
        [HttpGet]
        public IEnumerable<InscricaoResultado> GetInscricaoResultado()
        {
            return _context.InscricaoResultado;
        }

        // GET: api/InscricaoResultado/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscricaoResultado([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoResultado = await _context.InscricaoResultado.SingleOrDefaultAsync(m => m.InscricaoResultadoId == id);

            if (inscricaoResultado == null)
            {
                return NotFound();
            }

            return Ok(inscricaoResultado);
        }

        // PUT: api/InscricaoResultado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoResultado([FromRoute] string id, [FromBody] InscricaoResultado inscricaoResultado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inscricaoResultado.InscricaoResultadoId)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoResultado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoResultadoExists(id))
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

        // POST: api/InscricaoResultado
        [HttpPost]
        public async Task<IActionResult> PostInscricaoResultado([FromBody] InscricaoResultado inscricaoResultado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InscricaoResultado.Add(inscricaoResultado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoResultado", new { id = inscricaoResultado.InscricaoResultadoId }, inscricaoResultado);
        }

        // DELETE: api/InscricaoResultado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoResultado([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoResultado = await _context.InscricaoResultado.SingleOrDefaultAsync(m => m.InscricaoResultadoId == id);
            if (inscricaoResultado == null)
            {
                return NotFound();
            }

            _context.InscricaoResultado.Remove(inscricaoResultado);
            await _context.SaveChangesAsync();

            return Ok(inscricaoResultado);
        }

        private bool InscricaoResultadoExists(string id)
        {
            return _context.InscricaoResultado.Any(e => e.InscricaoResultadoId == id);
        }
    }
}