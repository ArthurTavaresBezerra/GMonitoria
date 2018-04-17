using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMonitoria.Domain.Entities;
using GMonitoria.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Authorization;

namespace GMonitoria.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Aluno")]
    [Authorize("Bearer")]
    public class AlunoController : Controller
    {
        private readonly GMonitoriaContext _context;

        public AlunoController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public IEnumerable<Aluno> GetAlunos()
        {
            return _context.Aluno;
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aluno = await _context.Aluno.SingleOrDefaultAsync(m => m.Matricula == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno([FromRoute] string id, [FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.Matricula)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Aluno
        [HttpPost]
        public async Task<IActionResult> PostAluno([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.Matricula }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aluno = await _context.Aluno.SingleOrDefaultAsync(m => m.Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        private bool AlunoExists(string id)
        {
            return _context.Aluno.Any(e => e.Matricula == id);
        }
    }
}