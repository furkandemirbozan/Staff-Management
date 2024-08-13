using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Company")]
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        //[ForeignKey("Employee")]

        // Navigation properties
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
