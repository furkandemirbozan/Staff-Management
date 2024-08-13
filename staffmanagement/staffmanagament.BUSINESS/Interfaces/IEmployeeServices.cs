using staffmanagament.CORE;
using staffmanagament.CORE.DTOs;
using staffmanagament.CORE.Models;

namespace staffmanagament.BUSINESS;

public interface IEmployeeServices
{
    Task<Employee> GetEmployeeById(int id);
    
    Task<EmployeeCardDto> GetEmployeeCardAsync(int employeeId);

    Task<MyManagerCardDto> GetMyManagerCardAsync(int employeeId);
    Task<List<EmployeeDto>> GetAllEmployeesAsync(int employeeId);

}
