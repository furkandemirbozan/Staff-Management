using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int RemainingLeaveDays { get; set; }
        public int CompanyId { get; set; }
        public int EducationLevelId { get; set; }
        public int GenderId { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerEmployeeId { get; set; }
        public bool isActive { get; set; }
        public int? UserId { get; set; }

        public EducationLevel? EducationLevel { get; set; }
        public Gender? Gender { get; set; }
        public Company? Company { get; set; }
        public Job? Job { get; set; }
        public Department? Department { get; set; }
        public Address? Address { get; set; }
        public Salary? Salary { get; set; }
        public Resume? Resume { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Leave>? Leaves { get; set; }
        public User? User { get; set; }
    }
}
