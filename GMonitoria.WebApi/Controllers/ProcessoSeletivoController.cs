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
    [Route("api/ProcessoSeletivo")]
    public class ProcessoSeletivoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public ProcessoSeletivoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/ProcessoSeletivo
        [HttpGet]
        public IEnumerable<ProcessoSeletivo> GetProcessoSeletivo()
        {
            return _context.ProcessoSeletivo;
        }

        // GET: api/ProcessoSeletivo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessoSeletivo([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processoSeletivo = await _context.ProcessoSeletivo.SingleOrDefaultAsync(m => m.ProcessoSeletivoId == id);

            if (processoSeletivo == null)
            {
                return NotFound();
            }

            return Ok(processoSeletivo);
        }

        // PUT: api/ProcessoSeletivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoSeletivo([FromRoute] string id, [FromBody] ProcessoSeletivo processoSeletivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != processoSeletivo.ProcessoSeletivoId)
            {
                return BadRequest();
            }

            _context.Entry(processoSeletivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoSeletivoExists(id))
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

        // POST: api/ProcessoSeletivo
        [HttpPost]
        public async Task<IActionResult> PostProcessoSeletivo([FromBody] ProcessoSeletivo processoSeletivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProcessoSeletivo.Add(processoSeletivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessoSeletivo", new { id = processoSeletivo.ProcessoSeletivoId }, processoSeletivo);
        }

        // DELETE: api/ProcessoSeletivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessoSeletivo([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processoSeletivo = await _context.ProcessoSeletivo.SingleOrDefaultAsync(m => m.ProcessoSeletivoId == id);
            if (processoSeletivo == null)
            {
                return NotFound();
            }

            _context.ProcessoSeletivo.Remove(processoSeletivo);
            await _context.SaveChangesAsync();

            return Ok(processoSeletivo);
        }

        private bool ProcessoSeletivoExists(string id)
        {
            return _context.ProcessoSeletivo.Any(e => e.ProcessoSeletivoId == id);
        }
    }
}