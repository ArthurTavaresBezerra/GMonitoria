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
    [Route("api/Inscricao")]
    public class InscricaoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public InscricaoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Inscricao
        [HttpGet]
        public IEnumerable<Inscricao> GetInscricao()
        {
            return _context.Inscricao;
        }

        // GET: api/Inscricao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscricao([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricao = await _context.Inscricao.SingleOrDefaultAsync(m => m.InscricaoId == id);

            if (inscricao == null)
            {
                return NotFound();
            }

            return Ok(inscricao);
        }

        // PUT: api/Inscricao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricao([FromRoute] string id, [FromBody] Inscricao inscricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inscricao.InscricaoId)
            {
                return BadRequest();
            }

            _context.Entry(inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(id))
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

        // POST: api/Inscricao
        [HttpPost]
        public async Task<IActionResult> PostInscricao([FromBody] Inscricao inscricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inscricao.Add(inscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricao", new { id = inscricao.InscricaoId }, inscricao);
        }

        // DELETE: api/Inscricao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricao([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inscricao = await _context.Inscricao.SingleOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            _context.Inscricao.Remove(inscricao);
            await _context.SaveChangesAsync();

            return Ok(inscricao);
        }

        private bool InscricaoExists(string id)
        {
            return _context.Inscricao.Any(e => e.InscricaoId == id);
        }
    }
}