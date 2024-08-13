using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.DTOs;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;
using staffmanagament.DAL;
using System.Security.Claims;

namespace staffmanagament.API.Controllers
{
    [Authorize(Roles = "CompanyManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;


        public JobController(IJobRepository jobRepository, IUserRepository userRepository, AppDbContext context)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;


            if (companyId == null)
            {
                return Forbid();
            }


            var jobs = await _context.Jobs.Where(j => j.CompanyId == companyId).Where(j => j.IsActive == true).ToListAsync();
            var jobDTOs = jobs.Select(job => new JobDto
            {
                Id = job.Id,
                Title = job.Title
            }).ToList();


            return Ok(jobDTOs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);


            if (job == null)
            {
                return NotFound();
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;


            if (job.CompanyId != companyId)
            {
                return Forbid();
            }


            var jobDTO = new JobDto
            {
                Id = job.Id,
                Title = job.Title
            };


            return Ok(jobDTO);
        }


        [HttpPost]
        public async Task<ActionResult<JobDto>> CreateJob(CreateJobDto createJobDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;


            if (companyId == null)
            {
                return Forbid();
            }


            var job = new Job
            {
                Title = createJobDTO.Title,
                CompanyId = companyId.Value,
                IsActive = true
            };


            await _jobRepository.AddAsync(job);


            var jobDTO = new JobDto
            {
                Id = job.Id,
                Title = job.Title
            };


            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, jobDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobDTO updateJobDTO)
        {
            if (id != updateJobDTO.Id)
            {
                return BadRequest();
            }


            var existingJob = await _jobRepository.GetByIdAsync(id);


            if (existingJob == null)
            {
                return NotFound();
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            var companyId = user.CompanyId;


            if (existingJob.CompanyId != companyId)
            {
                return Forbid();
            }


            existingJob.Title = updateJobDTO.Title;


            await _jobRepository.UpdateAsync(existingJob);


            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            job.IsActive = false;
            await _jobRepository.UpdateAsync(job);


            return Ok("Job deleted successfully.");
        }
    }

}
