using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobHuntApi.Models;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.Application;
using Microsoft.AspNetCore.Authorization;

namespace JobHuntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetApplicationDto>>> GetApplications()
        {
            return Ok(await _applicationRepository.GetAllAsync());
        }

        // GET: api/Application/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetApplicationDto>> GetApplication(string id)
        {

            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Application/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(string id, UpdateApplicationDto updateApplicationDto)
        {
            try
            {
                // Check if id corresponds to an application
                bool isUpdated = await _applicationRepository.UpdateAsync(id, updateApplicationDto);
                if (!isUpdated)
                    return NotFound();
            } catch (DbUpdateConcurrencyException){
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Application
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostApplication(CreateApplicationDto createApplicationDto)
        {
            // Return id of newly created application
            return Ok(await _applicationRepository.CreateAsync(createApplicationDto));
        }

        // DELETE: api/Application/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(string id)
        {
            bool isDeleted = await _applicationRepository.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> ApplicationExists(string id)
        {
            return await _applicationRepository.GetByIdAsync(id) != null;
        }
    }
}
