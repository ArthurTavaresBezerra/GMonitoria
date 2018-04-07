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
    [Route("api/Professor")]
    public class ProfessorController : Controller
    {
        private readonly GMonitoriaContext _context;

        public ProfessorController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Professor
        [HttpGet]
        public IEnumerable<Professor> GetProfessor()
        {
            return _context.Professor;
        }

        // GET: api/Professor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professor.SingleOrDefaultAsync(m => m.ProfessorId == id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor([FromRoute] string id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.ProfessorId)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professor
        [HttpPost]
        public async Task<IActionResult> PostProfessor([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new { id = professor.ProfessorId }, professor);
        }

        // DELETE: api/Professor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professor.SingleOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        private bool ProfessorExists(string id)
        {
            return _context.Professor.Any(e => e.ProfessorId == id);
        }
    }
}