using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staffmanagament.BUSINESS.Interfaces;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISalaryService _salaryService;
        private readonly AppDbContext _context;

        public EmployeeController(IEmployeeRepository employeeRepository, IUserRepository userRepository, ISalaryService salaryService, AppDbContext context)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _salaryService = salaryService;
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetEmployees()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            //var employees = await _employeeRepository.FindAsync(e => e.CompanyId == user.CompanyId.Value);
            var employees = await _context.Employees.Where(e => e.CompanyId == user.CompanyId).Where(e => e.isActive == true).ToListAsync();


            var getEmployeeDTOs = employees.Select(e => new GetEmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                HireDate = e.HireDate,
                BirthDate = e.BirthDate,
                PhoneNumber = e.PhoneNumber,
                RemainingLeaveDays = e.RemainingLeaveDays,
                EducationLevelId = e.EducationLevelId,
                GenderId = e.GenderId,
                JobId = e.JobId,
                DepartmentId = e.DepartmentId,
                isActive = e.isActive,
                UserId = e.UserId
            }).ToList();

            return Ok(getEmployeeDTOs);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null || employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<CreateEmployeeDto>> PostEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var employee = new Employee
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                Email = createEmployeeDto.Email,
                HireDate = createEmployeeDto.HireDate,
                BirthDate = createEmployeeDto.BirthDate,
                PhoneNumber = createEmployeeDto.PhoneNumber,
                RemainingLeaveDays = createEmployeeDto.RemainingLeaveDays,
                EducationLevelId = createEmployeeDto.EducationLevelId,
                GenderId = createEmployeeDto.GenderId,
                JobId = createEmployeeDto.JobId,
                DepartmentId = createEmployeeDto.DepartmentId,
                isActive = createEmployeeDto.isActive,
                UserId = createEmployeeDto.UserId,
                CompanyId = user.CompanyId.Value,
                Resume = new Resume
                {
                    Path = createEmployeeDto.CreateResumeDto.Path,
                    CompanyId = user.CompanyId.Value,
                },
                Salary = new Salary
                {
                    Amount = (decimal)createEmployeeDto.SalaryDto.Amount,
                },
                Address = new Address
                {
                    StreetAddress = createEmployeeDto.createAddressDto.StreetAddress,
                    PostalCode = createEmployeeDto.createAddressDto.PostalCode,
                    City = createEmployeeDto.createAddressDto.City,
                    State = createEmployeeDto.createAddressDto.State,
                    Country = createEmployeeDto.createAddressDto.Country,
                }
            };

            await _employeeRepository.AddAsync(employee);

            return createEmployeeDto;
        }


        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            if (id != updateEmployeeDto.Id)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null || employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            if (updateEmployeeDto.FirstName != null)
                employee.FirstName = updateEmployeeDto.FirstName;
            if (updateEmployeeDto.LastName != null)
                employee.LastName = updateEmployeeDto.LastName;
            if (updateEmployeeDto.Email != null)
                employee.Email = updateEmployeeDto.Email;
            if (updateEmployeeDto.HireDate != null)
                employee.HireDate = (DateTime)updateEmployeeDto.HireDate;
            if (updateEmployeeDto.BirthDate != null)
                employee.BirthDate = (DateTime)updateEmployeeDto.BirthDate;
            if (updateEmployeeDto.PhoneNumber != null)
                employee.PhoneNumber = updateEmployeeDto.PhoneNumber;
            if (updateEmployeeDto.RemainingLeaveDays != null)
                employee.RemainingLeaveDays = (int)updateEmployeeDto.RemainingLeaveDays;
            if (updateEmployeeDto.EducationLevelId != null)
                employee.EducationLevelId = (int)updateEmployeeDto.EducationLevelId;
            if (updateEmployeeDto.GenderId != null)
                employee.GenderId = (int)updateEmployeeDto.GenderId;
            if (updateEmployeeDto.JobId != null)
                employee.JobId = (int)updateEmployeeDto.JobId;
            if (updateEmployeeDto.DepartmentId != null)
                employee.DepartmentId = (int)updateEmployeeDto.DepartmentId;
            if (updateEmployeeDto.isActive != null)
                employee.isActive = (bool)updateEmployeeDto.isActive;
            if (updateEmployeeDto.UserId != null)
                employee.UserId = updateEmployeeDto.UserId;


            await _employeeRepository.UpdateAsync(employee);
            return Ok("Employee updated successfully.");
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            employee.isActive = false;
            await _employeeRepository.UpdateAsync(employee);

            return Ok("Employee deleted successfully.");
        }
        // GET: api/Employee/5/salaries
        [HttpGet("{id}/salaries")]
        public async Task<ActionResult<IEnumerable<SalaryDto>>> GetSalaries(int id)
        {
            var salaries = await _salaryService.GetSalaries();
            var employeeSalaries = salaries.Where(s => s.EmployeeId == id);

            return Ok(employeeSalaries);
        }

        // POST: api/Employee/{id}/salaries
        [HttpPost("{id}/salaries")]
        public async Task<ActionResult<SalaryDto>> PostSalary(int id, SalaryDto salaryDto)
        {
            if (id != salaryDto.EmployeeId)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var employee = await _employeeRepository.GetByIdAsync((int)salaryDto.EmployeeId);
            if (employee == null)
                return NotFound("Employee not found.");
            if (employee.Salary.Id != null)
                return BadRequest("Employee already has a salary.");


            var salary = await _salaryService.AddSalary(salaryDto);
            return CreatedAtAction(nameof(GetSalaries), new { id = salary.EmployeeId }, salary);
        }



        [HttpPut("{employeeId}/salary")]
        public async Task<IActionResult> PutSalary(int employeeId, SalaryDto salaryDto)
        {
            if (employeeId != salaryDto.EmployeeId)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var updatedSalary = await _salaryService.UpdateSalary(employeeId, salaryDto);
            return Ok(updatedSalary);
        }
        // POST: api/Employee/assign-job
        [HttpPost("assign-job")]
        public async Task<IActionResult> AssignJob(JobAssignmentDto jobAssignmentDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(jobAssignmentDto.EmployeeId);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null || employee.CompanyId != user.CompanyId)
            {
                return BadRequest("User or CompanyId not found or mismatch.");
            }

            employee.JobId = jobAssignmentDto.JobId;
            await _employeeRepository.UpdateAsync(employee);

            return Ok("Job assigned to employee successfully.");
        }
        // POST: api/Employee/assign-department
        [HttpPost("assign-department")]
        public async Task<IActionResult> AssignDepartment(DepartmenAssigmentDto departmentAssignmentDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(departmentAssignmentDto.EmployeeId);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null || employee.CompanyId != user.CompanyId)
            {
                return BadRequest("User or CompanyId not found or mismatch.");
            }

            employee.DepartmentId = departmentAssignmentDto.DepartmentId;
            await _employeeRepository.UpdateAsync(employee);

            return Ok("Department assigned to employee successfully.");
        }
        
        // POST: api/Employee/assign-user
        [HttpPost("assign-user")]
        public async Task<IActionResult> AssignUser(UserAssignmenDto userAssignmentDto)
        {
            var assignEmployee = await _employeeRepository.GetByIdAsync(userAssignmentDto.EmployeeId);
            if (assignEmployee == null)
            {
                return NotFound("Employee not found.");
            }
            var assignUser = await _userRepository.GetByIdAsync(userAssignmentDto.UserId);
            if (assignUser == null)
            {
                return NotFound("User not found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null || assignEmployee.CompanyId != assignUser.CompanyId)
            {
                return BadRequest("Not found or mismatch.");
            }

            assignEmployee.UserId = userAssignmentDto.UserId;
            await _employeeRepository.UpdateAsync(assignEmployee);

            return Ok("Department assigned to employee successfully.");
        }
    }


}

