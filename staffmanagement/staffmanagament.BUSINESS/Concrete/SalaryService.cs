using staffmanagament.BUSINESS.Interfaces;
using staffmanagament.CORE.DTOs;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Concrete
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public SalaryService(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<SalaryDto> AddSalary(SalaryDto salaryDto)
        {
            if (salaryDto == null) throw new ArgumentNullException(nameof(salaryDto));

            var employee = await _employeeRepository.GetByIdAsync(salaryDto.EmployeeId);
            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee ID.");
            }

            var salary = new Salary
            {
                EmployeeId = salaryDto.EmployeeId,
                Amount = salaryDto.Amount ?? 0 // Null ise 0 olarak ayarla
            };

            await _salaryRepository.AddAsync(salary);

            salaryDto.SalaryId = salary.Id;

            return salaryDto;
        }

        public async Task<SalaryDto> DeleteSalary(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("Salary not found.");
            }

            await _salaryRepository.DeleteAsync(salary);

            return new SalaryDto
            {
                SalaryId = salary.Id,
                EmployeeId = salary.EmployeeId,
                Amount = salary.Amount
            };
        }

        public async Task<IEnumerable<SalaryDto>> GetSalaries()
        {
            var salaries = await _salaryRepository.GetAllAsync();
            var salaryDtos = new List<SalaryDto>();

            foreach (var salary in salaries)
            {
                salaryDtos.Add(new SalaryDto
                {
                    SalaryId = salary.Id,
                    EmployeeId = salary.EmployeeId,
                    Amount = salary.Amount
                });
            }

            return salaryDtos;
        }

        public async Task<SalaryDto> GetSalary(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("Salary not found.");
            }

            return new SalaryDto
            {
                SalaryId = salary.Id,
                EmployeeId = salary.EmployeeId,
                Amount = salary.Amount
            };
        }

        public async Task<SalaryDto> UpdateSalary(int id, SalaryDto salaryDto)
        {
            if (salaryDto == null) throw new ArgumentNullException(nameof(salaryDto));

            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("Salary not found.");
            }

            salary.EmployeeId = salaryDto.EmployeeId;
            salary.Amount = salaryDto.Amount ?? salary.Amount; // Null değilse güncelle

            await _salaryRepository.UpdateAsync(salary);

            return new SalaryDto
            {
                SalaryId = salary.Id,
                EmployeeId = salary.EmployeeId,
                Amount = salary.Amount
            };
        }
    }
}
