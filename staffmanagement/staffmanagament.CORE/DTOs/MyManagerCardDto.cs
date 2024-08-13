using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class MyManagerCardDto
    {
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string? ManagerImageUrl { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
    }
}
