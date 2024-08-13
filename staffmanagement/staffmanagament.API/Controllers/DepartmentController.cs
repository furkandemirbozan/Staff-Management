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
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public DepartmentController(IDepartmentRepository departmentRepository, IUserRepository userRepository,AppDbContext context)
        {
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _context = context;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> GetDepartments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var departments = await _context.Departments.Where(d => d.CompanyId == user.CompanyId.Value).Where(d => d.IsActive == true).ToListAsync();

            var getDepartmentDtos = departments.Select(d => new GetDepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                CompanyId = d.CompanyId
            }).ToList();

            return Ok(getDepartmentDtos);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDto>> GetDepartment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null || department.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            var getDepartmentDto = new GetDepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CompanyId = department.CompanyId
            };

            return Ok(getDepartmentDto);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<GetDepartmentDto>> PostDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var department = new Department
            {
                Name = createDepartmentDto.Name,
                CompanyId = user.CompanyId.Value,
                IsActive = true
            };

            await _departmentRepository.AddAsync(department);

            var getDepartmentDto = new GetDepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CompanyId = department.CompanyId
            };

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, getDepartmentDto);
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            if (id != updateDepartmentDto.Id)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null || department.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            department.Name = updateDepartmentDto.Name;

            await _departmentRepository.UpdateAsync(department);

            return NoContent();
        }


        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            department.IsActive = false;
            await _departmentRepository.UpdateAsync(department);

            return Ok("Department deleted successfully.");
        }
    }
}
