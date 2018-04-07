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
    [Route("api/VagaRequisicao")]
    public class VagaRequisicaoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public VagaRequisicaoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/VagaRequisicao
        [HttpGet]
        public IEnumerable<VagaRequisicao> GetVagaRequisicao()
        {
            return _context.VagaRequisicao;
        }

        // GET: api/VagaRequisicao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVagaRequisicao([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vagaRequisicao = await _context.VagaRequisicao.SingleOrDefaultAsync(m => m.VagaRequisicaoId == id);

            if (vagaRequisicao == null)
            {
                return NotFound();
            }

            return Ok(vagaRequisicao);
        }

        // PUT: api/VagaRequisicao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVagaRequisicao([FromRoute] string id, [FromBody] VagaRequisicao vagaRequisicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vagaRequisicao.VagaRequisicaoId)
            {
                return BadRequest();
            }

            _context.Entry(vagaRequisicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaRequisicaoExists(id))
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

        // POST: api/VagaRequisicao
        [HttpPost]
        public async Task<IActionResult> PostVagaRequisicao([FromBody] VagaRequisicao vagaRequisicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VagaRequisicao.Add(vagaRequisicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVagaRequisicao", new { id = vagaRequisicao.VagaRequisicaoId }, vagaRequisicao);
        }

        // DELETE: api/VagaRequisicao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagaRequisicao([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vagaRequisicao = await _context.VagaRequisicao.SingleOrDefaultAsync(m => m.VagaRequisicaoId == id);
            if (vagaRequisicao == null)
            {
                return NotFound();
            }

            _context.VagaRequisicao.Remove(vagaRequisicao);
            await _context.SaveChangesAsync();

            return Ok(vagaRequisicao);
        }

        private bool VagaRequisicaoExists(string id)
        {
            return _context.VagaRequisicao.Any(e => e.VagaRequisicaoId == id);
        }
    }
}