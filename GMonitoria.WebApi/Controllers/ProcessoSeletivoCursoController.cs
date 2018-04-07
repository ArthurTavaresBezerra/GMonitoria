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
    [Route("api/ProcessoSeletivoCurso")]
    public class ProcessoSeletivoCursoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public ProcessoSeletivoCursoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/ProcessoSeletivoCurso
        [HttpGet]
        public IEnumerable<ProcessoSeletivoCurso> GetProcessoSeletivoCurso()
        {
            return _context.ProcessoSeletivoCurso;
        }

        // GET: api/ProcessoSeletivoCurso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessoSeletivoCurso([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processoSeletivoCurso = await _context.ProcessoSeletivoCurso.SingleOrDefaultAsync(m => m.ProcessoSeletivoCursoId == id);

            if (processoSeletivoCurso == null)
            {
                return NotFound();
            }

            return Ok(processoSeletivoCurso);
        }

        // PUT: api/ProcessoSeletivoCurso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoSeletivoCurso([FromRoute] string id, [FromBody] ProcessoSeletivoCurso processoSeletivoCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != processoSeletivoCurso.ProcessoSeletivoCursoId)
            {
                return BadRequest();
            }

            _context.Entry(processoSeletivoCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoSeletivoCursoExists(id))
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

        // POST: api/ProcessoSeletivoCurso
        [HttpPost]
        public async Task<IActionResult> PostProcessoSeletivoCurso([FromBody] ProcessoSeletivoCurso processoSeletivoCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProcessoSeletivoCurso.Add(processoSeletivoCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessoSeletivoCurso", new { id = processoSeletivoCurso.ProcessoSeletivoCursoId }, processoSeletivoCurso);
        }

        // DELETE: api/ProcessoSeletivoCurso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessoSeletivoCurso([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var processoSeletivoCurso = await _context.ProcessoSeletivoCurso.SingleOrDefaultAsync(m => m.ProcessoSeletivoCursoId == id);
            if (processoSeletivoCurso == null)
            {
                return NotFound();
            }

            _context.ProcessoSeletivoCurso.Remove(processoSeletivoCurso);
            await _context.SaveChangesAsync();

            return Ok(processoSeletivoCurso);
        }

        private bool ProcessoSeletivoCursoExists(string id)
        {
            return _context.ProcessoSeletivoCurso.Any(e => e.ProcessoSeletivoCursoId == id);
        }
    }
}