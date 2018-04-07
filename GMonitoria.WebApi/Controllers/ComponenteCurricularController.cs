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
    [Route("api/ComponenteCurricular")]
    public class ComponenteCurricularController : Controller
    {
        private readonly GMonitoriaContext _context;

        public ComponenteCurricularController(GMonitoriaContext context)
        {
            _context = context;
        }

        // GET: api/ComponenteCurricular
        [HttpGet]
        public IEnumerable<ComponenteCurricular> GetComponenteCurricular()
        {
            return _context.ComponenteCurricular;
        }

        // GET: api/ComponenteCurricular/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponenteCurricular([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var componenteCurricular = await _context.ComponenteCurricular.SingleOrDefaultAsync(m => m.ComponenteCurricularId == id);

            if (componenteCurricular == null)
            {
                return NotFound();
            }

            return Ok(componenteCurricular);
        }

        // PUT: api/ComponenteCurricular/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponenteCurricular([FromRoute] string id, [FromBody] ComponenteCurricular componenteCurricular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != componenteCurricular.ComponenteCurricularId)
            {
                return BadRequest();
            }

            _context.Entry(componenteCurricular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteCurricularExists(id))
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

        // POST: api/ComponenteCurricular
        [HttpPost]
        public async Task<IActionResult> PostComponenteCurricular([FromBody] ComponenteCurricular componenteCurricular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ComponenteCurricular.Add(componenteCurricular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponenteCurricular", new { id = componenteCurricular.ComponenteCurricularId }, componenteCurricular);
        }

        // DELETE: api/ComponenteCurricular/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponenteCurricular([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var componenteCurricular = await _context.ComponenteCurricular.SingleOrDefaultAsync(m => m.ComponenteCurricularId == id);
            if (componenteCurricular == null)
            {
                return NotFound();
            }

            _context.ComponenteCurricular.Remove(componenteCurricular);
            await _context.SaveChangesAsync();

            return Ok(componenteCurricular);
        }

        private bool ComponenteCurricularExists(string id)
        {
            return _context.ComponenteCurricular.Any(e => e.ComponenteCurricularId == id);
        }
    }
}