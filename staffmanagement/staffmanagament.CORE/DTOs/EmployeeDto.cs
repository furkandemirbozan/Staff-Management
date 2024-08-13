using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class EmployeeDto
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string? EmployeeImageUrl { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
    }
}
