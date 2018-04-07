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
    [Route("api/HorarioAtendimento")]
    public class HorarioAtendimentoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public HorarioAtendimentoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/HorarioAtendimento
        [HttpGet]
        public IEnumerable<HorarioAtendimento> GetHorarioAtendimento()
        {
            return _context.HorarioAtendimento;
        }

        // GET: api/HorarioAtendimento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHorarioAtendimento([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var horarioAtendimento = await _context.HorarioAtendimento.SingleOrDefaultAsync(m => m.HorarioAtendimentoId == id);

            if (horarioAtendimento == null)
            {
                return NotFound();
            }

            return Ok(horarioAtendimento);
        }

        // PUT: api/HorarioAtendimento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarioAtendimento([FromRoute] string id, [FromBody] HorarioAtendimento horarioAtendimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horarioAtendimento.HorarioAtendimentoId)
            {
                return BadRequest();
            }

            _context.Entry(horarioAtendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioAtendimentoExists(id))
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

        // POST: api/HorarioAtendimento
        [HttpPost]
        public async Task<IActionResult> PostHorarioAtendimento([FromBody] HorarioAtendimento horarioAtendimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HorarioAtendimento.Add(horarioAtendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarioAtendimento", new { id = horarioAtendimento.HorarioAtendimentoId }, horarioAtendimento);
        }

        // DELETE: api/HorarioAtendimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarioAtendimento([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var horarioAtendimento = await _context.HorarioAtendimento.SingleOrDefaultAsync(m => m.HorarioAtendimentoId == id);
            if (horarioAtendimento == null)
            {
                return NotFound();
            }

            _context.HorarioAtendimento.Remove(horarioAtendimento);
            await _context.SaveChangesAsync();

            return Ok(horarioAtendimento);
        }

        private bool HorarioAtendimentoExists(string id)
        {
            return _context.HorarioAtendimento.Any(e => e.HorarioAtendimentoId == id);
        }
    }
}