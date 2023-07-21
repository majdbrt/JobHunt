using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobHuntApi.Models;

namespace JobHuntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly JobHuntApiDbContext _context;

        public InterviewController(JobHuntApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Interview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interview>>> GetInterviews()
        {
          if (_context.Interviews == null)
          {
              return NotFound();
          }
            return await _context.Interviews.ToListAsync();
        }

        // GET: api/Interview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interview>> GetInterview(string id)
        {
          if (_context.Interviews == null)
          {
              return NotFound();
          }
            var interview = await _context.Interviews.FindAsync(id);

            if (interview == null)
            {
                return NotFound();
            }

            return interview;
        }

        // PUT: api/Interview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterview(string id, Interview interview)
        {
            if (id != interview.Id)
            {
                return BadRequest();
            }

            _context.Entry(interview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewExists(id))
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

        // POST: api/Interview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Interview>> PostInterview(Interview interview)
        {
          if (_context.Interviews == null)
          {
              return Problem("Entity set 'JobHuntApiDbContext.Interviews'  is null.");
          }
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterview", new { id = interview.Id }, interview);
        }

        // DELETE: api/Interview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(string id)
        {
            if (_context.Interviews == null)
            {
                return NotFound();
            }
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterviewExists(string id)
        {
            return (_context.Interviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
