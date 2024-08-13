using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class SalaryDto
    {
        public int? SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal? Amount { get; set; }
    }
}
