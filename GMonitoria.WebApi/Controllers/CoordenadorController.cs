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
    [Route("api/Coordenador")]
    public class CoordenadorController : Controller
    {
        private readonly GMonitoriaContext _context;

        public CoordenadorController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Coordenador
        [HttpGet]
        public IEnumerable<Coordenador> GetCoordenador()
        {
            return _context.Coordenador;
        }

        // GET: api/Coordenador/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoordenador([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coordenador = await _context.Coordenador.SingleOrDefaultAsync(m => m.CoordenadorId == id);

            if (coordenador == null)
            {
                return NotFound();
            }

            return Ok(coordenador);
        }

        // PUT: api/Coordenador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordenador([FromRoute] string id, [FromBody] Coordenador coordenador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordenador.CoordenadorId)
            {
                return BadRequest();
            }

            _context.Entry(coordenador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadorExists(id))
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

        // POST: api/Coordenador
        [HttpPost]
        public async Task<IActionResult> PostCoordenador([FromBody] Coordenador coordenador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coordenador.Add(coordenador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordenador", new { id = coordenador.CoordenadorId }, coordenador);
        }

        // DELETE: api/Coordenador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoordenador([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coordenador = await _context.Coordenador.SingleOrDefaultAsync(m => m.CoordenadorId == id);
            if (coordenador == null)
            {
                return NotFound();
            }

            _context.Coordenador.Remove(coordenador);
            await _context.SaveChangesAsync();

            return Ok(coordenador);
        }

        private bool CoordenadorExists(string id)
        {
            return _context.Coordenador.Any(e => e.CoordenadorId == id);
        }
    }
}