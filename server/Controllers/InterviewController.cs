using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobHuntApi.Models;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.Interview;
using Microsoft.AspNetCore.Authorization;

namespace JobHuntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewController(IInterviewRepository interviewRepository)
        {
            this._interviewRepository = interviewRepository;
        }

        // GET: api/Interview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetInterviewDto>>> GetInterviews()
        {
            return Ok(await _interviewRepository.GetAllAsync());
        }

        // GET: api/Interview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetInterviewDto>> GetInterview(string id)
        {
            var interview = await _interviewRepository.GetByIdAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            return Ok(interview);
        }

        // PUT: api/Interview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterview(string id, UpdateInterviewDto updateInterviewDto)
        {
            try
            {
                // Check if id corresponds to an interview
                bool isUpdated = await _interviewRepository.UpdateAsync(id, updateInterviewDto);
                if (!isUpdated)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return NoContent();
        }

        // POST: api/Interview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostInterview(CreateInterviewDto createInterviewDto)
        {
            // Return id of newly created Intervew object
            return Ok(await _interviewRepository.CreateAsync(createInterviewDto));
        }

        // DELETE: api/Interview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(string id)
        {
            try
            {
                // Check if id corresponds to an interview
                bool isDeleted = await _interviewRepository.DeleteAsync(id);
                if (!isDeleted)
                    return NotFound();
            }
            catch
            {
                // Trying to delete record that doesn't exist
                return NotFound();
            }
            return NoContent();
        }

        private async Task<bool> InterviewExists(string id)
        {
            return await _interviewRepository.GetByIdAsync(id) != null;
        }
    }
}
