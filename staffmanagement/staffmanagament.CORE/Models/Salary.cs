using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        //[ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}
