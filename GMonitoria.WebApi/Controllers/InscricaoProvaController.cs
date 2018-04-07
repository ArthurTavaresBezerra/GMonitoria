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
    [Route("api/InscricaoProva")]
    public class InscricaoProvaController : Controller
    {
        private readonly GMonitoriaContext _context;

        public InscricaoProvaController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/InscricaoProva
        [HttpGet]
        public IEnumerable<InscricaoProva> GetInscricaoProva()
        {
            return _context.InscricaoProva;
        }

        // GET: api/InscricaoProva/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscricaoProva([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoProva = await _context.InscricaoProva.SingleOrDefaultAsync(m => m.InscricaoProvaId == id);

            if (inscricaoProva == null)
            {
                return NotFound();
            }

            return Ok(inscricaoProva);
        }

        // PUT: api/InscricaoProva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoProva([FromRoute] string id, [FromBody] InscricaoProva inscricaoProva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inscricaoProva.InscricaoProvaId)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoProva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoProvaExists(id))
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

        // POST: api/InscricaoProva
        [HttpPost]
        public async Task<IActionResult> PostInscricaoProva([FromBody] InscricaoProva inscricaoProva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InscricaoProva.Add(inscricaoProva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoProva", new { id = inscricaoProva.InscricaoProvaId }, inscricaoProva);
        }

        // DELETE: api/InscricaoProva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoProva([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricaoProva = await _context.InscricaoProva.SingleOrDefaultAsync(m => m.InscricaoProvaId == id);
            if (inscricaoProva == null)
            {
                return NotFound();
            }

            _context.InscricaoProva.Remove(inscricaoProva);
            await _context.SaveChangesAsync();

            return Ok(inscricaoProva);
        }

        private bool InscricaoProvaExists(string id)
        {
            return _context.InscricaoProva.Any(e => e.InscricaoProvaId == id);
        }
    }
}