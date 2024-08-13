using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class GetExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? Description { get; set; }
        public int RequestStatusId { get; set; }
        public int EmployeeId { get; set; }
    }
}
