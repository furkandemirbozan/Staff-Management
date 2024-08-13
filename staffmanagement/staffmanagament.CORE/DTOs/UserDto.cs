using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class UserDto
    {
        public int? EmployeeId { get; set; }
        public int? CompanyId { get; set; }
        public string RoleId { get; set; }
        public string Token { get; set; }
    }
}
