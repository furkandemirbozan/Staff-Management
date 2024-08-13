using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public int? CompanyId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
