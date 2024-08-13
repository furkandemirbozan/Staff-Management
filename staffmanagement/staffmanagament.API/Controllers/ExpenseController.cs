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
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public ExpenseController(IExpenseRepository expenseRepository, IUserRepository userRepository, AppDbContext context)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
            _context = context;
        }

        // GET: api/Expense
        [Authorize(Roles = "CompanyManager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExpenseDto>>> GetExpenses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var expenses = await _expenseRepository.FindAsync(e => e.Employee.CompanyId == user.CompanyId.Value);

            var getExpenseDtos = expenses.Select(e => new GetExpenseDto
            {
                Id = e.Id,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                Description = e.Description,
                RequestStatusId = e.RequestStatusId,
                EmployeeId = e.EmployeeId
            }).ToList();

            return Ok(getExpenseDtos);
        }

        // GET: api/Expense/5
        [Authorize(Roles = "CompanyManager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetExpenseDto>> GetExpense(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null || expense.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            var getExpenseDto = new GetExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Description = expense.Description,
                RequestStatusId = expense.RequestStatusId,
                EmployeeId = expense.EmployeeId
            };

            return Ok(getExpenseDto);
        }

        // POST: api/Expense
        [Authorize(Roles = "CompanyUser")]
        [HttpPost("CreateExpenseRequest")]
        public async Task<ActionResult<GetExpenseDto>> CreateExpenseRequest(CreateExpenseDto createExpenseDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Include(u => u.Employee).FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            // var user2 = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            //var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == user.Employee.Id);
            var employee= await _context.Employees.FirstOrDefaultAsync(e=>e.Id ==user.Employee.Id);
            var expense = new Expense
            {
                Amount = createExpenseDto.Amount,
                ExpenseDate = createExpenseDto.ExpenseDate,
                Description = createExpenseDto.Description,
                EmployeeId = employee.Id,
                RequestedDate = DateTime.Now,
                RequestStatusId = 1, // Pending status
            };

            await _expenseRepository.AddAsync(expense);
            
            var getExpenseDto = new GetExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Description = expense.Description,
                RequestStatusId = expense.RequestStatusId,
                EmployeeId = expense.EmployeeId,
                RequestedDate = expense.RequestedDate
            };

            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, getExpenseDto);
        }

        // PUT: api/Expense/5
        [Authorize(Roles = "CompanyManager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, CreateExpenseDto updateExpenseDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null || expense.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            expense.Amount = updateExpenseDto.Amount;
            expense.ExpenseDate = updateExpenseDto.ExpenseDate;
            expense.Description = updateExpenseDto.Description;

            await _expenseRepository.UpdateAsync(expense);

            return NoContent();
        }

        // DELETE: api/Expense/5
        [Authorize(Roles = "CompanyManager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null || expense.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            await _expenseRepository.DeleteAsync(expense);

            return NoContent();
        }

        // PUT: api/Expense/UpdateExpenseStatus
        [Authorize(Roles = "CompanyManager")]
        [HttpPut("UpdateExpenseStatus")]
        public async Task<IActionResult> UpdateExpenseStatus(UpdateExpenseStatusDto updateExpenseStatusDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));

            if (user == null || user.CompanyId == null)
            {
                return BadRequest("User or CompanyId not found.");
            }

            var expense = await _expenseRepository.GetByIdAsync(updateExpenseStatusDto.Id);
            if (expense == null || expense.Employee.CompanyId != user.CompanyId)
            {
                return NotFound();
            }

            expense.RequestStatusId = updateExpenseStatusDto.RequestStatusId;

            await _expenseRepository.UpdateAsync(expense);

            return NoContent();
        }
    }
}
